using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
