using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;
using Itlezy.Common.Platform;

namespace Itlezy.App.ScratchPad.UI
{
	/// <summary>
	/// Description of ScratchPadUserControl.
	/// </summary>
	public partial class ScratchPadUserControl : UserControl
	{
		public ScratchPadUserControl()
		{
			InitializeComponent();
		}
		
		public ScintillaNET.Scintilla Editor
		{
			get
			{
				return txtScratchPad;
			}
		}
		
		void CkWrapCheckedChanged(object sender, EventArgs e)
		{
			Editor.LineWrapping.Mode = ckWrap.Checked ? LineWrappingMode.Word : LineWrappingMode.None;
		}
		
		void NumFontSizeValueChanged(object sender, EventArgs e)
		{
			Editor.Font = new Font(Editor.Font.Name, decimal.ToInt32(numFontSize.Value));
            Editor.Styles.LineNumber.Font = new Font(Editor.Font.Name, decimal.ToInt32(numFontSize.Value));
		}
		
		void ScratchPadUserControlLoad(object sender, EventArgs e)
		{
			Editor.Font = new Font(Editor.Font.Name, decimal.ToInt32(numFontSize.Value));
            Editor.Styles.LineNumber.Font = new Font(Editor.Font.Name, decimal.ToInt32(numFontSize.Value));
		}

        private void txtScratchPad_MarginClick(object sender, MarginClickEventArgs e)
        {
            ClipboardHelper.SetText(e.Line.Text);
        }
	}
}
