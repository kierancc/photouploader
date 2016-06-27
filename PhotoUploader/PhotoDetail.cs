using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoUploader
{
    public class PhotoDetail
    {
        protected String fileName;
        protected String path;
        protected String fqPath;
        protected Bitmap preview;

        public PhotoDetail(String fqpath)
        {
            fqPath = fqpath;
            int lastSlash = fqpath.LastIndexOf('\\');
            path = fqpath.Substring(0, lastSlash);
            fileName = fqpath.Substring(lastSlash + 1);
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

        public Bitmap Preview
        {
            get
            {
                if (preview == null)
                {
                    preview = new Bitmap(path + "\\" + fileName);
                }

                return preview;
            }

            set { preview = value; }
        }
    }
}
