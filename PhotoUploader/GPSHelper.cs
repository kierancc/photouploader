using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhotoUploader
{
    public class GPSHelper
    {
        public static void GetGPSCoordinates(PhotoDetail photo)
        {
            Double latitude = Double.MinValue;
            Double longitude = Double.MinValue;
            int latitudeDirection = int.MinValue;
            int longitudeDirection = int.MinValue;
            bool allInfoFound = false;

            using (Image img = photo.Preview)
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

        public static void GetClosestLocationData(PhotoDetail photo)
        {
            // Build URL to request reverse geocoding lookup from google maps
            String latlng = String.Format("{0},{1}", photo.Latitude, photo.Longitude);
            String requestURL = String.Format(ConfigurationManager.AppSettings["GPSReverseGeocodingLookupURL"], latlng);

            // Make the request
            using (HttpClient request = new HttpClient())
            {
                using (var response = request.GetAsync(requestURL).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseContent = response.Content)
                        {
                            String responseString = responseContent.ReadAsStringAsync().Result;
                            Location resultLocation = JsonConvert.DeserializeObject<Location>(responseString);
                            photo.Location = resultLocation.GetLocation();
                        }
                    }
                    else // Reverse geocoding request failed
                    {
                        throw new Exception("Reverse geocoding request failed with status code: " + response.StatusCode);
                    }
                }
            }
        }
    }

    public class Location
    {
        public string status { get; set; }
        public AddressInformation[] results { get; set; }

        public String GetLocation()
        {
            if (status.ToUpper() != "OK")
            {
                return "";
            }
            else
            {
                string location = "";

                // If there is only one address result, we will use it no matter what type it is
                // Otherwise prefer to use the "locality" type
                // If locality is not found, use the top result
                foreach (AddressInformation info in results)
                {
                    foreach (string type in info.types)
                    {
                        if (type.ToUpper() == "LOCALITY")
                        {
                            location = info.formatted_address;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(location))
                    {
                        break;
                    }
                }

                if (string.IsNullOrEmpty(location))
                {
                    location = results[0].formatted_address;
                }

                return location;
            }
        }
    }

    public class AddressInformation
    {
        public string[] types { get; set; }
        public string formatted_address { get; set; }
        public AddressComponent[] address_components { get; set; }
        public string place_id { get; set; }


    }

    public class AddressComponent
    {
        public string[] types { get; set; }
        public string long_name { get; set; }
        public string short_name { get; set; }
    }
}
