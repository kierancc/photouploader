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
            this.label1 = new System.Windows.Forms.Label();
            this.cbPhoto = new System.Windows.Forms.CheckBox();
            this.cbGPS = new System.Windows.Forms.CheckBox();
            this.cbLocationString = new System.Windows.Forms.CheckBox();
            this.cbTags = new System.Windows.Forms.CheckBox();
            this.cbDateTaken = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPhotos
            // 
            this.lbPhotos.FormattingEnabled = true;
            this.lbPhotos.ItemHeight = 25;
            this.lbPhotos.Location = new System.Drawing.Point(1112, 12);
            this.lbPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.lbPhotos.Name = "lbPhotos";
            this.lbPhotos.Size = new System.Drawing.Size(452, 704);
            this.lbPhotos.TabIndex = 0;
            this.lbPhotos.SelectedIndexChanged += new System.EventHandler(this.lbPhotos_SelectedIndexChanged);
            // 
            // btnLoadPhotos
            // 
            this.btnLoadPhotos.Location = new System.Drawing.Point(880, 12);
            this.btnLoadPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadPhotos.Name = "btnLoadPhotos";
            this.btnLoadPhotos.Size = new System.Drawing.Size(224, 58);
            this.btnLoadPhotos.TabIndex = 1;
            this.btnLoadPhotos.Text = "Load Photos";
            this.btnLoadPhotos.UseVisualStyleBackColor = true;
            this.btnLoadPhotos.Click += new System.EventHandler(this.btnLoadPhotos_Click);
            // 
            // btnClearPhotos
            // 
            this.btnClearPhotos.Location = new System.Drawing.Point(880, 77);
            this.btnClearPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearPhotos.Name = "btnClearPhotos";
            this.btnClearPhotos.Size = new System.Drawing.Size(224, 58);
            this.btnClearPhotos.TabIndex = 1;
            this.btnClearPhotos.Text = "Clear Photos";
            this.btnClearPhotos.UseVisualStyleBackColor = true;
            this.btnClearPhotos.Click += new System.EventHandler(this.btnClearPhotos_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(12, 12);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(4);
            this.pbPreview.MaximumSize = new System.Drawing.Size(862, 706);
            this.pbPreview.MinimumSize = new System.Drawing.Size(862, 706);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(862, 706);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(880, 662);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(224, 58);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload Photos";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(884, 409);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data To Upload:";
            // 
            // cbPhoto
            // 
            this.cbPhoto.AutoSize = true;
            this.cbPhoto.Checked = true;
            this.cbPhoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPhoto.Location = new System.Drawing.Point(890, 440);
            this.cbPhoto.Margin = new System.Windows.Forms.Padding(6);
            this.cbPhoto.Name = "cbPhoto";
            this.cbPhoto.Size = new System.Drawing.Size(100, 29);
            this.cbPhoto.TabIndex = 4;
            this.cbPhoto.Text = "Photo";
            this.cbPhoto.UseVisualStyleBackColor = true;
            // 
            // cbGPS
            // 
            this.cbGPS.AutoSize = true;
            this.cbGPS.Checked = true;
            this.cbGPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGPS.Location = new System.Drawing.Point(890, 481);
            this.cbGPS.Margin = new System.Windows.Forms.Padding(6);
            this.cbGPS.Name = "cbGPS";
            this.cbGPS.Size = new System.Drawing.Size(210, 29);
            this.cbGPS.TabIndex = 4;
            this.cbGPS.Text = "GPS Coordinates";
            this.cbGPS.UseVisualStyleBackColor = true;
            // 
            // cbLocationString
            // 
            this.cbLocationString.AutoSize = true;
            this.cbLocationString.Checked = true;
            this.cbLocationString.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLocationString.Location = new System.Drawing.Point(890, 522);
            this.cbLocationString.Margin = new System.Windows.Forms.Padding(6);
            this.cbLocationString.Name = "cbLocationString";
            this.cbLocationString.Size = new System.Drawing.Size(188, 29);
            this.cbLocationString.TabIndex = 4;
            this.cbLocationString.Text = "Location String";
            this.cbLocationString.UseVisualStyleBackColor = true;
            // 
            // cbTags
            // 
            this.cbTags.AutoSize = true;
            this.cbTags.Checked = true;
            this.cbTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTags.Location = new System.Drawing.Point(889, 563);
            this.cbTags.Margin = new System.Windows.Forms.Padding(6);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(92, 29);
            this.cbTags.TabIndex = 5;
            this.cbTags.Text = "Tags";
            this.cbTags.UseVisualStyleBackColor = true;
            // 
            // cbDateTaken
            // 
            this.cbDateTaken.AutoSize = true;
            this.cbDateTaken.Checked = true;
            this.cbDateTaken.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDateTaken.Location = new System.Drawing.Point(889, 601);
            this.cbDateTaken.Name = "cbDateTaken";
            this.cbDateTaken.Size = new System.Drawing.Size(155, 29);
            this.cbDateTaken.TabIndex = 6;
            this.cbDateTaken.Text = "Date Taken";
            this.cbDateTaken.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this.cbDateTaken);
            this.Controls.Add(this.cbTags);
            this.Controls.Add(this.cbLocationString);
            this.Controls.Add(this.cbGPS);
            this.Controls.Add(this.cbPhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnClearPhotos);
            this.Controls.Add(this.btnLoadPhotos);
            this.Controls.Add(this.lbPhotos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Photo Uploader";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPhotos;
        private System.Windows.Forms.Button btnLoadPhotos;
        private System.Windows.Forms.Button btnClearPhotos;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbPhoto;
        private System.Windows.Forms.CheckBox cbGPS;
        private System.Windows.Forms.CheckBox cbLocationString;
        private System.Windows.Forms.CheckBox cbTags;
        private System.Windows.Forms.CheckBox cbDateTaken;
    }
}

