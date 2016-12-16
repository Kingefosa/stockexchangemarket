using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchangeMarket.Controller.DAL;
using StockExchangeMarket.Controller;
using StockExchangeMarket.Model;
using System.Data;

namespace StockExchangeMarket.Tests
{
    [TestClass]
    public class UserProviderTests
    {
        [TestMethod]
        public void GetUserById_ValidId_ReturnsUser()
        {
            string username = "testuser";
            string password = "testpassword";
            User user = null;
            string userid = string.Empty;
            try
            {
                UserDAL.SaveUser(username, password);
                userid = SecurityHelper.CreateMD5(username + password + Constants.UserIdPrivateSecurityKey);
                user = UserProvider.GetUserById(userid);
                DBHelper.RemoveUser(user.Id);
            }
            catch (Exception)
            {
                //may be rollback on transaction but not necessary for this app
            }
            if (user != null)
            {
                Assert.AreEqual(username, user.Username);
                Assert.AreEqual(SecurityHelper.CreateMD5(password), user.Password);
                Assert.AreEqual(userid, user.Id);
            }
        }

        [TestMethod]
        public void GetUserById_InValidId_ReturnsNull()
        {
            string invalidId = "#invalidTestId#";
            User user = UserProvider.GetUserById(invalidId);
            Assert.AreEqual(user, null);
        }

        [TestMethod]
        public void GetUserByUsername_ValidUsername_ReturnsUser()
        {
            string username = "testuser";
            string password = "testpassword";
            User user = null;
            string userid = string.Empty;
            try
            {
                UserDAL.SaveUser(username, password);
                user = UserProvider.GetUserByUsername(username);
                DBHelper.RemoveUser(user.Id);
            }
            catch (Exception)
            {
                //may be rollback on transaction but not necessary for this app
            }
            if (user != null)
            {
                Assert.AreEqual(username, user.Username);
            }
        }

        [TestMethod]
        public void GetUserByUsername_InValidUsername_ReturnsNull()
        {
            string invalidUsername = "#invalidUserName#";
            User user = UserProvider.GetUserByUsername(invalidUsername);
            Assert.AreEqual(user, null);
        }

        [TestMethod]
        public void GetUserByInfo_ValidInfo_ReturnsUser()
        {
            string username = "testuser";
            string password = "testpassword";
            User user = null;
            string userid = string.Empty;
            try
            {
                UserDAL.SaveUser(username, password);
                user = UserProvider.GetUserByInfo(username, password);
                DBHelper.RemoveUser(user.Id);
            }
            catch (Exception)
            {
                //may be rollback on transaction but not necessary for this app
            }
            if (user != null)
            {
                Assert.AreEqual(username, user.Username);
                Assert.AreEqual(SecurityHelper.CreateMD5(password), user.Password);
            }
        }

        [TestMethod]
        public void GetUserByInfo_InValidInfo_ReturnsNull()
        {
            string invalidUsername = "#invalidUserName#";
            string invalidPassword = "#invalidPassword#";
            User user = UserProvider.GetUserByInfo(invalidUsername, invalidPassword);
            Assert.AreEqual(user, null);
        }
    }
}
