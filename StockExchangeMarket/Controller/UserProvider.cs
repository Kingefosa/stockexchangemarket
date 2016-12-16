using StockExchangeMarket.Controller.DAL;
using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller
{
    public class UserProvider
    {
        public static User GetUserById(string argId)
        {
            return UserDAL.GetUserById(argId);
        }

        public static User GetUserByUsername(string argUsername)
        {
            return UserDAL.GetUserByUsername(argUsername);
        }

        public static User GetUserByInfo(string argUsername, string argPassword)
        {
            return UserDAL.GetUserByInfo(argUsername, argPassword);
        }
    }
}
