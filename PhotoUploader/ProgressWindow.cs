using System;
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
    public partial class ProgressWindow : Form
    {
        protected int current;
        public ProgressWindow(int numFiles)
        {
            InitializeComponent();
            progbar.Visible = true;
            progbar.Minimum = 1;
            progbar.Maximum = numFiles;
            progbar.Value = 1;
            progbar.Step = 1;
            current = 0;
        }

        public void PerformStep()
        {
            progbar.PerformStep();
            current++;

            lbFilesCompleted.Text = String.Format("{0} / {1}", current, progbar.Maximum);
            lbPercentCompleted.Text = String.Format("{0}%", (current * 100 / progbar.Maximum));
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
    }
}
