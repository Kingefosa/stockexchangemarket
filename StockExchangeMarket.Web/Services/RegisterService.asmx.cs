using StockExchangeMarket.Controller;
using StockExchangeMarket.Controller.DAL;
using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace StockExchangeMarket.Web
{
    /// <summary>
    /// Summary description for RegisterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RegisterService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void Register(string argUsername, string argPassword)
        {
            if (UserProvider.GetUserByUsername(argUsername) == null)
            {
                UserDAL.SaveUser(argUsername, argPassword);
            }
            else
            {
                throw new Exception("Username already exist");
            }
            LoginService.LoginAndGetUser(argUsername, argPassword);
        }
    }
}
