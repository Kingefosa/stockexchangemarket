using StockExchangeMarket.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeMarket.Controller.DAL
{
    public class UserDAL
    {
        public static void SaveUser(string argUsername, string argPassword) {
            string query = "EXEC spSaveUser @argId = '" +
                SecurityHelper.CreateMD5(argUsername+argPassword+Constants.UserIdPrivateSecurityKey) + "'" +
                ", @argUserName = '" + argUsername + "'" +
                ", @argPassword = '" + SecurityHelper.CreateMD5(argPassword) + "'";
            SQLAdapter.Execute(query);
        }

        public static User GetUserById(string argUserId)
        {
            string lcQuery = "EXEC spGetUserById @argId = '" + argUserId + "'";
            return GetUserByQuery(lcQuery);
        }

        public static User GetUserByUsername(string argUsername)
        {
            string lcQuery = "EXEC spGetUserByUsername @argUsername = '" + argUsername + "'";
            return GetUserByQuery(lcQuery);
        }

        public static User GetUserByInfo(string argUsername, string argPassword)
        {
            string lcQuery = "EXEC spGetUserByInfo @argUsername = '" + argUsername + "', @argPassword = '" + SecurityHelper.CreateMD5(argPassword) + "'";
            return GetUserByQuery(lcQuery);
        }

        private static User GetUserByQuery(string argSqlQuery)
        {
            DataTable dtUser = SQLAdapter.Create(argSqlQuery);
            User user = null;
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                user = new User(dtUser.Rows[0]);
            }
            return user;
        }
    }
}
