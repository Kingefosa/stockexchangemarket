using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchangeMarket.Controller;
using StockExchangeMarket.Controller.DAL;
using StockExchangeMarket.Model;
using System.Collections.Generic;

namespace StockExchangeMarket.Tests
{
    [TestClass]
    public class StockProviderTests
    {
        [TestMethod]
        public void GetStocksByUserId_UserHaveStocks_ReturnsStocks()
        {
            string userId = "#TestUserId#";
            string stockCode = "#TestStockCode#";
            StockDAL.SaveStock(stockCode, userId);
            List<Stock> userStocks = StockProvider.GetStocksByUserId(userId);           
            StockDAL.RemoveStock(stockCode, userId);
            Assert.AreNotEqual(userStocks, null);
        }

        [TestMethod]
        public void GetStocksByUserId_UserDoNotHaveAnyStock_ReturnsNull()
        {
            string userId = "#TestUserId#";
            List<Stock> userStocks = StockProvider.GetStocksByUserId(userId);
            Assert.AreEqual(userStocks, null);
        }

        [TestMethod]
        public void GetStock_ValidArgument_ReturnsStock()
        {
            string userId = "#TestUserId#";
            string stockCode = "#TestStockCode#";
            StockDAL.SaveStock(stockCode, userId);
            Stock userStock = StockProvider.GetStock(stockCode, userId);
            StockDAL.RemoveStock(stockCode, userId);
            Assert.AreNotEqual(userStock, null);
        }

        [TestMethod]
        public void GetStock_InvalidArgument_ReturnsNull()
        {
            string userId = "#TestUserId#";
            string stockCode = "#TestStockCode#";
            Stock userStock = StockProvider.GetStock(stockCode, userId);
            Assert.AreEqual(userStock, null);
        }
    }
}
