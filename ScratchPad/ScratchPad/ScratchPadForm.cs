using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Itlezy.Common.Platform;
using Newtonsoft.Json;

namespace Itlezy.App.ScratchPad.UI
{
    public partial class ScratchPadForm : Form
    {
        private readonly ICollection<String> clipboardHistory = new LinkedList<String>();

        public bool Persistent
        {
            get;
            set;
        }

        public ScratchPadForm()
        {
            InitializeComponent();
        }

        void TimCheckClipboardTick(object sender, EventArgs e)
        {
            lstClipboardHistory.BeginUpdate();

            int previousSelected = lstClipboardHistory.SelectedIndex;

            bool added = false;

            // Get the DataObject.
            try
            {
                IDataObject dataObject = Clipboard.GetDataObject();

                if (dataObject.GetDataPresent(DataFormats.Text))
                {
                    String clipboardText = Clipboard.GetText();
                    if (!clipboardHistory.Contains(clipboardText))
                    {
                        clipboardHistory.Add(clipboardText);
                        added = true;
                    }
                }
            }
            catch { }

            if (added)
            {
                previousSelected++;
                lstClipboardHistory.Items.Clear();
                lstClipboardHistory.Items.AddRange(clipboardHistory.Reverse().ToArray());
            }

            if (lstClipboardHistory.Items.Count > 0)
            {
                if (previousSelected >= 0 && previousSelected < lstClipboardHistory.Items.Count)
                {
                    lstClipboardHistory.SelectedIndex = previousSelected;
                }
                else
                {
                    lstClipboardHistory.SelectedIndex = 0;
                }
            }

            lstClipboardHistory.EndUpdate();

            lstClipboardHistory.TopIndex = lstClipboardHistory.SelectedIndex;
        }

        void LstClipboardHistoryDoubleClick(object sender, EventArgs e)
        {
            if (lstClipboardHistory.SelectedIndex >= 0)
            {
                CurrentEditor.Editor.AppendText(Environment.NewLine +
                    lstClipboardHistory.Items[lstClipboardHistory.SelectedIndex]);
            }
        }

        void ClearHistoryToolStripMenuItemClick(object sender, EventArgs e)
        {
            ClipboardHelper.Clear();
            clipboardHistory.Clear();
            lstClipboardHistory.Items.Clear();
        }

        void ClearTextToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = String.Empty;
        }

        void ScratchPadFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Persistent)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        void NewTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            NewTab();
        }

        private void NewTab()
        {
            TabPage t = new TabPage("Tab " + (tabControl1.TabPages.Count + 1) + " (" + DateTime.Now.ToString("HH:mm:ss") + ")");
            ScratchPadUserControl u = new ScratchPadUserControl();
            tabControl1.TabPages.Add(t);
            u.Dock = DockStyle.Fill;
            t.Controls.Add(u);

            u.Editor.TextChanged += delegate(object sender, EventArgs e) { UpdateEditorInfo(); };
            u.Editor.SelectionChanged += delegate(object sender, EventArgs e) { UpdateEditorInfo(); };

            tabControl1.SelectedTab = t;

            UpdateEditorInfo();

            u.Editor.Select();
        }

        private void UpdateEditorInfo()
        {
            tlslblEditorInfo.Text = String.Format("Selected {0}/{1}",
                                                  CurrentEditor.Editor.Selection.Length,
                                                  CurrentEditor.Editor.TextLength);
        }

        void ScratchPadFormLoad(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CustomTitle))
            {
                this.Text += " | " + CustomTitle;
            }

            tlcmbEncoding.SelectedIndex = 3;
            NewTab();
        }

        private ScratchPadUserControl CurrentEditor
        {
            get
            {
                return tabControl1.SelectedTab.Controls[0] as ScratchPadUserControl;
            }
        }

        void ToBase64ToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = Convert.ToBase64String(CurrentEncoding.GetBytes(CurrentEditor.Editor.Text));
        }

        private Encoding CurrentEncoding
        {
            get
            {
                String enc = tlcmbEncoding.Items[tlcmbEncoding.SelectedIndex].ToString();
                return Encoding.GetEncoding(enc);
            }
        }

        void FromBase64ToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                CurrentEditor.Editor.Text = CurrentEncoding.GetString(Convert.FromBase64String(CurrentEditor.Editor.Text));
            }
            catch (Exception ex)
            {
                CurrentEditor.Editor.Text = ex.ToString();
            }
        }

        void ToURLEncodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = HttpUtility.UrlEncode(CurrentEditor.Editor.Text);
        }

        void FromURLEncodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                CurrentEditor.Editor.Text = HttpUtility.UrlDecode(CurrentEditor.Editor.Text);
            }
            catch (Exception ex)
            {
                CurrentEditor.Editor.Text = ex.ToString();
            }
        }

        void ToHTMLEscapeToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = HttpUtility.HtmlEncode(CurrentEditor.Editor.Text);
        }

        void FromHTMLEscapeToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                CurrentEditor.Editor.Text = HttpUtility.HtmlDecode(CurrentEditor.Editor.Text);
            }
            catch (Exception ex)
            {
                CurrentEditor.Editor.Text = ex.ToString();
            }
        }

        void HTMLAttributeEncodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = HttpUtility.HtmlAttributeEncode(CurrentEditor.Editor.Text);
        }

        void JavaScriptStringEncodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = HttpUtility.JavaScriptStringEncode(CurrentEditor.Editor.Text);
        }

        private String GetSuggestedFileName()
        {
            return "scratchPad_" +
                DateTime.Today.ToString("yyyy-MM-dd") + "_" +
                DateTime.Now.ToString("HH-mm-ss") + ".txt";
        }

        void SaveToolStripMenuItemClick(object sender, EventArgs e)
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

                    File.WriteAllText(fileName, CurrentEditor.Editor.Text, CurrentEncoding);
                }
            }
        }

        private String PrettyXml(String xml)
        {
            try
            {
                var stringBuilder = new StringBuilder();

                var element = XElement.Parse(xml);

                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                settings.Encoding = CurrentEncoding;

                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    element.Save(xmlWriter);
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                //
                return ex.ToString();
            }
        }

        void XMLToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = PrettyXml(CurrentEditor.Editor.Text);
        }

        void ToCodeStringWithCRLFToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, true, true);
        }

        private String ToCodeString(String s, bool withCR, bool withLF)
        {
            return ToCodeString(s, withCR, withLF, false);
        }

        private String ToCodeString(String s, bool withCR, bool withLF, bool singleQuote)
        {
            using (StringReader sr = new StringReader(s))
            {
                StringBuilder sb = new StringBuilder();

                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (singleQuote)
                    {
                        sb.Append(EscapeCodeLineSingleQuote(line, withCR, withLF));
                    }
                    else
                    {
                        sb.Append(EscapeCodeLine(line, withCR, withLF));
                    }
                    sb.AppendLine();
                }

                return sb.ToString();
            }
        }

        private String EscapeCodeLine(String s, bool withCR, bool withLF)
        {
            return "\"" + s.Replace("\\", "\\\\").Replace("\"", "\\\"") + (withCR && withLF ? "\\r" : "") + (withLF ? "\\n" : "") + "\" +";
        }

        private String EscapeCodeLineSingleQuote(String s, bool withCR, bool withLF)
        {
            return "'" + s.Replace("\\", "\\\\").Replace("'", "\\'") + (withCR && withLF ? "\\r" : "") + (withLF ? "\\n" : "") + "' +";
        }

        void ToCodeStringWithLFToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, false, true);
        }

        void ToCodeStringOneLineToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, false, false);
        }

        void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEditorInfo();

            CurrentEditor.Editor.Focus();
        }

        void TrimBothToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = Trim(CurrentEditor.Editor.Text, true, true);
        }

        private String Trim(String s, bool l, bool r)
        {
            using (StringReader sr = new StringReader(s))
            {
                StringBuilder sb = new StringBuilder();

                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (l && r)
                    {
                        sb.Append(line.Trim());
                    }
                    else if (l)
                    {
                        sb.Append(line.TrimStart());
                    }
                    else if (r)
                    {
                        sb.Append(line.TrimEnd());
                    }

                    sb.AppendLine();
                }

                return sb.ToString();
            }
        }

        void TrimEndToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = Trim(CurrentEditor.Editor.Text, false, true);
        }

        void TrimLeftToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = Trim(CurrentEditor.Editor.Text, true, false);
        }

        void TlsOnTopCheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = tlsOnTop.Checked;
        }

        private void toCodeStringSingleQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, false, false, true);
        }

        private void toCodeStringSingleQuoteWithCRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, true, true, true);
        }

        private void toCodeStringSingleQuoteWithLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentEditor.Editor.Text = ToCodeString(CurrentEditor.Editor.Text, false, true, true);
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                JsonSerializer s = new JsonSerializer();
                JsonReader reader = new JsonReader(new StringReader(CurrentEditor.Editor.Text));
                Object jsonObject = s.Deserialize(reader);
                if (jsonObject != null)
                {
                    StringWriter sWriter = new StringWriter();
                    JsonWriter writer = new JsonWriter(sWriter);
                    writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                    writer.Indentation = 4;
                    writer.IndentChar = ' ';
                    s.Serialize(writer, jsonObject);
                    CurrentEditor.Editor.Text = sWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                CurrentEditor.Editor.Text = ex.ToString();
            }
        }

        private void lstClipboardHistory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int index = lstClipboardHistory.IndexFromPoint(e.Location);
                {
                    if (index >= 0)
                    {
                        ClipboardHelper.SetText("" + lstClipboardHistory.Items[index]);
                    }
                }
            }
        }

        public string CustomTitle { get; set; }
    }
}
