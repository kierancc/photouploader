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
                Console.Write("Processing file: " + pd.FileName + " ...");
                // First load the GPS coordinates of each photo
                try
                {
                    GPSHelper.GetGPSCoordinates(pd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Failed to get GPS coordinates. ex: " + ex.Message);
                    continue;
                }

                // Next, get location by reverse geocoding
                try
                {
                    GPSHelper.GetClosestLocationData(pd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Failed to perform geocoding reverse lookup. ex: " + ex.Message);
                    continue;
                }

                // Next upload the photo to the server
                try
                {
                    FTPHelper.UploadFileToServer(FTPHelper.BuildRemoteFQPath(pd.FileName), pd.FQPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Failed to upload photo to server. ex: " + ex.Message);
                    continue;
                }

                // Next update the DB table with associated photo metadata
                try
                {
                    DBHelper.InsertPhotoMetadata(pd);
                }
                catch (Exception ex)
                {
                    //TODO: if inserting the photo data to DB fails we should delete the photo
                    Console.WriteLine();
                    Console.WriteLine("Failed to insert photo metadata to database. ex: " + ex.Message);
                    continue;
                }

                Console.WriteLine(" Complete");
            }
        }
    }
}
