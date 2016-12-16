using StockExchangeMarket.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Tests
{
    public class DBHelper
    {
        public static void RemoveUser(string argUserId)
        {
            string query = "DELETE FROM tblUsers WHERE Id = '" + argUserId + "'";
            SQLAdapter.Execute(query);
        }
    }
}
