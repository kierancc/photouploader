using System;
using System.Windows.Forms;

namespace PhotoUploader
{
    public partial class MainForm : Form
    {      
        public MainForm()
        {
            InitializeComponent();
            lbPhotos.DisplayMember = "FileName";
            lbPhotos.ValueMember = "FQPath";
        }

        private void btnLoadPhotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.RestoreDirectory = true;
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in dialog.FileNames)
                {
                    lbPhotos.Items.Add(new PhotoDetail(filename));
                }
            }
        }

        private void lbPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbPreview.Image = ((PhotoDetail)lbPhotos.SelectedItem).Preview;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {   
            foreach (PhotoDetail pd in lbPhotos.Items)
            {
                // First load the GPS coordinates of each photo
                try
                {
                    GPSHelper.GetGPSCoordinates(pd);
                }
                catch (Exception ex)
                {
                    //TODO: log this somewhere
                    continue;
                }

                // Next upload the photo to the server
                try
                {
                    FTPHelper.UploadFileToServer(FTPHelper.BuildRemoteFQPath(pd.FileName), pd.FQPath);
                }
                catch (Exception ex)
                {
                    //TODO: log this somewhere
                    continue;
                }

                // Next update the DB table with associated photo metadata
                //try
                //{
                    DBHelper.InsertGPSCoordinates(pd);
                //}
                //catch (Exception ex)
                //{
                    //TODO: log this somewhere
                    //TODO: if inserting the photo data to DB fails we should delete the photo
                    //continue;
                //}
            }
        }
    }
}
