using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFunctions
{
    /// <summary> 流水帳功能管理 </summary>
    public class AccountingManager
    {
        /// <summary> 查詢首頁頁面資訊所需資料 </summary>
        /// <returns> DataRow </returns>
        public static DataRow GetDefaultPageData()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT MAX([Accounting].[CreateDate]) AS lastest
	                                ,MIN([Accounting].[CreateDate]) AS oldest
	                                ,COUNT(*) AS totalAcc
	                                ,(SELECT COUNT(*) FROM [dbo].[UserInfo]) AS totalMem
                    FROM [dbo].[Accounting]
                 ";

            List<SqlParameter> list = new List<SqlParameter>();

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

        /// <summary> 檢查流水帳清單 </summary>
        /// <param name="userID"> 使用者ID </param>
        /// <returns> 使用者DataTable </returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT [ID],[Caption],[Amount],[ActType],[CreateDate]
                     FROM Accounting
                     WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

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

        /// <summary> 檢查流水帳資料列 </summary>
        /// <param name="id"> 資料ID </param>
        /// <param name="userID"> 使用者ID </param>
        /// <returns> 使用者DataRow </returns>
        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT 
                        [ID],
                        [Caption],
                        [Amount],
                        [ActType],
                        [CreateDate],
                        [Body]
                     FROM Accounting
                     WHERE ID = @id AND UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));

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

        /// <summary> 建立流水帳 </summary>
        /// <param name="userID"> 使用者ID </param>
        /// <param name="caption"> 標題 </param>
        /// <param name="amount"> 金額 </param>
        /// <param name="actType"> 收支</param>
        /// <param name="body"> 描述 </param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            // <<<check input>>>
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must be between 0 ~ 10,000,000");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("Act Type must be 0 or 1");
            // <<< check input>>>

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"INSERT INTO [dbo].[Accounting]
                        ([UserID]
                        ,[Caption]
                        ,[Amount]
                        ,[ActType]
                        ,[CreateDate]
                        ,[Body])
                    VALUES
                        (@userID,
                        @caption,
                        @amount,
                        @actType,
                        @createDate,
                        @body)
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@userID", userID));
            parmList.Add(new SqlParameter("@caption", caption));
            parmList.Add(new SqlParameter("@amount", amount));
            parmList.Add(new SqlParameter("@actType", actType));
            parmList.Add(new SqlParameter("@createDate", DateTime.Now));
            parmList.Add(new SqlParameter("@body", body));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
        }

        /// <summary> 更新流水帳 </summary>
        /// <param name="ID"> 資料ID </param>
        /// <param name="userID"> 使用者ID </param>
        /// <param name="caption"> 標題 </param>
        /// <param name="amount"> 金額 </param>
        /// <param name="actType"> 收支 </param>
        /// <param name="body"> 描述 </param>
        /// <returns> Boolean value </returns>
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            // <<<check input>>>
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must be between 0 ~ 10,000,000");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("Act Type must be 0 or 1");
            // <<< check input

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"UPDATE [Accounting]
                     SET
                        UserID          = @userID,
                        Caption         = @caption,
                        Amount         =@amount,
                        ActType        =@actType,
                        CreateDate   = @createDate,
                        Body             = @body
                    WHERE
                        ID = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@userID", userID));
            parmList.Add(new SqlParameter("@caption", caption));
            parmList.Add(new SqlParameter("@amount", amount));
            parmList.Add(new SqlParameter("@actType", actType));
            parmList.Add(new SqlParameter("@createDate", DateTime.Now));
            parmList.Add(new SqlParameter("@body", body));
            parmList.Add(new SqlParameter("@id", ID));

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

        /// <summary> 刪除流水帳 </summary>
        /// <param name="ID"> 資料ID </param>
        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"DELETE [Accounting]
                    WHERE
                        ID = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@id", ID));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
        }
    }
}
