using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFunctions
{
    /// <summary> DataBase basic operate functions </summary>
    class DBHelper
    {
        /// <summary> 取得SQL連線字串 </summary>
        /// <returns> Web.Config中的連線設定 </returns>
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }

        /// <summary> 讀取資料庫中的指定資料表 </summary>
        /// <param name="connStr">連線字串</param>
        /// <param name="dbCommand">SQL語法</param>
        /// <param name="list">輸入的Values List</param>
        /// <returns>Data Table 資料</returns>
        public static DataTable ReadDataTable(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    //comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }

        /// <summary> 讀取資料庫中的指定列資料 </summary>
        /// <param name="connStr">連線字串</param>
        /// <param name="dbCommand">SQL語法</param>
        /// <param name="list">輸入的Values List</param>
        /// <returns>Data Row 資料</returns>
        public static DataRow ReadDataRow(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count == 0)
                        return null;
                    else
                        return dt.Rows[0];
                }
            }
        }

        /// <summary> 編輯資料表中的資料 </summary>
        /// <param name="connStr">連線字串</param>
        /// <param name="dbCommand">SQL語法</param>
        /// <param name="parmList">輸入的Values List</param>
        /// <returns> 受影響的的資料列數量 </returns>
        public static int ModifyDatas(string connStr, string dbCommand, List<SqlParameter> parmList)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(parmList.ToArray());
                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }
    }
}
