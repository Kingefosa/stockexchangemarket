using StockExchangeMarket.Controller;
using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace StockExchangeMarket.Web
{
    /// <summary>
    /// Summary description for LoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void Login(string argUsername, string argPassword)
        {
            LoginAndGetUser(argUsername, argPassword);
        }

        [WebMethod(EnableSession = true)]
        public void Logout()
        {
            System.Web.HttpContext.Current.Session["UserId"] = null;
        }

        [WebMethod(EnableSession = true)]
        public static void LoginAndGetUser(string argUsername, string argPassword)
        {
            User user = UserProvider.GetUserByInfo(argUsername, argPassword);
            if (user == null)
            {
                throw new Exception("Invalid Username/Password");
            }
            System.Web.HttpContext.Current.Session["UserId"] = user.Id;
        }
    }
}
