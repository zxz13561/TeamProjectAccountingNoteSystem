using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAuthentication;

namespace WebPages.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // write page title
            Admin mainMaster = this.Master as Admin;
            mainMaster.MyTitle = "流水帳紀錄系統 - 後台 : 個人資料";

            //check already press button or not
            if (!this.IsPostBack)
            {
                // redirect to login page if user not login
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrecntUser();

                // if user not exist, redirect to login page
                if (currentUser == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                this.ltlAcc.Text = currentUser.Account.ToString();
                this.ltlName.Text = currentUser.Name.ToString();
                this.ltlEmail.Text = currentUser.Email.ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Logout account and redirect to homepage
            AuthManager.Logout();
            Response.Redirect("/Login.aspx");
        }
    }
}