using StockExchangeMarket.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Model
{
    public class User
    {
        public User() { }
        public User(DataRow argDataRow)
        {
            Id = (string)Utility.IsNull(argDataRow["Id"], string.Empty);
            Username = (string)Utility.IsNull(argDataRow["Username"], string.Empty);
            Password = (string)Utility.IsNull(argDataRow["Pass"], string.Empty);
            StockList = StockProvider.GetStocksByUserId(Id);
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Stock> StockList { get; set; }
    }
}
