using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QopenAPI;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace QopenAPI
{
    public class Service
    {
        public string app_id { get; set; }
        public string app_secret { get; set; }
        private HttpClient QoHttpClient = new HttpClient();
        private WebClient QoWebClient = new WebClient();

        string baseUrl = "https://www.qobuz.com/api.json/0.2/";

        public AppID GetAppID()
        {
            using (QoWebClient)
            {
                var htmlCodeFind = QoWebClient.DownloadString("https://play.qobuz.com/login");
                try
                {
                    var regexSearch = Regex.Match(htmlCodeFind, "<script src=\"(?<bundleJS>\\/resources\\/\\d+\\.\\d+\\.\\d+-[a-z]\\d{3}\\/bundle\\.js)\"><\\/script>").Groups;
                    string bundleURL = regexSearch[1].Value;
                    var htmlCode = QoWebClient.DownloadString("https://play.qobuz.com" + bundleURL);
                    try
                    {
                        var regexSearch2 = Regex.Match(htmlCode, "\\):\\(n.qobuzapi={app_id:\"(?<appID>.*?)\",app_secret:").Groups;
                        var jsonAppID = "{\"app_id\": \"" + regexSearch2[1].Value + "\"}";
                        AppID app = JsonConvert.DeserializeObject<AppID>(jsonAppID);
                        return app;
                    }
                    catch
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public AppSecret GetAppSecret(string app_id, string user_auth_token)
        {
            using (QoWebClient)
            {
                var htmlCodeFind = QoWebClient.DownloadString("https://play.qobuz.com/login");
                try
                {
                    var regexSearch = Regex.Match(htmlCodeFind, "<script src=\"(?<bundleJS>\\/resources\\/\\d+\\.\\d+\\.\\d+-[a-z]\\d{3}\\/bundle\\.js)\"><\\/script>").Groups;
                    string bundleURL = regexSearch[1].Value;
                    var htmlCode = QoWebClient.DownloadString("https://play.qobuz.com" + bundleURL);
                    try
                    {
                        // Regex for finding needed values (for Berlin timezone)
                        var pattern1 = "name:\"(?<timezone>[A-Za-z\\/]+\\/Berlin)\",info:\"(?<info>[\\w=]+)\",extras:\"(?<extras>[\\w=]+)\"";
                        var pattern2 = "[a-z]\\.initialSeed\\(\"(?<seed>[\\w=]+)\",window\\.utimezone\\.(?<timezone>berlin)\\)";

                        // Find "info" & "extras" (for Berlin timezone)
                        var bundleLog1 = Regex.Match(htmlCode, pattern1);
                        var bundleInfo = bundleLog1.Groups[2].Captures[0].ToString();
                        Console.WriteLine("info = " + bundleInfo);
                        var bundleExtras = bundleLog1.Groups[3].Captures[0].ToString();
                        Console.WriteLine("extras = " + bundleExtras);

                        // Find "seed" (for Berlin timezone)
                        var bundleLog2 = Regex.Match(htmlCode, pattern2);
                        var bundleSeed = bundleLog2.Groups[1].Captures[0].ToString();
                        Console.WriteLine("seed = " + bundleSeed);

                        // Combine all values in correct order, remove 44 characters, then decode from Base64
                        string B64step1 = bundleSeed + bundleInfo + bundleExtras;
                        B64step1 = B64step1.Remove(B64step1.Length - 44, 44);
                        byte[] step2Data = Convert.FromBase64String(B64step1);
                        app_secret = Encoding.UTF8.GetString(step2Data);

                        while (true)
                        {
                            try
                            {
                                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                                string time = unixTimestamp.ToString();
                                string signatureKey = "userLibrarygetAlbumsList" + time + app_secret;
                                string signature = null;

                                using (MD5 md5Hash = MD5.Create())
                                {
                                    signature = GetMd5Hash(md5Hash, signatureKey);
                                }

                                string test_url = baseUrl + "userLibrary/getAlbumsList";
                                Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
                                _paramsValue.Add("app_id", app_id);
                                _paramsValue.Add("user_auth_token", user_auth_token);
                                _paramsValue.Add("request_ts", time);
                                _paramsValue.Add("request_sig", signature);

                                string _parameterizedURL = CreateParameterizedQuery(test_url, _paramsValue);

                                var response = QoHttpClient.GetAsync(_parameterizedURL);
                                if (response.Result.IsSuccessStatusCode)
                                {
                                    app_secret = app_secret;
                                    break;
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine("shit aint work");
                                    return null;
                                }
                            }
                            catch
                            {
                                
                            }
                        }

                        var jsonAppSecret = "{\"app_secret\": \"" + app_secret + "\"}";

                        AppSecret app = JsonConvert.DeserializeObject<AppSecret>(jsonAppSecret);
                        return app;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
                
                
            }
        }

        public User Login(string app_id, string email, string password)
        {
            string login_url = baseUrl + "user/login";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("email", email);
            _paramsValue.Add("password", password);

            string _parameterizedURL = CreateParameterizedQuery(login_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return user;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public User ResetPassword(string app_id, string email)
        {
            string reset_url = baseUrl + "user/resetPassword";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("username", email);

            string _parameterizedURL = CreateParameterizedQuery(reset_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return user;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Album AlbumGet(string app_id, string album_id)
        {
            string album_url = baseUrl + "album/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("album_id", album_id);

            string _parameterizedURL = CreateParameterizedQuery(album_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Album album = JsonConvert.DeserializeObject<Album>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return album;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Album AlbumGetWithAuth(string app_id, string album_id, string user_auth_token)
        {
            string album_url = baseUrl + "album/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("album_id", album_id);
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(album_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Album album = JsonConvert.DeserializeObject<Album>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return album;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Item TrackGet(string app_id, string track_id)
        {
            string track_url = baseUrl + "track/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("track_id", track_id);

            string _parameterizedURL = CreateParameterizedQuery(track_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Item track = JsonConvert.DeserializeObject<Item>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return track;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Item TrackGetWithAuth(string app_id, string track_id, string user_auth_token)
        {
            string track_url = baseUrl + "track/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("track_id", track_id);
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(track_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Item track = JsonConvert.DeserializeObject<Item>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view login API response
                return track;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Stream TrackGetFileUrl(string track_id, string format_id, string app_id, string user_auth_token, string app_secret)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string time = unixTimestamp.ToString();
            string signatureKey = "trackgetFileUrlformat_id" + format_id + "intentstreamtrack_id" + track_id + time + app_secret;
            string signature = null;

            using (MD5 md5Hash = MD5.Create())
            {
                signature = GetMd5Hash(md5Hash, signatureKey);
            }

            string stream_url = baseUrl + "track/getFileUrl";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("request_ts", time);
            _paramsValue.Add("request_sig", signature);
            _paramsValue.Add("track_id", track_id);
            _paramsValue.Add("format_id", format_id);
            _paramsValue.Add("intent", "stream");
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(stream_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Stream stream = JsonConvert.DeserializeObject<Stream>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view stream API response
                return stream;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        private string CreateParameterizedQuery(string url, Dictionary<string, string> parameters)
        {
            string _paramQuery = string.Empty;

            foreach (var item in parameters)
            {
                _paramQuery += item.Key + "=" + item.Value + "&";
            }

            return url + "?" + _paramQuery.TrimEnd(new char[] { '&' });
        }

        static string generateHash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", "");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
