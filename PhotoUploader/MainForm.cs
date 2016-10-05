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
            // Determine which operations to perform and upload
            bool doGPSCoords = cbGPS.Checked || cbLocationString.Checked; // This needs to be done if either of these operations is requsted, since the coordinates are required to determine the location string
            bool uploadGPS = cbGPS.Checked;
            bool doLocationString = cbLocationString.Checked;
            bool uploadLocationString = cbLocationString.Checked;
            bool uploadPhoto = cbPhoto.Checked;
            bool doTags = cbTags.Checked;
            bool uploadTags = cbTags.Checked;

            MetadataHelper mh = new MetadataHelper();
            mh.GetGPSCoordinates = doGPSCoords;
            mh.GetTags = doTags;

            foreach (PhotoDetail pd in lbPhotos.Items)
            {
                Console.Write("Processing file: " + pd.FileName + " ...");

                // Load metadata from the image
                try
                {
                    mh.GetPhotoMetadata(pd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Failed to get photo metadata. ex: " + ex.Message);
                    continue;
                }

                if (doLocationString)
                {
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
                }

                if (uploadPhoto)
                {
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
                }

                // TODO: Refactor the metadata update to allow partial metadata updating
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
