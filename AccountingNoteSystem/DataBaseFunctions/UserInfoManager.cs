using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFunctions
{
    /// <summary> 管理使用者資訊功能 </summary>
    public class UserInfoManager
    {
        /// <summary> 依照帳號取得會員資訊 </summary>
        /// <param name="_account">帳號</param>
        /// <returns>使用者DataRow</returns>
        public static DataRow GetUserInfoByAccount(string _account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @"SELECT [ID],[Account],[PWD],[Name],[Email]
                     FROM UserInfo
                     WHERE [Account] = @account
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", _account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }
    }
}
