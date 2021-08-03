using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAuthentication;

namespace WebPages.SystemAdmin
{
    public partial class UserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // write page title
            Admin mainMaster = this.Master as Admin;
            mainMaster.MyTitle = "流水帳紀錄系統 - 後台 : 修改密碼";

            // check login
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrecntUser();

            // if user not exist, redirect to login page
            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            // check is postback
            if (!this.IsPostBack)
            {
                // check query string
                string uidText = this.Request.QueryString["UID"];
                if (!string.IsNullOrWhiteSpace(uidText))
                {
                    var drUser = UserDBManager.GetUserInfo(uidText);

                    // check user in data base
                    if (drUser == null)
                    {
                        this.ltlErrMsg.Text = "User doesn't exist";
                    }
                    else
                    {
                        this.ltlAcc.Text = drUser["Account"].ToString();
                    }
                }
                else
                {
                    this.ltlErrMsg.Text = "User Account is required.";
                }
            }
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            string _newPwd = this.txtNewPwd.Text;

            // recover error messages
            this.ltlCheckMsg.Text = string.Empty;
            this.ltlErrMsg.Text = string.Empty;

            if (string.Compare(this.txtOldPwd.Text, this.txtPwdCheck.Text, false) != 0)
            {
                this.ltlCheckMsg.Text = "舊密碼與確認密碼不相同";
                return;
            }

            if (this.txtNewPwd.Text.Length < 8 || this.txtNewPwd.Text.Length > 16)
            {
                this.ltlErrMsg.Text = "新密碼長度應大於8個字元，小於16個字元";
                return;
            }

            // check query string
            string uidText = this.Request.QueryString["UID"];
            if (!string.IsNullOrWhiteSpace(uidText))
            {
                var drUser = UserDBManager.GetUserInfo(uidText);

                // check user in data base
                if (drUser == null)
                {
                    this.ltlErrMsg.Text = "查無會員";
                }
                else
                {
                    string _oldPwd = drUser["PWD"].ToString();
                    if (string.Compare(this.txtPwdCheck.Text, _oldPwd, false) == 0)
                    {
                        UserDBManager.UpdatePassword(uidText, this.txtNewPwd.Text);
                        Response.Redirect("UserList.aspx");
                    }
                    else
                    {
                        this.ltlErrMsg.Text = "會員密碼不符";
                        return;
                    }
                }
            }
            else
            {
                this.ltlErrMsg.Text = "沒有取得會員ID";
            }
        }
    }
}