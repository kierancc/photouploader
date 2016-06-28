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
            this.btnUpload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPhotos
            // 
            this.lbPhotos.FormattingEnabled = true;
            this.lbPhotos.Location = new System.Drawing.Point(556, 6);
            this.lbPhotos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbPhotos.Name = "lbPhotos";
            this.lbPhotos.Size = new System.Drawing.Size(228, 368);
            this.lbPhotos.TabIndex = 0;
            this.lbPhotos.SelectedIndexChanged += new System.EventHandler(this.lbPhotos_SelectedIndexChanged);
            // 
            // btnLoadPhotos
            // 
            this.btnLoadPhotos.Location = new System.Drawing.Point(440, 6);
            this.btnLoadPhotos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadPhotos.Name = "btnLoadPhotos";
            this.btnLoadPhotos.Size = new System.Drawing.Size(112, 30);
            this.btnLoadPhotos.TabIndex = 1;
            this.btnLoadPhotos.Text = "Load Photos";
            this.btnLoadPhotos.UseVisualStyleBackColor = true;
            this.btnLoadPhotos.Click += new System.EventHandler(this.btnLoadPhotos_Click);
            // 
            // btnClearPhotos
            // 
            this.btnClearPhotos.Location = new System.Drawing.Point(440, 40);
            this.btnClearPhotos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClearPhotos.Name = "btnClearPhotos";
            this.btnClearPhotos.Size = new System.Drawing.Size(112, 30);
            this.btnClearPhotos.TabIndex = 1;
            this.btnClearPhotos.Text = "Clear Photos";
            this.btnClearPhotos.UseVisualStyleBackColor = true;
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(6, 6);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(431, 367);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(440, 344);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(112, 30);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload Photos";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 379);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnClearPhotos);
            this.Controls.Add(this.btnLoadPhotos);
            this.Controls.Add(this.lbPhotos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnUpload;
    }
}

