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
                        [ID]
                        ,[Account]
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

        /// <summary> 取得會員資訊 </summary>
        /// <param name="id"> UID </param>
        /// <returns> 帳號的會員資訊 </returns>
        public static DataRow GetUserInfo(string id)
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
                     WHERE [ID] = @id
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));

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

        /// <summary> 新增帳號 </summary>
        /// <param name="id"> Guid </param>
        /// <param name="account"> 帳號 </param>
        /// <param name="name"> 名稱 </param>
        /// <param name="pwd"> 密碼 </param>
        /// <param name="userlevel"> 權限 </param>
        public static void CreateNewUser(string id, string account, string name, string pwd, string email, int userlevel)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"INSERT INTO [dbo].[UserInfo]
                        ([ID]
                        ,[Account]
                        ,[Name]
                        ,[PWD]
                        ,[Email]
                        ,[UserLevel]
                        ,[CreateDate])
                    VALUES
                        (@id,
                        @account,
                        @name,
                        @pwd,
                        @email,
                        @userLevel,
                        @createDate)
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@id", id));
            parmList.Add(new SqlParameter("@account", account));
            parmList.Add(new SqlParameter("@name", name));
            parmList.Add(new SqlParameter("@pwd", pwd));
            parmList.Add(new SqlParameter("@email", email));
            parmList.Add(new SqlParameter("@userLevel", userlevel));
            parmList.Add(new SqlParameter("@createDate", DateTime.Now));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
        }

        /// <summary> 更新會員資料 </summary>
        /// <param name="id"> UID </param>
        /// <param name="name"> 名稱 </param>
        /// <param name="email"> Email </param>
        /// <returns> 修改的筆數(int) </returns>
        public static bool UpdateUserInfo(string id, string name, string email)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"UPDATE [dbo].[UserInfo]
                     SET
                        [Name] = @name,
                        [Email] = @email
                    WHERE
                        [ID] = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@Name", name));
            parmList.Add(new SqlParameter("@email", email));
            parmList.Add(new SqlParameter("@id", id));

            try
            {
                int effectRows = DBHelper.ModifyDatas(connStr, dbCommand, parmList);

                // check update successfully and return
                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return false;
            }
        }

        /// <summary> 刪除帳號 </summary>
        /// <param name="uid"> UID </param>
        public static void DeleteUser(string uid)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"DELETE FROM [dbo].[UserInfo]
                    WHERE [ID] = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@id", uid));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
        }

        /// <summary> 更新會員密碼 </summary>
        /// <param name="id"> UID </param>
        /// <param name="pwd"> 新密碼 </param>
        /// <returns> 修改的筆數(int) </returns>
        public static bool UpdatePassword(string id, string pwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"UPDATE [dbo].[UserInfo]
                     SET
                        [PWD]= @pwd
                     WHERE
                        [ID] = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@PWD", pwd));
            parmList.Add(new SqlParameter("@id", id));

            try
            {
                int effectRows = DBHelper.ModifyDatas(connStr, dbCommand, parmList);

                // check update successfully and return
                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return false;
            }
        }
    }
}
