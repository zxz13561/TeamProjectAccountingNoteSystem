using DataBaseFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication
{
    public class UserDBManager
    {
        /// <summary> 讀取會員清單 </summary>
        /// <returns> 會員資料(DataTable) </returns>
        public static DataTable GetUserList()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT [Account],[Name],[Email],[UserLevel],[CreateDate]
                     FROM UserInfo
                 ";

            List<SqlParameter> list = new List<SqlParameter>();

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }
    }
}
