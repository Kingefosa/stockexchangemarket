using StockExchangeMarket.Controller.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller
{
    public class Logger
    {
        public static void SaveLog(string argLogMessage, string argUsername = "SystemUser")
        {
            LogDAL.SaveLog(argLogMessage, argUsername);
        }
    }
}
