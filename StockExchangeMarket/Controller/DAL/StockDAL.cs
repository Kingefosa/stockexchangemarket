using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller.DAL
{
    public class StockDAL
    {
        public static void SaveStock(string argStockCode, string argUserId)
        {
            string query = "EXEC spSaveUserStock @argCode = '" + argStockCode + "'" +
                ", @argUserId = '" + argUserId + "'";
            SQLAdapter.Execute(query);
        }
        public static void RemoveStock(string argStockCode, string argUserId)
        {
            string query = "EXEC spRemoveUserStock @argCode = '" + argStockCode + "'" +
                   ", @argUserId = '" + argUserId + "'";
            SQLAdapter.Execute(query);
        }
        public static List<Stock> GetStocksByUserId(string argUserId)
        {
            string lcQuery = "EXEC spGetStocksByUserId @argUserId = '" + argUserId + "'";
            DataTable dtUserStocks = SQLAdapter.Create(lcQuery);
            List<Stock> stocks = null;
            if (dtUserStocks != null && dtUserStocks.Rows.Count > 0)
            {
                stocks = new List<Stock>();
                foreach (DataRow row in dtUserStocks.Rows)
                {
                    stocks.Add(new Stock(row));
                }
            }
            return stocks;
        }

        public static Stock GetStock(string argStockCode, string argUserId)
        {
            string lcQuery = "EXEC spGetStock @argCode = '" + argStockCode + "'" +
                ", @argUserId = '" + argUserId + "'";
            DataTable dtUserStocks = SQLAdapter.Create(lcQuery);
            Stock stock = null;
            if (dtUserStocks != null && dtUserStocks.Rows.Count > 0)
            {
                stock = new Stock(dtUserStocks.Rows[0]);
            }
            return stock;
        }
    }
}
