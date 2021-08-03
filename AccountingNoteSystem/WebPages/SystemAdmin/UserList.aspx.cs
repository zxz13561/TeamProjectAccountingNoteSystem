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
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // write page title
            Admin mainMaster = this.Master as Admin;
            mainMaster.MyTitle = "流水帳紀錄系統 - 後台 : 會員管理";

            // check login
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var dtUser = UserDBManager.GetUserList();

            // check get user list
            if (dtUser.Rows.Count > 0)
            {
                this.gvUserList.DataSource = dtUser;
                this.gvUserList.DataBind();
                this.plcNoUser.Visible = false;
            }
            else
            {
                this.gvUserList.Visible = false;
                this.plcNoUser.Visible = true;
            }
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // get grid view row
            var row = e.Row;

            // select row
            if (row.RowType == DataControlRowType.DataRow)
            {
                // set row label
                Label lbl = row.FindControl("lblUserLevel") as Label;

                // get user level data
                var dr = e.Row.DataItem as DataRowView;
                int userLevel = dr.Row.Field<int>("UserLevel");

                if (userLevel == 0)
                {
                    lbl.Text = "管理者";
                }
                else
                {
                    lbl.Text = "一般會員";
                }
            }
        }

        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetail.aspx");
        }
    }
}