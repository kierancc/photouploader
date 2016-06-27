namespace PhotoUploader
{
    partial class MainForm
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
            this.lbPhotos = new System.Windows.Forms.ListBox();
            this.btnLoadPhotos = new System.Windows.Forms.Button();
            this.btnClearPhotos = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPhotos
            // 
            this.lbPhotos.FormattingEnabled = true;
            this.lbPhotos.ItemHeight = 25;
            this.lbPhotos.Location = new System.Drawing.Point(1111, 12);
            this.lbPhotos.Name = "lbPhotos";
            this.lbPhotos.Size = new System.Drawing.Size(451, 704);
            this.lbPhotos.TabIndex = 0;
            // 
            // btnLoadPhotos
            // 
            this.btnLoadPhotos.Location = new System.Drawing.Point(881, 12);
            this.btnLoadPhotos.Name = "btnLoadPhotos";
            this.btnLoadPhotos.Size = new System.Drawing.Size(224, 58);
            this.btnLoadPhotos.TabIndex = 1;
            this.btnLoadPhotos.Text = "Load Photos";
            this.btnLoadPhotos.UseVisualStyleBackColor = true;
            this.btnLoadPhotos.Click += new System.EventHandler(this.btnLoadPhotos_Click);
            // 
            // btnClearPhotos
            // 
            this.btnClearPhotos.Location = new System.Drawing.Point(881, 76);
            this.btnClearPhotos.Name = "btnClearPhotos";
            this.btnClearPhotos.Size = new System.Drawing.Size(224, 58);
            this.btnClearPhotos.TabIndex = 1;
            this.btnClearPhotos.Text = "Clear Photos";
            this.btnClearPhotos.UseVisualStyleBackColor = true;
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(13, 12);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(862, 705);
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.btnClearPhotos);
            this.Controls.Add(this.btnLoadPhotos);
            this.Controls.Add(this.lbPhotos);
            this.Name = "MainForm";
            this.Text = "Photo Uploader";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPhotos;
        private System.Windows.Forms.Button btnLoadPhotos;
        private System.Windows.Forms.Button btnClearPhotos;
        private System.Windows.Forms.PictureBox pbPreview;
    }
}

