using System;
using System.Collections.Generic;
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

        }
    }
}