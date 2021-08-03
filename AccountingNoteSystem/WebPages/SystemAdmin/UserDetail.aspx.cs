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
                    // visible setting
                    this.txtID.Visible = true;
                    this.lblPwd.Visible = true;
                    this.txtPwd.Visible = true;

                    // enable input
                    this.txtID.Enabled = true;
                    this.txtAccount.Enabled = true;
                    this.txtPwd.Enabled = true;
                    this.ddlUserLevel.Enabled = true;
                    this.ltlCreateDate.Text = DateTime.Now.ToString();
                }
                else
                {
                    // visible setting
                    this.btnDelete.Visible = true;
                    this.btnPwd.Visible = true;

                    // disable input
                    this.txtID.Enabled = false;
                    this.txtAccount.Enabled = false;
                    this.txtPwd.Enabled = false;
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
            List<string> msgList = new List<string>();

            // check input have error
            if (!this.CheckInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            // check editor user is same data user
            var currentUser = AuthManager.GetCurrecntUser();
            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            // collect input data
            string _id = this.txtID.Text;
            string _account = this.txtAccount.Text;
            string _pwd = this.txtPwd.Text;
            string _name = this.txtName.Text;
            string _email = this.txtEmail.Text;
            string _level = this.ddlUserLevel.SelectedValue;

            // get data ID from query string
            string txtUID = this.Request.QueryString["UID"];

            // check data ID
            if (string.IsNullOrWhiteSpace(txtUID))
            {
                // check User Level correct
                if (int.TryParse(_level, out int userlevel))
                {
                    // create new user
                    UserDBManager.CreateNewUser(_id, _account, _name, _pwd, _email, userlevel);
                }
            }
            else
            {
                // update user information
                UserDBManager.UpdateUserInfo(txtUID, _name, _email);
            }

            // wipe out password
            _pwd = string.Empty;
            this.txtPwd.Text = string.Empty;

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // get data ID from query string
            string txtUID = this.Request.QueryString["UID"];

            // delete user
            UserDBManager.DeleteUser(txtUID);

            Response.Redirect("UserList.aspx");
        }

        protected void btnPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPassword.aspx");
        }

        /// <summary> 檢查輸入選項 </summary>
        /// <param name="errorMsgList"> 錯誤訊息 </param>
        /// <returns> Boolean value </returns>
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            //Check ID
            if (string.IsNullOrWhiteSpace(this.txtID.Text))
                msgList.Add("請輸入ID !");
            else
            if (!Guid.TryParse(this.txtID.Text, out Guid _testUID))
                msgList.Add("ID不是Guid格式 !");


            //Check Account
            if (string.IsNullOrWhiteSpace(this.txtAccount.Text))
                msgList.Add("請輸入帳號 !");

            //Check Name
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
                msgList.Add("請輸入名稱 !");

            //Check Email
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
                msgList.Add("請輸入E-mail !");
            else
                if (!IsValidEmail(this.txtEmail.Text))
                    msgList.Add("請輸入正確的Email格式 !");

            //Check User Level
            if (this.ddlUserLevel.SelectedValue != "0" && this.ddlUserLevel.SelectedValue != "1")
            {
                msgList.Add("請正確使用選單 !");
            }

            errorMsgList = msgList;

            // check have error
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        /// <summary> 檢查Email格式正確 </summary>
        /// <param name="email"> 字串 </param>
        /// <returns> Boolean </returns>
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}