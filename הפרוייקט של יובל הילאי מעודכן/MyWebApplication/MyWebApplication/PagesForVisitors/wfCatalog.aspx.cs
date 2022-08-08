using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using ClassLibraryLibDoQuerise;
using System.Collections;

namespace MyWebApplication.PagesForVisitors
{
    public partial class wfCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedDataKey == null) return;
            int IDProduct = int.Parse(GridView1.SelectedDataKey.Value.ToString());
            Response.Redirect("wfProductPage.aspx?IDPRODUCT=" + IDProduct);
        }
    }
}