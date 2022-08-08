using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using ClassLibraryLibDoQuerise;
using System.Collections;
using System.Web.UI.WebControls;

namespace MyWebApplication.PagesForClients
{
    public partial class wfOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDORDER"] == null)
                Response.Redirect("wfPayment.aspx");
            else
            {
                ViewOrderDetails();
                ViewItemsInOrder();
            }

        }
        private void ViewOrderDetails()
        {
            int idOrder = int.Parse(Request.QueryString["IDORDER"].ToString());
            Entities.Order order = new Entities.Order();
            order.idOrder = idOrder;
            DataTable dt = order.GetDetails();
            gvOrderDetails.DataSource = dt;
            gvOrderDetails.DataBind();
        }
        private void ViewItemsInOrder()
        {
            int idOrder = int.Parse(Request.QueryString["IDORDER"].ToString());
            Entities.ShoppingBags item = new Entities.ShoppingBags();
            item.idOrder = idOrder;
            DataTable dt = item.GetDetails();
            gvItemsInOrder.DataSource = dt;
            gvItemsInOrder.DataBind();

        }

   
    }
}

