using System;
using System.Drawing;

namespace PhotoUploader
{
    public class PhotoDetail
    {
        protected String fileName;
        protected String path;
        protected String fqPath;
        protected double latitude;
        protected double longitude;
        protected Bitmap preview;

        public PhotoDetail(String fqpath)
        {
            fqPath = fqpath;
            int lastSlash = fqpath.LastIndexOf('\\');
            path = fqpath.Substring(0, lastSlash);
            fileName = fqpath.Substring(lastSlash + 1);
            latitude = 0;
            longitude = 0;
            preview = null; // We will lazy load these
        }

        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public String Path
        {
            get { return path; }
            set { path = value; }
        }

        public String FQPath
        {
            get { return fqPath; }
            set { fqPath = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public Bitmap Preview
        {
            get
            {
                if (preview == null)
                {
                    preview = new Bitmap(fqPath);
                }

                return preview;
            }

            set { preview = value; }
        }
    }
}
