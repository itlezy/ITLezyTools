namespace ScintillaNET
{
    partial class IncrementalSearcher
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
            this.components = new System.ComponentModel.Container();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.brnPrevious = new System.Windows.Forms.Button();
            this.btnHighlightAll = new System.Windows.Forms.Button();
            this.btnClearHighlights = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.Location = new System.Drawing.Point(1, 7);
            this.lblFind.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(27, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "&Find";
            this.lblFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFind.Location = new System.Drawing.Point(33, 2);
            this.txtFind.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(545, 22);
            this.txtFind.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtFind, "CTRL+F (while focus on text) Open find dialog");
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Image = global::ScintillaNET.Properties.Resources.GoToNextMessage;
            this.btnNext.Location = new System.Drawing.Point(581, 2);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnNext, "Find Next (F3)");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // brnPrevious
            // 
            this.brnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brnPrevious.FlatAppearance.BorderSize = 0;
            this.brnPrevious.Image = global::ScintillaNET.Properties.Resources.GoToPreviousMessage;
            this.brnPrevious.Location = new System.Drawing.Point(610, 2);
            this.brnPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.brnPrevious.Name = "brnPrevious";
            this.brnPrevious.Size = new System.Drawing.Size(23, 23);
            this.brnPrevious.TabIndex = 3;
            this.toolTip.SetToolTip(this.brnPrevious, "Find Previous (SHIFT+F3)");
            this.brnPrevious.UseVisualStyleBackColor = true;
            this.brnPrevious.Click += new System.EventHandler(this.brnPrevious_Click);
            // 
            // btnHighlightAll
            // 
            this.btnHighlightAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHighlightAll.FlatAppearance.BorderSize = 0;
            this.btnHighlightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlightAll.ForeColor = System.Drawing.Color.SkyBlue;
            this.btnHighlightAll.Image = global::ScintillaNET.Properties.Resources.LineColorHS;
            this.btnHighlightAll.Location = new System.Drawing.Point(639, 2);
            this.btnHighlightAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnHighlightAll.Name = "btnHighlightAll";
            this.btnHighlightAll.Size = new System.Drawing.Size(23, 23);
            this.btnHighlightAll.TabIndex = 4;
            this.btnHighlightAll.Text = "&h";
            this.toolTip.SetToolTip(this.btnHighlightAll, "Highlight All Matches (ALT+H)");
            this.btnHighlightAll.UseVisualStyleBackColor = true;
            this.btnHighlightAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // btnClearHighlights
            // 
            this.btnClearHighlights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHighlights.FlatAppearance.BorderSize = 0;
            this.btnClearHighlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearHighlights.Image = global::ScintillaNET.Properties.Resources.DeleteHS;
            this.btnClearHighlights.Location = new System.Drawing.Point(668, 2);
            this.btnClearHighlights.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearHighlights.Name = "btnClearHighlights";
            this.btnClearHighlights.Size = new System.Drawing.Size(23, 23);
            this.btnClearHighlights.TabIndex = 5;
            this.btnClearHighlights.Text = "&j";
            this.toolTip.SetToolTip(this.btnClearHighlights, "Clear Highlights (ALT+J)");
            this.btnClearHighlights.UseVisualStyleBackColor = true;
            this.btnClearHighlights.Click += new System.EventHandler(this.btnClearHighlights_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 2000;
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 2000;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 1000;
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            // 
            // IncrementalSearcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnClearHighlights);
            this.Controls.Add(this.btnHighlightAll);
            this.Controls.Add(this.brnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblFind);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "IncrementalSearcher";
            this.Size = new System.Drawing.Size(693, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button brnPrevious;
        private System.Windows.Forms.Button btnHighlightAll;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnClearHighlights;
    }
}
