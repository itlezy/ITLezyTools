using System;
using System.Drawing;
using System.Windows.Forms;

namespace Itlezy.App.OutputViewer.UI
{
	/// <summary>
	/// Description of OutputViewerDetachedForm.
	/// </summary>
	public partial class OutputViewerDetachedForm : Form
	{
		public OutputViewerDetachedForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CkTaskbarCheckedChanged(object sender, EventArgs e)
		{
			this.ShowInTaskbar = ckTaskbar.Checked;
		}
		
		void CkOnTopCheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = ckOnTop.Checked;
		}
    }
}
