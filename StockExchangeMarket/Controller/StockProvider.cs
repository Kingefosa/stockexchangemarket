using StockExchangeMarket.Controller.DAL;
using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller
{
    public class StockProvider
    {
        public static List<Stock> GetStocksByUserId(string argUserId)
        {
            return StockDAL.GetStocksByUserId(argUserId);
        }

        public static Stock GetStock(string argStockCode, string argUserId)
        {
            return StockDAL.GetStock(argStockCode, argUserId);
        }
    }
}
