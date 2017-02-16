using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace PhotoUploader
{
    public class MetadataHelper
    {
        protected bool getGPSCoordinates;
        public bool GetGPSCoordinates
        {
            get { return getGPSCoordinates; }
            set { getGPSCoordinates = value; }
        }

        protected bool getTags;
        public bool GetTags
        {
            get { return getTags; }
            set { getTags = value; }
        }

        protected bool getDateTaken;
        public bool GetDateTaken
        {
            get { return getDateTaken; }
            set { getDateTaken = value; }
        }

        public void GetPhotoMetadata(PhotoDetail photo)
        {
            if (getGPSCoordinates)
            {
                GetGPSCoordinatesFromPhoto(photo);
            }

            if (getTags || getDateTaken)
            {
                GetBitmapMetadata(photo);
            }
        }

        protected void GetBitmapMetadata(PhotoDetail photo)
        {
            using (FileStream fs = new FileStream(photo.FQPath, FileMode.Open))
            {
                JpegBitmapDecoder decoder = new JpegBitmapDecoder(fs, BitmapCreateOptions.None, BitmapCacheOption.None);
                BitmapMetadata metadata = decoder.Frames[0].Metadata as BitmapMetadata;

                string keywords = "";
                string dateTaken = "";

                if (null != metadata)
                {
                    keywords = metadata.Keywords.Aggregate((old, val) => old + ";" + val);
                    dateTaken = metadata.DateTaken;
                }

                if (getTags)
                {
                    photo.Tags = keywords;
                }

                if (getDateTaken && (!string.IsNullOrEmpty(dateTaken)))
                {
                    photo.DateTaken = DateTime.Parse(dateTaken);
                }

                fs.Close();
            }
        }

        protected void GetGPSCoordinatesFromPhoto(PhotoDetail photo)
        {
            Double latitude = Double.MinValue;
            Double longitude = Double.MinValue;
            int latitudeDirection = int.MinValue;
            int longitudeDirection = int.MinValue;
            bool allInfoFound = false;

            // Note, we make a new Bitmap here instead of using the .Preview member of the PhotoDetail object to save memory
            // That member will only be popluated if the user actually wants to view the preview
            using (Image img = new Bitmap(photo.FQPath))
            {
                PropertyItem[] propertyItems = img.PropertyItems;

                foreach (PropertyItem item in propertyItems)
                {
                    // Determine Latitute (0x0002) or Longitude (0x0004)
                    if (item.Id == 0x0002 || item.Id == 0x0004)
                    {
                        Double[] coordiantes = new Double[3];

                        for (int j = 0; j < 3; j++)
                        {
                            byte[] num = new byte[4];
                            byte[] den = new byte[4];

                            Array.Copy(item.Value, 0 + 8 * j, num, 0, 4);
                            Array.Copy(item.Value, 4 + 8 * j, den, 0, 4);

                            Int32 numerator = BitConverter.ToInt32(num, 0);
                            Int32 denominator = BitConverter.ToInt32(den, 0);

                            coordiantes[j] = (double)numerator / (double)denominator;
                        }

                        // Now convert the coordinates into degrees (with decimals) only
                        Double degrees = coordiantes[0] + coordiantes[1] / 60.0 + coordiantes[2] / 3600.0;

                        if (item.Id == 0x0002)
                        {
                            latitude = degrees;
                        }
                        else
                        {
                            longitude = degrees;
                        }
                    }
                    // Determine direction for Latitude (0x0001) or Longitude (0x0003)
                    else if (item.Id == 0x0001 || item.Id == 0x0003)
                    {
                        String value = Encoding.ASCII.GetString(item.Value).Trim('\0');

                        if (String.Compare(value, "N", true) == 0)
                        {
                            latitudeDirection = 1;
                        }
                        else if (String.Compare(value, "S", true) == 0)
                        {
                            latitudeDirection = -1;
                        }
                        else if (String.Compare(value, "E", true) == 0)
                        {
                            longitudeDirection = 1;
                        }
                        else if (String.Compare(value, "W", true) == 0)
                        {
                            longitudeDirection = -1;
                        }
                        else
                        {
                            throw new Exception("Invalid Latitude or Longitude reference: \"" + value + "\"");
                        }
                    }

                    // Break early if all values are found
                    if (latitude != Double.MinValue && longitude != Double.MinValue && latitudeDirection != int.MinValue && longitudeDirection != int.MinValue)
                    {
                        allInfoFound = true;
                        break;
                    }
                }

                // Only proceed if all required info was found
                if (allInfoFound)
                {
                    // Combine degrees and direction
                    latitude *= latitudeDirection;
                    longitude *= longitudeDirection;

                    // Save the latitude and longitude
                    photo.Latitude = latitude;
                    photo.Longitude = longitude;
                }
                else
                {
                    throw new Exception("Failed to determine GPS coordinates");
                }
            }
        }
    }
}
