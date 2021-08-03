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
                @"SELECT 
                        [Account]
                        ,[Name]
                        ,[Email]
                        ,[UserLevel]
                        ,[CreateDate]
                     FROM [UserInfo]
                     ORDER BY [CreateDate] DESC
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

        /// <summary> 取的會員資訊 </summary>
        /// <param name="account"> 帳號 </param>
        /// <returns> 帳號的會員資訊 </returns>
        public static DataRow GetUserInfo(string account)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT 
                        [ID],
                        [Account],
                        [PWD],
                        [Name],
                        [Email],
                        [CreateDate],
                        [UserLevel]
                     FROM [dbo].[UserInfo]
                     WHERE [Account] = @account
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }
    }
}
