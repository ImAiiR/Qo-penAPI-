using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QopenAPI;

namespace Qo_penAPI__Tester
{
    [TestClass]
    public class UnitTest1
    {
        string _testUsername = "putemailfortestinghere";
        string _testPassword = "putpasswordfortestinghere";

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
                user = service.Login(appid.App_ID, _testUsername, _testPassword);
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
                user = service.Login(appid.App_ID, _testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
            System.Diagnostics.Trace.WriteLine(user.UserAuthToken);
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
                user = service.Login(appid.App_ID, _testUsername, _testPassword);
                appsecret = service.GetAppSecret(appid.App_ID, user.UserAuthToken);
                stream = service.GetStream("125486173", "27", appid.App_ID, user.UserAuthToken, appsecret.App_Secret);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(stream != null && !string.IsNullOrEmpty(stream.StreamURL));
            System.Diagnostics.Trace.WriteLine(stream.StreamURL);
        }
        #endregion
    }
}
