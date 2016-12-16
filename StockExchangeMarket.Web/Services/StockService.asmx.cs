using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using StockExchangeMarket.Model;
using System.Security.Authentication;
using StockExchangeMarket.Model.Interfaces;
using System.Web.Script.Services;
using StockExchangeMarket.Controller;
using System.Web.Script.Serialization;
using StockExchangeMarket.Controller.DAL;

namespace StockExchangeMarket.Web
{
    /// <summary>
    /// Summary description for StockService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Web.Script.Services.ScriptService]
    public class StockService : System.Web.Services.WebService, IAuthorizable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argStockCodes"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<Stock> GetStockPrices(List<string> argStockCodes)
        {
            List<Stock> stockList = null;
            if (System.Web.HttpContext.Current.Session["UserId"] != null && DoesUserHaveAccess(UserProvider.GetUserById(System.Web.HttpContext.Current.Session["UserId"].ToString())))
            {
                stockList = new List<Stock>();
                foreach (string stockCode in argStockCodes)
                {
                    stockList.Add(new Stock(stockCode));
                }
            }
            else
            {
                throw new AuthenticationException("You do not have access! Sorry :(");
            }

            return stockList;
        }

        [WebMethod(EnableSession = true)]
        public Stock AddNewStock(string argStockCode)
        {
            Stock stock = null;
            if (System.Web.HttpContext.Current.Session["UserId"] != null && DoesUserHaveAccess(UserProvider.GetUserById(System.Web.HttpContext.Current.Session["UserId"].ToString())))
            {
                if (StockProvider.GetStock(argStockCode, System.Web.HttpContext.Current.Session["UserId"].ToString()) == null)
                {
                    stock = new Stock(argStockCode);
                    StockDAL.SaveStock(argStockCode, System.Web.HttpContext.Current.Session["UserId"].ToString());
                }
                else
                {
                    throw new Exception("Stock code already exist");
                }          
            }
            else
            {
                throw new AuthenticationException("You do not have access! Sorry :(");
            }

            return stock;
        }

        [WebMethod(EnableSession = true)]
        public void RemoveStock(string argStockCode)
        {
            if (System.Web.HttpContext.Current.Session["UserId"] != null && DoesUserHaveAccess(UserProvider.GetUserById(System.Web.HttpContext.Current.Session["UserId"].ToString())))
            {
                StockDAL.RemoveStock(argStockCode, System.Web.HttpContext.Current.Session["UserId"].ToString());
            }
            else
            {
                throw new AuthenticationException("You do not have access! Sorry :(");
            }
        }

        [WebMethod(EnableSession = true)]
        public List<Stock> GetUserStocks()
        {
            List<Stock> stockList = null;
            if (System.Web.HttpContext.Current.Session["UserId"] != null && DoesUserHaveAccess(UserProvider.GetUserById(System.Web.HttpContext.Current.Session["UserId"].ToString())))
            {
                stockList = StockProvider.GetStocksByUserId(System.Web.HttpContext.Current.Session["UserId"].ToString());
            }
            else
            {
                throw new AuthenticationException("You do not have access! Sorry :(");
            }

            return stockList;
        }

        public bool DoesUserHaveAccess(User argUser)
        {
            return argUser != null;
        }
    }
}
