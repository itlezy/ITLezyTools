namespace Itlezy.App.ScratchPad.UI
{
	partial class ScratchPadUserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.ckWrap = new System.Windows.Forms.CheckBox();
            this.txtScratchPad = new ScintillaNET.Scintilla();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScratchPad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFontSize);
            this.panel1.Controls.Add(this.numFontSize);
            this.panel1.Controls.Add(this.ckWrap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 29);
            this.panel1.TabIndex = 2;
            // 
            // lblFontSize
            // 
            this.lblFontSize.Location = new System.Drawing.Point(64, 7);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(55, 19);
            this.lblFontSize.TabIndex = 27;
            this.lblFontSize.Text = "Font Si&ze";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(125, 5);
            this.numFontSize.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(42, 20);
            this.numFontSize.TabIndex = 28;
            this.numFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.NumFontSizeValueChanged);
            // 
            // ckWrap
            // 
            this.ckWrap.Location = new System.Drawing.Point(3, 3);
            this.ckWrap.Name = "ckWrap";
            this.ckWrap.Size = new System.Drawing.Size(104, 24);
            this.ckWrap.TabIndex = 0;
            this.ckWrap.Text = "Wrap";
            this.ckWrap.UseVisualStyleBackColor = true;
            this.ckWrap.CheckedChanged += new System.EventHandler(this.CkWrapCheckedChanged);
            // 
            // txtScratchPad
            // 
            this.txtScratchPad.Caret.CurrentLineBackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtScratchPad.Caret.HighlightCurrentLine = true;
            this.txtScratchPad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScratchPad.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScratchPad.IsBraceMatching = true;
            this.txtScratchPad.LineWrapping.VisualFlags = ScintillaNET.LineWrappingVisualFlags.End;
            this.txtScratchPad.Location = new System.Drawing.Point(0, 29);
            this.txtScratchPad.Margins.Margin0.IsClickable = true;
            this.txtScratchPad.Margins.Margin0.Width = 50;
            this.txtScratchPad.Name = "txtScratchPad";
            this.txtScratchPad.Size = new System.Drawing.Size(697, 598);
            this.txtScratchPad.Styles.BraceBad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtScratchPad.Styles.BraceBad.Size = 12F;
            this.txtScratchPad.Styles.BraceLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtScratchPad.Styles.BraceLight.Size = 12F;
            this.txtScratchPad.Styles.ControlChar.Size = 12F;
            this.txtScratchPad.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtScratchPad.Styles.Default.CharacterSet = ScintillaNET.CharacterSet.Ansi;
            this.txtScratchPad.Styles.Default.FontName = "Consolas";
            this.txtScratchPad.Styles.Default.Size = 12F;
            this.txtScratchPad.Styles.IndentGuide.Size = 12F;
            this.txtScratchPad.Styles.LastPredefined.Size = 12F;
            this.txtScratchPad.Styles.LineNumber.CharacterSet = ScintillaNET.CharacterSet.Ansi;
            this.txtScratchPad.Styles.LineNumber.FontName = "Consolas";
            this.txtScratchPad.Styles.LineNumber.Size = 9.75F;
            this.txtScratchPad.Styles.Max.Size = 12F;
            this.txtScratchPad.TabIndex = 3;
            this.txtScratchPad.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.txtScratchPad_MarginClick);
            // 
            // ScratchPadUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtScratchPad);
            this.Controls.Add(this.panel1);
            this.Name = "ScratchPadUserControl";
            this.Size = new System.Drawing.Size(697, 627);
            this.Load += new System.EventHandler(this.ScratchPadUserControlLoad);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScratchPad)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.NumericUpDown numFontSize;
		private System.Windows.Forms.Label lblFontSize;
		private System.Windows.Forms.CheckBox ckWrap;
        private System.Windows.Forms.Panel panel1;
        private ScintillaNET.Scintilla txtScratchPad;
	}
}
