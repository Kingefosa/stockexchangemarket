using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller.DAL
{
    public class LogDAL
    {
        public static void SaveLog(string argLogMessage, string argUsername = "SystemUser")
        {
            string lcQuery = "EXEC spSaveLog @argLogMessage = '" +
                argLogMessage + "'" +
                ", @argUsername = '" + argUsername + "'";
            SQLAdapter.Execute(lcQuery);
        }
    }
}
