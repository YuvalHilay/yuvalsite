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
    public partial class wfPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDCLIENT"] == null)
            {
                Response.Redirect("../PagesForVisitors/wfLogin.aspx");
            }
            ViewClientDetails();


            if (Session["Cart"] != null)
                if (((DataTable)Session["Cart"]).Rows.Count > 0)//אם יש פריטים בעגלה
                    ViewCart();

            if (!IsPostBack)
            {
                PopddlExpireYear();
                PopddlMonth();
                PopddlCompanyList();
            }
            }

            private void PopddlMonth()
        {
            for (int i = 1; i <= 12; i++)
                ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlMonth.SelectedIndex = 0;
        }
            private void PopddlExpireYear()
            {
                for (int i = DateTime.Today.Year; i <= DateTime.Today.Year + 5; i++)
                    ddlExpireYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlExpireYear.SelectedIndex = 0;
            }

            private void PopddlCompanyList()
            {
                ProxyCreditCard.wsCreditCardService service = new ProxyCreditCard.wsCreditCardService();
                DataSet ds = service.GetCompanies();
                DataTable dt = ds.Tables[0];
                ddlCompanies.DataSource = dt;
                ddlCompanies.DataTextField = "CompanyName";
                ddlCompanies.DataValueField = "IdCompany";
                ddlCompanies.DataBind();
                ddlCompanies.SelectedIndex = 0;
            }

        private void ViewClientDetails()
        {
           
            //חילוץ קוד לקוח מאובייקט הסטיין
            int idClient = (int)(Session["IDCLIENT"]);
            //יצירת אובייקט מסוג לקוח
            Entities.Client c = new Entities.Client();
            c.IDClient = idClient;
            DataTable dt = c.GetDetails();
            gvClientDetails.DataSource = dt;
            gvClientDetails.DataBind();

        }

        protected void ViewCart()
        {
            //חשיפת העגלה 
            DataTable cartTable = (DataTable)Session["Cart"];

            //  הצמדת מקור הנתונים לגריד
            gvViewCart.DataSource = cartTable;

            // "שידוך" הנתונים למבנה הגריד
            gvViewCart.DataBind();

            // חישוב סכום העגלה: עלות פריט*מספר היחידות שהוזמנו
            decimal sum = 0;

            foreach (DataRow dr in cartTable.Rows)
                sum += decimal.Parse(dr["Price"].ToString()) * int.Parse(dr["NumOfUnits"].ToString());

            lblTotalSum.Text = sum.ToString();
        
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            //בדיקת כרטיס אשראי
           ProxyCreditCard.Card card = new ProxyCreditCard.Card();
            card.CardNum = txtCardNum.Text;
            card.TZ = txtTZ.Text;
            card.ExpireMonth = int.Parse(ddlMonth.SelectedValue);
            card.ExpireYear = int.Parse(ddlExpireYear.SelectedValue);
            card.IdCompany = int.Parse(ddlCompanies.SelectedValue);
            ProxyCreditCard.wsCreditCardService service = new ProxyCreditCard.wsCreditCardService();
            if (service.IsValidCard(card) == true)
            {
                ProxyCreditCard.Deal deal = new ProxyCreditCard.Deal();
                deal.CardNum = txtCardNum.Text;
                deal.DealDate = DateTime.Today;
                deal.TotalSum = decimal.Parse(lblTotalSum.Text);
                deal.IdSite = 4;
                int idDeal = service.InsertDeal(deal);
                Response.Write(idDeal);
                InsertOrder(idDeal);


            }
                
            else
                lblMsg.Text = "Not Valid Card";
        }
        public void InsertOrder(int idDeal)
        {
            Entities.Order o = new Entities.Order();
            o.idClient = int.Parse(Session["IDCLIENT"].ToString());
            o.idDeal = idDeal;
            o.totalsum = decimal.Parse(lblTotalSum.Text);
            int idOrder = o.Insert();
            //חשיפת העגלה 
            Entities.ShoppingBags product = new Entities.ShoppingBags();
            product.idOrder = idOrder;
            DataTable cartTable = (DataTable)Session["Cart"];
            foreach (DataRow dr in cartTable.Rows)
            {
                product.idProduct = int.Parse(dr["IdProduct"].ToString());
                product.unitPrice = decimal.Parse(dr["Price"].ToString());
                product.numOFUnits = int.Parse(dr["NumOfUnits"].ToString());
                product.Insert();
               
                Entities.Client c = new Entities.Client();
                c.SumOfBuying++;
            }
           
              
        }
        }
    }
