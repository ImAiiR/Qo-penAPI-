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
using System.Net.Http.Headers;

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
                        var regexSearch2 = Regex.Match(htmlCode, "production:{api\\:{appId:\"(?<appID>.*?)\",appSecret:").Groups;
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
                        Console.WriteLine("app_secret = " + app_secret);

                        try
                        {
                            string testURL = TrackGetFileUrl("197432204", "5", app_id, user_auth_token, app_secret).StreamURL;
                            Console.WriteLine("app_secret test stream url = " + testURL);
                            // If GetStream test works, set app_secret.
                            app_secret = app_secret;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("app_secret test failed");
                            System.Diagnostics.Trace.WriteLine(ex);
                            return null;
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

        public User Login(string app_id, string email, string password, string user_auth_token)
        {
            string login_url = baseUrl + "user/login";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            if (email != null)
            {
                _paramsValue.Add("email", email);
            }
            if (password != null)
            {
                _paramsValue.Add("password", WebUtility.UrlEncode(password));
            }
            if (user_auth_token != null)
            {
                _paramsValue.Add("user_auth_token", user_auth_token);
            }

            string _parameterizedURL = CreateParameterizedQuery(login_url, _paramsValue);

            QoHttpClient.DefaultRequestHeaders.Remove("X-App-Id");
            QoHttpClient.DefaultRequestHeaders.Add("X-App-Id", app_id);
            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Trace.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
                User user = JsonConvert.DeserializeObject<User>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return user;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                System.Diagnostics.Trace.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public User ResetPassword(string app_id, string email)
        {
            // CURRENTLY NOT WORKING
            string reset_url = baseUrl + "user/resetPassword";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            System.Diagnostics.Trace.WriteLine("app_id = " + app_id);
            _paramsValue.Add("username", email);
            System.Diagnostics.Trace.WriteLine("e-mail = " + email);

            string _parameterizedURL = CreateParameterizedQuery(reset_url, _paramsValue);
            System.Diagnostics.Trace.WriteLine("parameterizedURL = " + _parameterizedURL);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(result);
                System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
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
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
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
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return album;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("API response error");
                return null;
            }
        }

        public Artist ArtistGet(string app_id, string album_id)
        {
            string artist_url = baseUrl + "artist/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("artist_id", album_id);
            _paramsValue.Add("extra", "albums%2Calbums_with_last_release");
            _paramsValue.Add("limit", "9999");
            _paramsValue.Add("sort", "release_desc");

            string _parameterizedURL = CreateParameterizedQuery(artist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Artist artist = JsonConvert.DeserializeObject<Artist>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return artist;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Artist ArtistGetWithAuth(string app_id, string album_id, string user_auth_token)
        {
            string artist_url = baseUrl + "artist/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("artist_id", album_id);
            _paramsValue.Add("extra", "albums%2Calbums_with_last_release");
            _paramsValue.Add("limit", "9999");
            _paramsValue.Add("sort", "release_desc");
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(artist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Artist artist = JsonConvert.DeserializeObject<Artist>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return artist;
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

        public Favorites FavoriteGetUserFavorites(string app_id, string user_id, string type, int limit, int offset)
        {
            string favorites_url = baseUrl + "album/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("user_id", user_id);
            _paramsValue.Add("type", type);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());

            string _parameterizedURL = CreateParameterizedQuery(favorites_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Favorites favorites = JsonConvert.DeserializeObject<Favorites>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return favorites;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Favorites FavoriteGetUserFavoritesWithAuth(string app_id, string user_id, string type, int limit, int offset, string user_auth_token)
        {
            string favorites_url = baseUrl + "favorite/getUserFavorites";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("user_id", user_id);
            _paramsValue.Add("type", type);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(favorites_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Favorites favorites = JsonConvert.DeserializeObject<Favorites>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return favorites;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Label LabelGet(string app_id, string label_id, string extra, int limit, int offset)
        {
            string label_url = baseUrl + "label/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("label_id", label_id);
            _paramsValue.Add("extra", "albums");
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());

            string _parameterizedURL = CreateParameterizedQuery(label_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Label label = JsonConvert.DeserializeObject<Label>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return label;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Label LabelGetWithAuth(string app_id, string label_id, string extra, int limit, int offset, string user_auth_token)
        {
            string label_url = baseUrl + "label/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("label_id", label_id);
            _paramsValue.Add("extra", extra);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(label_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Label label = JsonConvert.DeserializeObject<Label>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return label;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Playlist PlaylistGet(string app_id, string playlist_id, string extra, int limit, int offset)
        {
            string playlist_url = baseUrl + "playlist/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("playlist_id", playlist_id);
            _paramsValue.Add("extra", extra);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());

            string _parameterizedURL = CreateParameterizedQuery(playlist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Playlist playlist = JsonConvert.DeserializeObject<Playlist>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return playlist;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public Playlist PlaylistGetWithAuth(string app_id, string playlist_id, string extra, int limit, int offset, string user_auth_token)
        {
            string playlist_url = baseUrl + "playlist/get";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("playlist_id", playlist_id);
            _paramsValue.Add("extra", extra);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(playlist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Playlist playlist = JsonConvert.DeserializeObject<Playlist>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return playlist;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }
        
        public SearchAlbumResult SearchAlbumsWithAuth(string app_id, string searchTerm, int limit, int offset, string user_auth_token)
        {
            string playlist_url = baseUrl + "album/search";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("query", searchTerm);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(playlist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                SearchAlbumResult search = JsonConvert.DeserializeObject<SearchAlbumResult>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return search;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("shit aint work");
                return null;
            }
        }

        public SearchTrackResult SearchTracksWithAuth(string app_id, string searchTerm, int limit, int offset, string user_auth_token)
        {
            string playlist_url = baseUrl + "track/search";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", app_id);
            _paramsValue.Add("query", searchTerm);
            _paramsValue.Add("limit", limit.ToString());
            _paramsValue.Add("offset", offset.ToString());
            _paramsValue.Add("user_auth_token", user_auth_token);

            string _parameterizedURL = CreateParameterizedQuery(playlist_url, _paramsValue);

            var response = QoHttpClient.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                SearchTrackResult search = JsonConvert.DeserializeObject<SearchTrackResult>(result);
                //System.Diagnostics.Trace.WriteLine(result);//           <-- Use to view API response
                return search;
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
