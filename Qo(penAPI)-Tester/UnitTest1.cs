using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QopenAPI;

namespace Qo_penAPI__Tester
{
    [TestClass]
    public class UnitTest1
    {
        readonly string _testUsername = "putemailfortestinghere";
        readonly string _testPassword = "putpasswordfortestinghere";

        #region Test Getting App ID
        [TestMethod]
        public void App_ID()
        {
            Service service = new Service();
            AppID appid;
            try
            {
                appid = service.GetAppID();
                Console.WriteLine("app_id = " + appid.App_ID);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Test Getting App Secret
        [TestMethod]
        public void App_Secret()
        {
            Service service = new Service();
            User user;
            AppID appid;
            AppSecret appsecret;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                appsecret = service.GetAppSecret(appid.App_ID, user.UserAuthToken);
                Console.WriteLine("");
                Console.WriteLine("app_secret = " + appsecret.App_Secret);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Test Logging In
        [TestMethod]
        public void Login()
        {
            Service service = new Service();
            User user;
            AppID appid;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
            System.Diagnostics.Trace.WriteLine(user.UserAuthToken);
            System.Diagnostics.Trace.WriteLine(user.UserInfo.DisplayName);
        }
        #endregion

        #region Test Resetting Password
        [TestMethod]
        public void ResetPassword()
        {
            Service service = new Service();
            User user;
            AppID appid;
            try
            {
                appid = service.GetAppID();
                user = service.ResetPassword(appid.App_ID, "putemailfortestinghere");
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.Status));
            System.Diagnostics.Trace.WriteLine(user.Status);
        }
        #endregion

        #region Test Getting Artist Info
        [TestMethod]
        public void ArtistGet()
        {
            Service service = new Service();
            AppID appid;
            Artist artist;
            try
            {
                appid = service.GetAppID();
                artist = service.ArtistGet(appid.App_ID, "3131928", "albums%2Calbums_with_last_release");
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(artist != null && !string.IsNullOrEmpty(artist.Id.ToString()));
            Console.WriteLine("Artist ID = " + artist.Id);

        }
        #endregion

        #region Test Getting Album Search Results (w/ Auth)
        [TestMethod]
        public void SearchAlbumWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            SearchAlbumResult search;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                search = service.SearchAlbumsWithAuth(appid.App_ID, user.UserAuthToken, "twenty one pilots", 50, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(search != null && !string.IsNullOrEmpty(search.Query));
            foreach (var item in search.Albums.Items)
            {
                Console.WriteLine("Release Name: {0}", item.Title);
                Console.WriteLine("Release ID: {0}", item.Id);
            }

        }
        #endregion

        #region Test Getting Track Search Results (w/ Auth)
        [TestMethod]
        public void SearchTrackWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            SearchTrackResult search;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                search = service.SearchTracksWithAuth(appid.App_ID, user.UserAuthToken, "twenty one pilots", 50, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(search != null && !string.IsNullOrEmpty(search.Query));
            foreach (var item in search.Tracks.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("Track ID: {0}", item.Id);
            }

        }
        #endregion

        #region Test Getting Artist Info (w/ Auth)
        [TestMethod]
        public void ArtistGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Artist artist;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                artist = service.ArtistGetWithAuth(appid.App_ID, "45874", user.UserAuthToken, "albums%2Calbums_with_last_release");
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(artist != null && !string.IsNullOrEmpty(artist.Id.ToString()));
            Console.WriteLine("Artist ID = " + artist.Id);

            foreach (var item in artist.Albums.Items)
            {
                Console.WriteLine("Album Name: {0}", item.Title);
                Console.WriteLine("Album ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Album Info
        [TestMethod]
        public void AlbumGet()
        {
            Service service = new Service();
            AppID appid;
            Album album;
            try
            {
                appid = service.GetAppID();
                album = service.AlbumGet(appid.App_ID, "epi0dnl1yec1a");
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(album != null && !string.IsNullOrEmpty(album.Id));
            Console.WriteLine("Album ID = " + album.Id);
            Console.WriteLine("UPC = " + album.UPC);
            Console.WriteLine("Genre = " + album.Genre.Name);
            Console.WriteLine("Total Tracks = " + album.TracksCount);
            Console.WriteLine("Total Duration = " + album.Duration);
            Console.WriteLine("Release Date = " + album.ReleasedAt);
            Console.WriteLine("Version = " + album.Version);
            Console.WriteLine("Album Title = " + album.Title);
            Console.WriteLine("Cover Art = " + album.Image.Large);
            Console.WriteLine("Disc Total = " + album.MediaCount);
            Console.WriteLine("Label = " + album.Label.Name);
            Console.WriteLine("Qobuz ID = " + album.QobuzId);
            Console.WriteLine("Popularity = " + album.Popularity);
            Console.WriteLine("Purchasable = " + album.Purchasable);
            Console.WriteLine("Purchasable At = " + album.PurchasableAt);
            Console.WriteLine("Streamable = " + album.Streamable);
            Console.WriteLine("Streamable At = " + album.StreamableAt);
            Console.WriteLine("Previewable = " + album.Previewable);
            Console.WriteLine("Sampleable = " + album.Sampleable);
            Console.WriteLine("Downloadable = " + album.Downloadable);
            Console.WriteLine("Displayable = " + album.Displayable);
            Console.WriteLine("Maximum Sampling Rate = " + album.MaximumSamplingRate);
            Console.WriteLine("Maximum Bit Depth = " + album.MaximumBitDepth);

            if (album.Artists.Count > 1)
            {
                var mainArtists = album.Artists.Where(a => a.Roles.Contains("main-artist")).ToList();
                string allButLast = string.Join(", ", mainArtists.Take(album.Artists.Count - 1).Select(a => a.Name));
                string lastArtist = mainArtists.Last().Name;
                Console.WriteLine("Artist = " + allButLast + " & " + lastArtist);
            }
            else
            {
                Console.WriteLine("Artist = " + album.Artist.Name);
            }

            foreach (var item in album.Tracks.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("PRIME ELEMENT: {0}", item.Id);
            }

        }
        #endregion

        #region Test Getting Album Info (w/ auth)
        [TestMethod]
        public void AlbumGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Album album;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                album = service.AlbumGetWithAuth(appid.App_ID, "epi0dnl1yec1a", user.UserAuthToken);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(album != null && !string.IsNullOrEmpty(album.Id));
            Console.WriteLine("Album ID = " + album.Id);
            Console.WriteLine("UPC = " + album.UPC);
            Console.WriteLine("Genre = " + album.Genre.Name);
            Console.WriteLine("Total Tracks = " + album.TracksCount);
            Console.WriteLine("Total Duration = " + album.Duration);
            Console.WriteLine("Release Date = " + album.ReleasedAt);
            Console.WriteLine("Version = " + album.Version);
            Console.WriteLine("Album Title = " + album.Title);
            Console.WriteLine("Cover Art = " + album.Image.Large);
            Console.WriteLine("Disc Total = " + album.MediaCount);
            Console.WriteLine("Label = " + album.Label.Name);
            Console.WriteLine("Qobuz ID = " + album.QobuzId);
            Console.WriteLine("Popularity = " + album.Popularity);
            Console.WriteLine("Purchasable = " + album.Purchasable);
            Console.WriteLine("Streamable = " + album.Streamable);
            Console.WriteLine("Purchaseable At = " + album.PurchasableAt);
            Console.WriteLine("Streamable At = " + album.StreamableAt);
            Console.WriteLine("Previewable = " + album.Previewable);
            Console.WriteLine("Sampleable = " + album.Sampleable);
            Console.WriteLine("Downloadable = " + album.Downloadable);
            Console.WriteLine("Displayable = " + album.Displayable);
            Console.WriteLine("Maximum Sampling Rate = " + album.MaximumSamplingRate);
            Console.WriteLine("Maximum Bit Depth = " + album.MaximumBitDepth);

            if (album.Artists.Count > 1)
            {
                var mainArtists = album.Artists.Where(a => a.Roles.Contains("main-artist")).ToList();
                string allButLast = string.Join(", ", mainArtists.Take(album.Artists.Count - 1).Select(a => a.Name));
                string lastArtist = mainArtists.Last().Name;
                Console.WriteLine("Artist = " + allButLast + " & " + lastArtist);
            }
            else
            {
                Console.WriteLine("Artist = " + album.Artist.Name);
            }

            foreach (var item in album.Tracks.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("PRIME ELEMENT: {0}", item.Id);
            }

        }
        #endregion

        #region Test Getting Track Info
        [TestMethod]
        public void TrackGet()
        {
            Service service = new Service();
            AppID appid;
            Item track;
            try
            {
                appid = service.GetAppID();
                track = service.TrackGet(appid.App_ID, "125486173");
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(track != null && !string.IsNullOrEmpty(track.Id.ToString()));
            System.Diagnostics.Trace.WriteLine("Track ID = " + track.Id);
            System.Diagnostics.Trace.WriteLine("Performer = " + track.Performer.Name);
            System.Diagnostics.Trace.WriteLine("Performers = " + track.Performers);
            System.Diagnostics.Trace.WriteLine("Composer = " + track.Composer.Name);
            System.Diagnostics.Trace.WriteLine("Explicit = " + track.ParentalWarning);
            System.Diagnostics.Trace.WriteLine("Track Gain = " + track.AudioInfo.ReplayGainTrackGain);
            System.Diagnostics.Trace.WriteLine("Album = " + track.Album.Title);
            System.Diagnostics.Trace.WriteLine("Duration = " + track.Duration);
            System.Diagnostics.Trace.WriteLine("Title = " + track.Title);
            System.Diagnostics.Trace.WriteLine("Copyright = " + track.Copyright);
            System.Diagnostics.Trace.WriteLine("Disc Number = " + track.MediaNumber);
            System.Diagnostics.Trace.WriteLine("Track Number = " + track.TrackNumber);
            System.Diagnostics.Trace.WriteLine("Version = " + track.Version);
            System.Diagnostics.Trace.WriteLine("Purchasable = " + track.Purchasable);
            System.Diagnostics.Trace.WriteLine("Purchasable At = " + track.PurchasableAt);
            System.Diagnostics.Trace.WriteLine("Streamable = " + track.Streamable);
            System.Diagnostics.Trace.WriteLine("Streamable At = " + track.StreamableAt);
            System.Diagnostics.Trace.WriteLine("Previewable = " + track.Previewable);
            System.Diagnostics.Trace.WriteLine("Sampleable = " + track.Sampleable);
            System.Diagnostics.Trace.WriteLine("Downloadable = " + track.Downloadable);
            System.Diagnostics.Trace.WriteLine("Displayable = " + track.Displayable);
            System.Diagnostics.Trace.WriteLine("Maximum Sampling Rate = " + track.MaximumSamplingRate);
            System.Diagnostics.Trace.WriteLine("Maximum Bit Depth = " + track.MaximumBitDepth);
            System.Diagnostics.Trace.WriteLine("Maximum Channel Count = " + track.MaximumChannelCount);
            System.Diagnostics.Trace.WriteLine("Hi-Res = " + track.Hires);
            System.Diagnostics.Trace.WriteLine("Position = " + track.Position);
            System.Diagnostics.Trace.WriteLine("Created At = " + track.CreatedAt);
            System.Diagnostics.Trace.WriteLine("Playlist Track Id = " + track.PlaylistTrackId);
        }
        #endregion

        #region Test Getting Track Info (w/ auth)
        [TestMethod]
        public void TrackGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Item track;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                track = service.TrackGetWithAuth(appid.App_ID, "2193659", user.UserAuthToken);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(track != null && !string.IsNullOrEmpty(track.Id.ToString()));
            System.Diagnostics.Trace.WriteLine("Track ID = " + track.Id);
            System.Diagnostics.Trace.WriteLine("Performer = " + track.Performer.Name);
            System.Diagnostics.Trace.WriteLine("Performers = " + track.Performers);
            System.Diagnostics.Trace.WriteLine("Explicit = " + track.ParentalWarning);
            System.Diagnostics.Trace.WriteLine("Track Gain = " + track.AudioInfo.ReplayGainTrackGain);
            System.Diagnostics.Trace.WriteLine("Album = " + track.Album.Title);
            System.Diagnostics.Trace.WriteLine("Duration = " + track.Duration);
            System.Diagnostics.Trace.WriteLine("Title = " + track.Title);
            System.Diagnostics.Trace.WriteLine("Copyright = " + track.Copyright);
            System.Diagnostics.Trace.WriteLine("Disc Number = " + track.MediaNumber);
            System.Diagnostics.Trace.WriteLine("Track Number = " + track.TrackNumber);
            System.Diagnostics.Trace.WriteLine("Version = " + track.Version);
            System.Diagnostics.Trace.WriteLine("Purchasable = " + track.Purchasable);
            System.Diagnostics.Trace.WriteLine("Purchasable At = " + track.PurchasableAt);
            System.Diagnostics.Trace.WriteLine("Streamable = " + track.Streamable);
            System.Diagnostics.Trace.WriteLine("Streamable At = " + track.StreamableAt);
            System.Diagnostics.Trace.WriteLine("Previewable = " + track.Previewable);
            System.Diagnostics.Trace.WriteLine("Sampleable = " + track.Sampleable);
            System.Diagnostics.Trace.WriteLine("Downloadable = " + track.Downloadable);
            System.Diagnostics.Trace.WriteLine("Displayable = " + track.Displayable);
            System.Diagnostics.Trace.WriteLine("Maximum Sampling Rate = " + track.MaximumSamplingRate);
            System.Diagnostics.Trace.WriteLine("Maximum Bit Depth = " + track.MaximumBitDepth);
            System.Diagnostics.Trace.WriteLine("Maximum Channel Count = " + track.MaximumChannelCount);
            System.Diagnostics.Trace.WriteLine("Hi-Res = " + track.Hires);
            System.Diagnostics.Trace.WriteLine("Position = " + track.Position);
            System.Diagnostics.Trace.WriteLine("Created At = " + track.CreatedAt);
            System.Diagnostics.Trace.WriteLine("Playlist Track Id = " + track.PlaylistTrackId);
        }
        #endregion

        #region Test Getting Favorite Albums (w/ auth)
        [TestMethod]
        public void FavoriteAlbumsGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Favorites favorites;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                favorites = service.FavoriteGetUserFavoritesWithAuth(appid.App_ID, user.UserInfo.Id.ToString(), "albums", user.UserAuthToken, 500, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(favorites != null && !string.IsNullOrEmpty(favorites.User.Id.ToString()));

            foreach (var item in favorites.Albums.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("Track ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Favorite Tracks (w/ auth)
        [TestMethod]
        public void FavoriteTracksGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Favorites favorites;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                favorites = service.FavoriteGetUserFavoritesWithAuth(appid.App_ID, user.UserInfo.Id.ToString(), "tracks", user.UserAuthToken, 500, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(favorites != null && !string.IsNullOrEmpty(favorites.User.Id.ToString()));

            foreach (var item in favorites.Tracks.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("Track ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Favorite Artists (w/ auth)
        [TestMethod]
        public void FavoriteArtistsGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Favorites favorites;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                favorites = service.FavoriteGetUserFavoritesWithAuth(appid.App_ID, user.UserInfo.Id.ToString(), "artists", user.UserAuthToken, 500, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(favorites != null && !string.IsNullOrEmpty(favorites.User.Id.ToString()));

            foreach (var item in favorites.Artists.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Name);
                Console.WriteLine("Track ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Label Info (w/ auth)
        [TestMethod]
        public void LabelGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Label label;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                label = service.LabelGetWithAuth(appid.App_ID, "32535", "albums", user.UserAuthToken, 500, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(label != null && !string.IsNullOrEmpty(label.Id.ToString()));

            foreach (var item in label.Albums.Items)
            {
                Console.WriteLine("Release Name: {0}", item.Title);
                Console.WriteLine("Release ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Playlist Info (w/ auth)
        [TestMethod]
        public void PlaylistGetWithAuth()
        {
            Service service = new Service();
            AppID appid;
            User user;
            Playlist playlist;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                playlist = service.PlaylistGetWithAuth(appid.App_ID, user.UserAuthToken, "14040852", "tracks", 500, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(playlist != null && !string.IsNullOrEmpty(playlist.Id.ToString()));

            foreach (var item in playlist.Tracks.Items)
            {
                Console.WriteLine("Track Name: {0}", item.Title);
                Console.WriteLine("Track ID: {0}", item.Id);
            }
        }
        #endregion

        #region Test Getting Stream Link / Info
        [TestMethod]
        public void Stream()
        {
            Service service = new Service();
            User user;
            AppID appid;
            AppSecret appsecret;
            Stream stream;
            try
            {
                appid = service.GetAppID();
                user = service.Login(appid.App_ID, _testUsername, _testPassword, null);
                appsecret = service.GetAppSecret(appid.App_ID, user.UserAuthToken);
                stream = service.TrackGetFileUrl("280639840", "27", appid.App_ID, user.UserAuthToken, appsecret.App_Secret);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error:\r\n" + ex);
                throw;
            }
            Assert.IsTrue(stream != null && !string.IsNullOrEmpty(stream.StreamURL));
            System.Diagnostics.Trace.WriteLine(stream.StreamURL);
            System.Diagnostics.Trace.WriteLine(stream.FormatID);
        }
        #endregion
    }
}
