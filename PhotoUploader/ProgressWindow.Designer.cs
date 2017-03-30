namespace PhotoUploader
{
    partial class ProgressWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progbar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFilesCompleted = new System.Windows.Forms.Label();
            this.lbPercentCompleted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progbar
            // 
            this.progbar.Location = new System.Drawing.Point(12, 41);
            this.progbar.Name = "progbar";
            this.progbar.Size = new System.Drawing.Size(597, 84);
            this.progbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files Completed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Percent Completed:";
            // 
            // lbFilesCompleted
            // 
            this.lbFilesCompleted.AutoSize = true;
            this.lbFilesCompleted.Location = new System.Drawing.Point(538, 138);
            this.lbFilesCompleted.Name = "lbFilesCompleted";
            this.lbFilesCompleted.Size = new System.Drawing.Size(0, 25);
            this.lbFilesCompleted.TabIndex = 3;
            // 
            // lbPercentCompleted
            // 
            this.lbPercentCompleted.AutoSize = true;
            this.lbPercentCompleted.Location = new System.Drawing.Point(538, 176);
            this.lbPercentCompleted.Name = "lbPercentCompleted";
            this.lbPercentCompleted.Size = new System.Drawing.Size(0, 25);
            this.lbPercentCompleted.TabIndex = 4;
            // 
            // ProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 273);
            this.ControlBox = false;
            this.Controls.Add(this.lbPercentCompleted);
            this.Controls.Add(this.lbFilesCompleted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ProgressWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProgressWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProgressWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFilesCompleted;
        private System.Windows.Forms.Label lbPercentCompleted;
    }
}