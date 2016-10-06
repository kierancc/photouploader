using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PhotoUploader
{
    public class DBHelper
    {
        protected static String connectionString = "";

        protected static String ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(connectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("server=");
                    sb.Append(ConfigurationManager.AppSettings["DBServer"]);
                    sb.Append(";uid=");
                    sb.Append(ConfigurationManager.AppSettings["DBUser"]);
                    sb.Append(";pwd=");
                    sb.Append(ConfigurationManager.AppSettings["DBPassword"]);
                    sb.Append(";database=");
                    sb.Append(ConfigurationManager.AppSettings["DBDatabase"]);
                    sb.Append(";");

                    connectionString = sb.ToString();
                }

                return connectionString;
            }
        }

        public static void InsertPhotoMetadata(PhotoDetail photo)
        {
            String insertQuery = "INSERT INTO `photos`(`filename`, `latitude`, `longitude`, `locationstring`, `tagsstring`) VALUES (@filename,@latitude,@longitude,@locationstring,@tagsstring)";
            MySqlParameter[] insertParams = new MySqlParameter[5];
            insertParams[0] = new MySqlParameter("@filename", photo.FileName);
            insertParams[1] = new MySqlParameter("@latitude", photo.Latitude);
            insertParams[2] = new MySqlParameter("@longitude", photo.Longitude);
            insertParams[3] = new MySqlParameter("@locationstring", photo.Location);
            insertParams[4] = new MySqlParameter("@tagsstring", photo.Tags);

            int rc = MySqlHelper.ExecuteNonQuery(ConnectionString, insertQuery, insertParams);
        }
    }
}
