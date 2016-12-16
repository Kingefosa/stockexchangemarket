using StockExchangeMarket.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeMarket.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Stock
    {
        private Random stockPriceGenerator = new Random();
        public Stock() { }
        public Stock(string argStockCode) {
            Code = argStockCode;
            Thread.Sleep(100);
            Price = stockPriceGenerator.Next(1, 1000);
        }

        public Stock(DataRow argDataRow)
        {
            Code = (string)Utility.IsNull(argDataRow["Code"], string.Empty);
            Thread.Sleep(100);
            Price = stockPriceGenerator.Next(1, 1000);
        }
        public string Code { get; set; }
        public int Price { get; set; }
    }
}
