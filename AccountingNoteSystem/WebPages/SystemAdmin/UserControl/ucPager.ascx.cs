using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.SystemAdmin.UserControl
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        public string Url { get; set; }
        public int TotalSize { get; set; }  //總筆數
        public int PageSize { get; set; } //頁面筆數
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Bind();
        }

        /// <summary> 顯示頁數功能 </summary>
        public void Bind()
        {
            int totalPages = this.GetTotalPages();
            this.ltlPager.Text = $"總共 {TotalSize} 筆資料, 共 {totalPages} 頁, 目前在第 {GetCurrentPage()} 頁 </br>";

            for (var i = 1; i <= totalPages; i++)
            {
                this.ltlPager.Text += $"<a href='AccountingList.aspx?page={i}'>{i}</a>&nbsp";
            }
        }

        private int GetCurrentPage()
        {
            // get what page
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }

        private int GetTotalPages()
        {
            int pagers = this.TotalSize / this.PageSize;

            if ((this.TotalSize % this.PageSize) > 0)
                pagers += 1;

            return pagers;
        }
    }
}