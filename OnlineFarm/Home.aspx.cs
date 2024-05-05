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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable Dt = ProductMaster.GetProducts();
                RptProducts.DataSource = Dt;
                RptProducts.DataBind();
            }
        }

        protected void RptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                var ProductId = e.CommandArgument.ToString();
                Response.Redirect(string.Format("~/ProductDetails.aspx?ProductId={0}", ProductId));
            }
        }
    }
}