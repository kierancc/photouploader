using System;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhotoUploader
{
    public class GPSHelper
    {
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

                            if (resultLocation.status != "OK" && resultLocation.status != "ZERO_RESULTS")
                            {
                                throw new Exception("Reverse geocoding request rejected with status: " + resultLocation.status);
                            }

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
