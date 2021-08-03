using DataBaseFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAuthentication;

namespace WebPages.SystemAdmin
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // write page title
            Admin mainMaster = this.Master as Admin;
            mainMaster.MyTitle = "流水帳紀錄系統 - 後台 : 編輯會員資料";

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
                // Check is account create mode or edit mode
                if (this.Request.QueryString["UID"] == null)
                {
                    this.btnDelete.Visible = false;

                    // enable input
                    this.txtID.Enabled = true;
                    this.txtAccount.Enabled = true;
                    this.ddlUserLevel.Enabled = true;
                    this.ltlCreateDate.Text = DateTime.Now.ToString();
                }
                else
                {
                    this.btnDelete.Visible = true;

                    // disable input
                    this.txtID.Enabled = false;
                    this.txtAccount.Enabled = false;
                    this.ddlUserLevel.Enabled = false;

                    // check query string
                    string accText = this.Request.QueryString["UID"];
                    if (!string.IsNullOrWhiteSpace(accText))
                    {
                        var drUser = UserDBManager.GetUserInfo(accText);

                        // check user in data base
                        if (drUser == null)
                        {
                            this.ltlMsg.Text = "User doesn't exist";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;
                        }
                        else
                        {
                            this.txtID.Text = drUser["ID"].ToString();
                            this.txtAccount.Text = drUser["Account"].ToString();
                            this.txtName.Text = drUser["Name"].ToString();
                            this.ddlUserLevel.SelectedValue = drUser["UserLevel"].ToString();
                            this.txtEmail.Text = drUser["Email"].ToString();
                            this.ltlCreateDate.Text = drUser["CreateDate"].ToString();
                        }
                    }
                    else
                    {
                        this.ltlMsg.Text = "User Account is required.";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}