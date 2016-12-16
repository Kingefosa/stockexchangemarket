using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace StockExchangeMarket.Model
{
    public class Constants
    {
        public const string UserIdPrivateSecurityKey = "ABCDEF123456ABCD";
        public readonly static string SQLServerName = WebConfigurationManager.AppSettings["SQLServerName"];
    }
}
