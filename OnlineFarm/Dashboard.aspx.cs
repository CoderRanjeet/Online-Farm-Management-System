using OnlineFarm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineFarm
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(Request.QueryString["email"] != null || Session["email"]!=null)
                //{
                //    Session["email"] = Request.QueryString["email"].ToString();
                //    GetProducts();

                //}
                //else
                //{
                //    Response.Redirect("~/AdminLogin.aspx");
                //}
                GetProducts();
                GetOrders();

                lblTotalBilling.Text = BillingMaster.TotalBillingRecords().ToString();
                lblRevenue.Text = BillingMaster.TotalRevenue().ToString();
                lblOrders.Text = OrderMaster.TotalOrderRecords().ToString();
                lblProducts.Text = ProductMaster.TotalProducts().ToString();
            }
        }

        public void GetProducts()
        {
            DataTable dt = ProductMaster.GetProducts();
            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Take(5).CopyToDataTable();
                RptProducts.DataSource = dt;
                RptProducts.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }
        public void GetOrders()
        {
            DataTable dt = OrderMaster.GetOrders();
            if (dt.Rows.Count > 0)
            {
                dt = dt.AsEnumerable().Take(5).CopyToDataTable();
                RptOrders.DataSource = dt;
                RptOrders.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }
    }
}