using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using StockExchangeMarket.Model;

namespace StockExchangeMarket.Controller
{
    public class SQLAdapter
    {
        private static SqlConnection mSqlConnection;
        private static object syncRoot = new Object();
        public static SqlConnection Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (mSqlConnection == null)
                    {
                        mSqlConnection = new SqlConnection();
                        mSqlConnection.ConnectionString =
                        @"Data Source=" + Constants.SQLServerName + @";" +
                        "Initial Catalog=StockExchangeMarket;" +
                        "Integrated Security=SSPI;";
                    }
                }
                return mSqlConnection;
            }
        }

        public static void Execute(string argSqlQuery){
            try
            {
                if(Instance.State != ConnectionState.Open) Instance.Open();
                SqlCommand command = Instance.CreateCommand();
                command.CommandText = argSqlQuery;
                command.ExecuteNonQuery();
                Instance.Close();
            }
            catch (Exception ex)
            {
                Logger.SaveLog(ex.Message);
                throw new Exception("An error occured on execute process.");
            }     
        }

        public static DataTable Create(string argSqlQuery)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (Instance.State != ConnectionState.Open) Instance.Open();
                SqlCommand command = Instance.CreateCommand();
                command.CommandText = argSqlQuery;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                Instance.Close();
            }
            catch (Exception ex)
            {
                Logger.SaveLog(ex.Message);
                throw new Exception("An error occured on create process.");
            }

            return dataTable;
        }
    }
}
