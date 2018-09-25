using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EPocalipse.Json.JsonView;
using log4net;
using System.Runtime.InteropServices;
using System.Linq;
using Itlezy.Common.Platform;
using Itlezy.App.OutputViewer.Text;
using Itlezy.App.OutputViewer.Tail;
using Itlezy.App.OutputViewer.UI;
using Itlezy.Common.JSON;

namespace Itlezy.App.OutputViewer.UI
{
    public partial class OutputViewerUserControl : UserControl, IJsonItemsSource
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(OutputViewerUserControl));

        /// <summary>
        /// JSON Extractor
        /// </summary>
        private readonly JsonExtractor jsonExtractor = new JsonExtractor();
        /// <summary>
        /// XML Extractor
        /// </summary>
        private readonly XmlExtractor xmlExtractor = new XmlExtractor();
        /// <summary>
        /// Line matching logic
        /// </summary>
        private readonly Matching matching = new Matching();
        /// <summary>
        /// Search service
        /// </summary>
        private readonly Search search = new Search();
        /// <summary>
        /// Messages buffer
        /// </summary>
        private readonly StringBuilder messages = new StringBuilder();
        /// <summary>
        /// Buffered lines count
        /// </summary>
        private int bufferedLinesCount = 0;
        /// <summary>
        /// Tail Monitor, to tail log files
        /// </summary>
        private TailMonitor tailMonitor;
        /// <summary>
        /// The current ItemId opened (tab's title)
        /// </summary>
        public String ItemId { get; set; }
        /// <summary>
        /// Is it paused?
        /// </summary>
        private bool pause;
        /// <summary>
        /// Last line highlighted
        /// </summary>
        private int lastHighlightedLine = 0;
        /// <summary>
        /// Count of error lines detected
        /// </summary>
        private int errorCount = 0;

        /// <summary>
        /// New content event handler
        /// </summary>
        public delegate void NewContentEventHandler();
        /// <summary>
        /// New content event
        /// </summary>
        public event NewContentEventHandler NewContent;

        /// <summary>
        /// Lock object (not really necessary)
        /// </summary>
        private readonly Object lockObject = new Object();

        public IList<JsonItem> JsonItems
        {
            get
            {
                return jsonExtractor.Extract(SelectedOrAllText);
            }
        }

        private String SelectedOrAllText
        {
            get
            {
                return txtOutput.Selection.Length > 0 ?
                   txtOutput.Selection.Text :
                   txtOutput.Text;
            }
        }

        public OutputViewerUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Scroll to the end of text, if autoscroll enabled
        /// </summary>
        private void ScrollToTail()
        {
            if (ckAutoScroll.Checked && txtOutput.Text.Length > 2)
            {
                txtOutput.Scrolling.ScrollToLine(txtOutput.Lines.Count);
            }
        }

        /// <summary>
        /// Tail a file
        /// </summary>
        /// <param name="fileName"></param>
        public void Tail(String fileName)
        {
            tailMonitor = new TailMonitor(fileName);

            tailMonitor.NewLine += delegate(String line)
            {
                // Appends messages to the StringBuilder, so no need to use Invoke
                AppendMsg(line, OutputKind.STDOUT);
            };

            tailMonitor.Start();
        }

        public void DisposeTail()
        {
            if (tailMonitor != null)
            {
                tailMonitor.Dispose();
            }
        }

        public void AppendMsg(String msg, OutputKind kind)
        {
            if (msg != null)
            {
                lock (lockObject)
                {
                    // quick and dirty way to get the hl for STDERR
                    messages.AppendLine(
                        kind == OutputKind.STDERR && !String.IsNullOrWhiteSpace(msg) ?
                        "ERROR [stderr] " + msg :
                        msg);

                    bufferedLinesCount += (1 + msg.Count(c => c == '\n'));

                    if (NewContent != null)
                    {
                        NewContent();
                    }
                }
            }
        }

        void CkWrapCheckedChanged(object sender, EventArgs e)
        {
            txtOutput.LineWrapping.Mode = ckWrap.Checked ?
                ScintillaNET.LineWrappingMode.Char : ScintillaNET.LineWrappingMode.None;

            ScrollToTail();
        }

        private void Highlight()
        {
            int linesLength = txtOutput.Lines.Count;

            if (lastHighlightedLine > linesLength)
            {
                lastHighlightedLine = 0;
            }
            else if (lastHighlightedLine > 20)
            {
                lastHighlightedLine -= 20;
            }

            for (int i = Math.Max(lastHighlightedLine, linesLength - 500); i < linesLength; i++)
            {
                var currentLine = txtOutput.Lines[i];

                if (currentLine.GetMarkers().Count > 0)
                {
                    continue;
                }

                var currentLineText = currentLine.Text;

                if (matching.IsWarning(currentLineText))
                {
                    currentLine.AddMarker(txtOutput.Markers[0]);
                    errorCount++;
                }
                else if (matching.IsError(currentLineText) || matching.IsErrorDetail(currentLineText))
                {
                    currentLine.AddMarker(txtOutput.Markers[1]);

                    if (matching.IsError(currentLineText))
                    {
                        errorCount++;
                    }
                }
            }

            lastHighlightedLine = linesLength;
        }

        void NumFontSizeValueChanged(object sender, EventArgs e)
        {
            txtOutput.Font = new Font(txtOutput.Font.Name, decimal.ToInt32(numFontSize.Value));
            txtOutput.Styles.LineNumber.Font = new Font(txtOutput.Font.Name, decimal.ToInt32(numFontSize.Value));
        }

        void CkTailCheckedChanged(object sender, EventArgs e)
        {
            if (ckTail.Checked)
            {
                pause = false;
                PerformUpdate();
            }
            else
            {
                pause = true;
            }
        }

        void BtnClearClick(object sender, EventArgs e)
        {
            ClearOutput(false);
        }

        /// <summary>
        /// Clear the current output
        /// </summary>
        /// <param name="all">Include buffered messages?</param>
        public void ClearOutput(bool all)
        {
            if (all)
            {
                messages.Clear();
            }

            lastHighlightedLine = 0;
            errorCount = 0;
            txtOutput.Text = String.Empty;

            txtMessagesLen.Text = 0.ToString("D10");
            txtOutputLen.Text = txtOutput.Lines.Count.ToString("D10");
            txtErrorCount.Text = errorCount.ToString();
        }

        void BtnCopyClick(object sender, EventArgs e)
        {
            if (txtOutput.Selection.Length > 0)
            {
                ClipboardHelper.SetText(txtOutput.Selection.Text);
            }
            else if (txtOutput.TextLength > 0)
            {
                ClipboardHelper.SetText(txtOutput.Text);
            }
        }

        /// <summary>
        /// Allow to set focus to the output viewer
        /// </summary>
        public void FocusOutput()
        {
            txtOutput.Focus();
        }

        /// <summary>
        /// Will pause appending text to the output viewer
        /// </summary>
        public void Pause()
        {
            pause = true;
        }

        public void Resume()
        {
            if (ckTail.Checked)
            {
                pause = false;
                PerformUpdate();
            }
        }

        /// <summary>
        /// Updates the output viewer with the content of the buffered messages
        /// Will perform highlighting and scrolling
        /// </summary>
        private void PerformUpdate()
        {
            lock (lockObject) // the lock is probably not necessary
            {
                if (messages.Length > 0)
                {
                    bool wasPaused = pause;
                    pause = true;

                    txtOutput.AppendText(messages.ToString());

                    messages.Clear();
                    bufferedLinesCount = 0;

                    Highlight();

                    ScrollToTail();

                    txtOutputLen.Text = txtOutput.Lines.Count.ToString("D10");

                    pause = wasPaused;
                }
            }
        }

        void TimUpdateTextTick(object sender, EventArgs e)
        {
            txtMessagesLen.Text = bufferedLinesCount.ToString("D10");
            txtErrorCount.Text = errorCount.ToString();

            if (!pause)
            {
                PerformUpdate();
            }
        }

        void BtnSaveClick(object sender, EventArgs e)
        {
            using (SaveFileDialog sd = new SaveFileDialog())
            {
                sd.FileName = GetSuggestedFileName();

                if (DialogResult.OK == sd.ShowDialog())
                {
                    String fileName = sd.FileName;
                    if (!fileName.Contains("."))
                    {
                        fileName += ".txt";
                    }

                    File.WriteAllText(fileName, txtOutput.Text);
                }
            }
        }

        void BtnNotepadClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(txtOutput.Text);
        }

        private void SaveAndRunNotepad(String content)
        {
            if (!String.IsNullOrWhiteSpace(content))
            {
                String fpath = Path.GetTempPath() + GetSuggestedFileName();
                File.WriteAllText(fpath, content);

                String notepad = Environment.GetEnvironmentVariable("NOTEPAD");
                if (String.IsNullOrWhiteSpace(notepad))
                {
                    notepad = "notepad.exe";
                }
                Process.Start(notepad, "\"" + fpath + "\"");
            }
        }

        private String GetSuggestedFileName()
        {
            String fileName;
            if (tailMonitor != null)
            {
                fileName = Path.GetFileNameWithoutExtension(tailMonitor.FileName);
            }
            else
            {
                fileName = ItemId;
            }

            foreach (char c in Path.GetInvalidPathChars().Union(Path.GetInvalidFileNameChars()))
            {
                fileName = fileName.Replace(c, '_');
            }

            return "log_" + fileName + "_" +
                DateTime.Today.ToString("yyyy-MM-dd") + "_" +
                DateTime.Now.ToString("HH-mm-ss") + ".txt";
        }

        void BtnFilterErrorClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(search.FilterText(txtOutput.Text,
                new List<ISet<SearchCriteria>>() { 
                    matching.ErrorLevel,
                    matching.ErrorLevelDetail
                }));
        }

        void BtnFilterWarnClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(search.FilterText(txtOutput.Text,
                new List<ISet<SearchCriteria>>() { 
                    matching.ErrorLevel,
                    matching.ErrorLevelDetail,
                    matching.WarningLevel
                }));
        }

        void BtnFilterInfoClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(search.FilterText(txtOutput.Text,
                new List<ISet<SearchCriteria>>() { 
                    matching.ErrorLevel,
                    matching.ErrorLevelDetail,
                    matching.WarningLevel,
                    matching.InfoLevel
                }));
        }

        void BtnMarkClick(object sender, EventArgs e)
        {
            bool wasPaused = pause;

            pause = true;

            txtOutput.AppendText(
                Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                "---------------------------------------------------------------" +
                Environment.NewLine +
                "                         " +
                DateTime.Now.ToString("HH:mm:ss") +
                "                              " +
                Environment.NewLine +
                "---------------------------------------------------------------" +
                Environment.NewLine +
                Environment.NewLine
            );

            pause = wasPaused;

            ScrollToTail();
        }

        void JSONToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(jsonExtractor.Extract(txtOutput.Text, false));
        }

        void XMLToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveAndRunNotepad(xmlExtractor.Extract(SelectedOrAllText));
        }

        private int jsonViewersCount;

        private EPocalipse.Json.JsonView.MainForm InstanciateJsonViewer()
        {
            EPocalipse.Json.JsonView.MainForm jsonView = 
                new EPocalipse.Json.JsonView.MainForm(this) { CustomTitle = ItemId + " | " + CustomTitle + " (" + ++jsonViewersCount + ")" };

            jsonView.Show();
            jsonView.Activate();

            return jsonView;
        }

        void JSONViewerListToolStripMenuItemClick(object sender, EventArgs e)
        {
            InstanciateJsonViewer();
        }

        void TxtRegexGroupKeyDown(object sender, KeyEventArgs e)
        {
            txtRegexGroup.BackColor = SystemColors.Window;

            if (e.KeyCode == Keys.Escape)
            {
                txtRegexGroup.Clear();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txtRegexGroup.Text))
                {
                    return;
                }

                txtRegexGroup.AutoCompleteCustomSource.Add(txtRegexGroup.Text);

                String searchResult;

                if (e.Control && e.Shift)
                {
                    // Regexp extraction
                    searchResult = search.RegexExtract(
                            txtOutput.Text,
                            new SearchCriteria()
                            {
                                SearchTerm = txtRegexGroup.Text,
                                CaseSensitive = ckCase.Checked
                            });
                }
                else
                {
                    // normal search
                    searchResult = search.FilterText(
                            txtOutput.Text,
                            new SearchCriteria()
                            {
                                SearchTerm = txtRegexGroup.Text,
                                CaseSensitive = ckCase.Checked
                            });
                }

                if (e.Control)
                {
                    SaveAndRunNotepad(searchResult);
                }
                else if (!String.IsNullOrEmpty(searchResult))
                {
                    ClipboardHelper.SetText(searchResult);
                }
            }
        }

        void OutputViewerUserControlLoad(object sender, EventArgs e)
        {
            txtOutput.Font = new Font(txtOutput.Font.Name, decimal.ToInt32(numFontSize.Value));
            txtOutput.Styles.LineNumber.Font = new Font(txtOutput.Font.Name, decimal.ToInt32(numFontSize.Value));

            txtOutput.Markers[0].BackColor = Color.PeachPuff;
            txtOutput.Markers[0].Symbol = ScintillaNET.MarkerSymbol.Background;

            txtOutput.Markers[1].BackColor = Color.LightCoral;
            txtOutput.Markers[1].Symbol = ScintillaNET.MarkerSymbol.Background;

            txtOutput.MouseWheel += new MouseEventHandler(txtOutput_MouseWheel);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F3 | Keys.Shift))
            {
                incrementalSearcher.findPrevious();
            }
            else if (keyData == Keys.F3)
            {
                incrementalSearcher.findNext();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void BtnScrollToTailClick(object sender, EventArgs e)
        {
            ckAutoScroll.Checked = true;
            ckTail.Checked = true;

            pause = false;

            ScrollToTail();
        }

        void BtnScrollToTopClick(object sender, EventArgs e)
        {
            ckAutoScroll.Checked = false;

            txtOutput.Scrolling.ScrollToLine(0);
        }

        void BtnMailToClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtOutput.Text))
            {
                String fname = GetSuggestedFileName();
                String fpath = Path.GetTempPath() + fname;
                File.WriteAllText(fpath, txtOutput.Text);

                try
                {
                    // mail is not critical
                    ProcessStartInfo pi = new ProcessStartInfo();
                    pi.FileName = "mailto:a@example.com?Subject=" + fname + "&Body=" + fname;
                    pi.UseShellExecute = true;
                    Process.Start(pi);
                }
                catch (Exception ex)
                {
                    logger.Warn("", ex);
                }

                Process.Start("explorer.exe", "/Select,\"" + fpath + "\"");
            }
        }

        private void txtOutput_MarginClick(object sender, ScintillaNET.MarginClickEventArgs e)
        {
            if (e.Line != null && !String.IsNullOrEmpty(e.Line.Text))
            {
                ClipboardHelper.SetText(e.Line.Text);
            }
        }

        private void txtOutput_Scroll(object sender, ScrollEventArgs e)
        {
            //if (logger.IsDebugEnabled)
            //{
            //    logger.DebugFormat("Scroll Event Type {0} NewValue {1} OldValue {2}, ReachedBottom {3}",
            //        e.Type, e.NewValue, e.OldValue, ReachedBottom);
            //}

            if (e.Type == ScrollEventType.EndScroll)
            {
                ckAutoScroll.Checked = ReachedBottom;
            }
        }

        [DllImport("user32")]
        private static extern int GetScrollInfo(IntPtr hwnd, int nBar, ref SCROLLINFO scrollInfo);

        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int min;
            public int max;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        [System.Flags]
        public enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS
        }

        private bool ReachedBottom
        {
            get
            {
                SCROLLINFO scrollInfo = new SCROLLINFO();
                scrollInfo.cbSize = (uint)Marshal.SizeOf(scrollInfo);
                scrollInfo.fMask = (uint)ScrollInfoMask.SIF_ALL;

                GetScrollInfo(
                    txtOutput.Handle,
                    // nBar = 1 -> VScrollbar
                    1,
                    ref scrollInfo);

                //if (logger.IsDebugEnabled)
                //{
                //    logger.DebugFormat("Scroll Info cbSize {0} fMask {1} min {2} max {3} " +
                //        "nPage {4} nPos {5} nTrackPos {6}, calc {7}",
                //        scrollInfo.cbSize, scrollInfo.fMask, scrollInfo.min, scrollInfo.max, scrollInfo.nPage,
                //        scrollInfo.nPos, scrollInfo.nTrackPos, (scrollInfo.nPos + scrollInfo.nPage + 5));
                //}

                if (scrollInfo.nPos > scrollInfo.max || scrollInfo.nPos < 0)
                {
                    return false;
                }
                else
                {
                    return scrollInfo.max <= (scrollInfo.nPos + scrollInfo.nPage + 5);
                }
            }
        }

        private void txtOutput_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ckAutoScroll.Checked && e.Delta > 0)
            {
                ckAutoScroll.Checked = false;
            }
            else if (!ckAutoScroll.Checked && e.Delta < 0 && ReachedBottom)
            {
                ckAutoScroll.Checked = true;
            }
        }

        private void txtOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearOutput(false);
            }
            else if (ckAutoScroll.Checked && (
                (e.KeyCode == Keys.PageUp && !ReachedBottom) ||
                (e.KeyCode == Keys.Up && !ReachedBottom) ||
                (e.Control && e.KeyCode == Keys.Home)))
            {
                ckAutoScroll.Checked = false;
            }
            else if (!ckAutoScroll.Checked && (
                (e.Control && e.KeyCode == Keys.End) ||
                (e.KeyCode == Keys.PageDown && ReachedBottom) ||
                (e.KeyCode == Keys.Down && ReachedBottom)))
            {
                ckAutoScroll.Checked = true;
            }
        }

        private void btnJsonViewerList_Click(object sender, EventArgs e)
        {
            InstanciateJsonViewer();
        }

        private void txtOutput_Resize(object sender, EventArgs e)
        {
            ScrollToTail();
        }

        private void ckCase_CheckedChanged(object sender, EventArgs e)
        {
            txtOutput.FindReplace.Window.chkMatchCaseF.Checked = ckCase.Checked;
        }

        private void incrementalSearcher_Search()
        {
            ckAutoScroll.Checked = false;
        }

        public string CustomTitle { get; set; }

        private void txtOutput_SelectionChanged(object sender, EventArgs e)
        {
            if (txtOutput.Selection.Length > 0)
            {
                ckAutoScroll.Checked = false;
            }
        }
    }
}
