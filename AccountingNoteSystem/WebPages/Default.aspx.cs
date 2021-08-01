using DataBaseFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get data page need
            DataRow drDefault = AccountingManager.GetDefaultPageData();

            this.ltlFirstDate.Text = drDefault["oldest"].ToString();
            this.ltlLastDate.Text = drDefault["lastest"].ToString();
            this.ltlTotal.Text = drDefault["totalAcc"].ToString();
            this.ltlMembers.Text = drDefault["totalMem"].ToString();
        }
    }
}