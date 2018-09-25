#region Using Directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion Using Directives


namespace ScintillaNET
{
    public partial class IncrementalSearcher : UserControl
    {
        #region�Fields

        private Scintilla _scintilla;
        private bool _toolItem = false;
        private bool _autoPosition = true;

        /// <summary>
        /// Search event handler
        /// </summary>
        public delegate void SearchEventHandler();
        /// <summary>
        /// Search event
        /// </summary>
        public event SearchEventHandler Search;

        public bool ToolItem
        {
            get { return _toolItem; }
            set { _toolItem = value; }
        }

        #endregion�Fields


        #region�Methods

        private void brnPrevious_Click(object sender, EventArgs e)
        {
            findPrevious();
        }


        private void btnClearHighlights_Click(object sender, EventArgs e)
        {
            if (Scintilla == null) 
                return;
            Scintilla.FindReplace.ClearAllHighlights();
        }


        private void btnHighlightAll_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == string.Empty)
                return;
            if (Scintilla == null)
                return;
            Scintilla.FindReplace.HighlightAll(Scintilla.FindReplace.FindAll(txtFind.Text));
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            findNext();
        }


        public void findNext()
        {
            if (txtFind.Text == string.Empty)
                return;
            
            if (Scintilla == null)
                return;

            if (Search != null) { Search(); }

            txtFind.AutoCompleteCustomSource.Add(txtFind.Text);

            Range r = Scintilla.FindReplace.FindNext(
                txtFind.Text, 
                true, 
                Scintilla.FindReplace.Window.GetSearchFlags());

            if (r != null)
                r.Select();

            MoveFormAwayFromSelection();
        }


        public void findPrevious()
        {
            if (txtFind.Text == string.Empty)
                return;
            
            if (Scintilla == null)
                return;

            if (Search != null) { Search(); }

            txtFind.AutoCompleteCustomSource.Add(txtFind.Text);

            Range r = Scintilla.FindReplace.FindPrevious(
                txtFind.Text,
                true,
                Scintilla.FindReplace.Window.GetSearchFlags());
            
            if (r != null)
                r.Select();

            MoveFormAwayFromSelection();
        }


        public virtual void MoveFormAwayFromSelection()
        {
            if (!Visible || Scintilla == null)
                return;

            if (!AutoPosition)
                return;

            int pos = Scintilla.Caret.Position;
            int x = Scintilla.PointXFromPosition(pos);
            int y = Scintilla.PointYFromPosition(pos);

            Point cursorPoint = new Point(x, y);

            Rectangle r = new Rectangle(Location, Size);
            if (r.Contains(cursorPoint))
            {
                Point newLocation;
                if (cursorPoint.Y < (Screen.PrimaryScreen.Bounds.Height / 2))
                {
                    // Top half of the screen
                    newLocation = new Point(Location.X, cursorPoint.Y + Scintilla.Lines.Current.Height * 2);
                        
                }
                else
                {
                    // Bottom half of the screen
                    newLocation = new Point(Location.X, cursorPoint.Y - Height - (Scintilla.Lines.Current.Height * 2));
                }
                
                Location = newLocation;
            }
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            MoveFormAwayFromSelection();
            txtFind.Focus();
        }


        protected override void OnLeave(EventArgs e)
        {
            base.OnLostFocus(e);
            if(!_toolItem)
            Hide();
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            txtFind.Text = string.Empty;
            txtFind.BackColor = SystemColors.Window;

            MoveFormAwayFromSelection();

            if (Visible)
                txtFind.Focus();
            else if(Scintilla!=null)
                Scintilla.Focus();
        }


        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    findNext();
                    e.Handled = true;
                    break;
                case Keys.Up:
                    findPrevious();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    txtFind.Clear();
                    if(!_toolItem)
                    Hide();
                    break;
            }
        }


        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            txtFind.BackColor = SystemColors.Window;
            if (txtFind.Text == string.Empty)
                return;
            if (Scintilla == null)
                return;

            if (Search != null) { Search(); }

            int pos = Math.Min(Scintilla.Caret.Position, Scintilla.Caret.Anchor);
            Range r = Scintilla.FindReplace.Find(pos, Scintilla.TextLength, txtFind.Text, Scintilla.FindReplace.Window.GetSearchFlags());
            if (r == null)
                r = Scintilla.FindReplace.Find(0, pos, txtFind.Text, Scintilla.FindReplace.Window.GetSearchFlags());

            if (r != null)
                r.Select();
            else
                txtFind.BackColor = Color.LightCoral;

            MoveFormAwayFromSelection();
        }

        #endregion�Methods


        #region�Properties

        /// <summary>
        /// Gets or sets whether the control should automatically move away from the current
        /// selection to prevent obscuring it.
        /// </summary>
        /// <returns>true to automatically move away from the current selection; otherwise, false.</returns>
        public bool AutoPosition
        {
            get
            {
                return _autoPosition;
            }
            set
            {
                _autoPosition = value;
            }
        }


        public Scintilla Scintilla
        {
            get
            {
                return _scintilla;
            }
            set
            {
                _scintilla = value;
            }
        }
        
        public String ContentSearchTerm { get {return txtFind.Text; } set { txtFind.Text = value; } }

        #endregion�Properties


        #region Constructors

        public IncrementalSearcher()
        {
            InitializeComponent();
        }


        public IncrementalSearcher(bool toolItem)
        {
            InitializeComponent();
            _toolItem = toolItem;
            if (toolItem)
                BackColor = Color.Transparent;
        }

        #endregion Constructors
    }
}
