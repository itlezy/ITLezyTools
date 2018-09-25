namespace Itlezy.App.Console.UI
{
    partial class ConsoleUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sciCommand = new ScintillaNET.Scintilla();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbWorkingDirectory = new System.Windows.Forms.ComboBox();
            this.txtWorkingDirectory = new System.Windows.Forms.TextBox();
            this.ckVerticalSplit = new System.Windows.Forms.CheckBox();
            this.btnKill = new System.Windows.Forms.Button();
            this.outputViewer = new Itlezy.App.OutputViewer.UI.OutputViewerUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.sciCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sciCommand
            // 
            this.sciCommand.AcceptsTab = false;
            this.sciCommand.Caret.CurrentLineBackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.sciCommand.Caret.HighlightCurrentLine = true;
            this.sciCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sciCommand.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sciCommand.IsBraceMatching = true;
            this.sciCommand.Location = new System.Drawing.Point(0, 54);
            this.sciCommand.Margins.Margin0.IsClickable = true;
            this.sciCommand.Margins.Margin0.Width = 60;
            this.sciCommand.Name = "sciCommand";
            this.sciCommand.Size = new System.Drawing.Size(954, 106);
            this.sciCommand.Styles.BraceBad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sciCommand.Styles.BraceBad.Size = 12F;
            this.sciCommand.Styles.BraceLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sciCommand.Styles.BraceLight.Size = 12F;
            this.sciCommand.Styles.ControlChar.Size = 12F;
            this.sciCommand.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.sciCommand.Styles.Default.Size = 12F;
            this.sciCommand.Styles.IndentGuide.Size = 12F;
            this.sciCommand.Styles.LastPredefined.Size = 12F;
            this.sciCommand.Styles.LineNumber.CharacterSet = ScintillaNET.CharacterSet.Ansi;
            this.sciCommand.Styles.LineNumber.FontName = "Consolas";
            this.sciCommand.Styles.LineNumber.Size = 12F;
            this.sciCommand.Styles.Max.Size = 12F;
            this.sciCommand.TabIndex = 20;
            this.sciCommand.Whitespace.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.sciCommand.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciCommand_MarginClick);
            this.sciCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sciCommand_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sciCommand);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 90;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.outputViewer);
            this.splitContainer1.Panel2MinSize = 90;
            this.splitContainer1.Size = new System.Drawing.Size(954, 637);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbWorkingDirectory);
            this.panel1.Controls.Add(this.txtWorkingDirectory);
            this.panel1.Controls.Add(this.ckVerticalSplit);
            this.panel1.Controls.Add(this.btnKill);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 54);
            this.panel1.TabIndex = 2;
            // 
            // cmbWorkingDirectory
            // 
            this.cmbWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkingDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingDirectory.DropDownWidth = 1024;
            this.cmbWorkingDirectory.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkingDirectory.Location = new System.Drawing.Point(3, 28);
            this.cmbWorkingDirectory.MaxDropDownItems = 20;
            this.cmbWorkingDirectory.Name = "cmbWorkingDirectory";
            this.cmbWorkingDirectory.Size = new System.Drawing.Size(948, 23);
            this.cmbWorkingDirectory.TabIndex = 15;
            this.cmbWorkingDirectory.SelectedIndexChanged += new System.EventHandler(this.cmbWorkingDirectory_SelectedIndexChanged);
            this.cmbWorkingDirectory.Resize += new System.EventHandler(this.cmbWorkingDirectory_Resize);
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWorkingDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtWorkingDirectory.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingDirectory.Location = new System.Drawing.Point(175, 4);
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(776, 23);
            this.txtWorkingDirectory.TabIndex = 10;
            this.txtWorkingDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkingDirectory_KeyDown);
            // 
            // ckVerticalSplit
            // 
            this.ckVerticalSplit.AutoSize = true;
            this.ckVerticalSplit.Location = new System.Drawing.Point(85, 7);
            this.ckVerticalSplit.Name = "ckVerticalSplit";
            this.ckVerticalSplit.Size = new System.Drawing.Size(84, 17);
            this.ckVerticalSplit.TabIndex = 5;
            this.ckVerticalSplit.Text = "&Vertical Split";
            this.ckVerticalSplit.UseVisualStyleBackColor = true;
            this.ckVerticalSplit.CheckedChanged += new System.EventHandler(this.ckVerticalSplit_CheckedChanged);
            // 
            // btnKill
            // 
            this.btnKill.Enabled = false;
            this.btnKill.Location = new System.Drawing.Point(3, 3);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 1;
            this.btnKill.Text = "&Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // outputViewer
            // 
            this.outputViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputViewer.ItemId = null;
            this.outputViewer.Location = new System.Drawing.Point(0, 0);
            this.outputViewer.Name = "outputViewer";
            this.outputViewer.Size = new System.Drawing.Size(954, 473);
            this.outputViewer.TabIndex = 30;
            // 
            // ConsoleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConsoleUserControl";
            this.Size = new System.Drawing.Size(954, 637);
            this.Load += new System.EventHandler(this.ConsoleUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sciCommand)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Itlezy.App.OutputViewer.UI.OutputViewerUserControl outputViewer;
        private ScintillaNET.Scintilla sciCommand;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.CheckBox ckVerticalSplit;
        private System.Windows.Forms.TextBox txtWorkingDirectory;
        private System.Windows.Forms.ComboBox cmbWorkingDirectory;
    }
}
