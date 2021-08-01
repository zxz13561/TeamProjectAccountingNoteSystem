using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataBaseFunctions;

namespace UserAuthentication
{
    /// <summary> User Authentication Functions </summary>
    public class AuthManager
    {
        /// <summary> Check is login or not </summary>
        /// <returns>Boolean Value</returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary> 取得現有使用者資訊 </summary>
        /// <returns> 使用者DataRow(格式請參考UserAuthentication.UserInfoModel) </returns>
        public static UserInfoModel GetCurrecntUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            // check Session empty or login
            if (account == null) 
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            // Check account is in database
            if (dr == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            // Write into model
            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();

            return model;
        }

        /// <summary> 登出 </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }

        /// <summary> 嘗試登入 </summary>
        /// <param name="account">帳號</param>
        /// <param name="pwd">密碼</param>
        /// <param name="errMsg">錯誤資訊</param>
        /// <returns>Boolean value. If error happened, set errMsg context</returns>
        public static bool TryLogin(string account, string pwd, out string errMsg)
        {
            // check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errMsg = "Account / Pwd is required.";
                return false;
            }

            var dr = UserInfoManager.GetUserInfoByAccount(account);

            // check account is in database
            if (dr == null)
            {
                errMsg = "Account doesn't exists.";
                return false;
            }

            // check account / password
            if (string.Compare(dr["Account"].ToString(), account, true) == 0 && string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();
                errMsg = string.Empty;
                return true;
            }
            else
            {
                errMsg = "Login fail. Please check Account / PWD";
                return false;
            }
        }
    }
}
