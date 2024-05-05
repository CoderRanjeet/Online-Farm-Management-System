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
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable Dt = ProductMaster.GetProducts();
                RptProducts.DataSource = Dt;
                RptProducts.DataBind();

                DataTable dt = CategoryMaster.GetCategories();
                ddlcategory.DataSource = dt;
                ddlcategory.DataTextField = "Category";
                ddlcategory.DataValueField = "Category";
                ddlcategory.DataBind();
                ddlcategory.Items.Insert(0, new ListItem("-- Select Category --", string.Empty));
            }
        }

        protected void RptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                var ProdId = e.CommandArgument.ToString();
                Response.Redirect(string.Format("~/ProductDetails.aspx?ProductId={0}", ProdId));
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var category = ddlcategory.SelectedValue;
            if (category != null && category != "0" && category !="")
            {
                DataTable Dt = ProductMaster.GetCategories(category);
                if (Dt.Rows.Count > 0)
                {
                    RptProducts.DataSource = Dt;
                    RptProducts.DataBind();
                    lblMsg.Visible = false;
                    lblMsg.Text = "";
                }
                else
                {
                    RptProducts.DataSource = Dt;
                    RptProducts.DataBind();
                    lblMsg.Visible = true;
                    lblMsg.Text = "No Data Present for " + category;
                }
            }
            else if (category == "0" || category == "")
            {
                DataTable Dt = ProductMaster.GetProducts();
                RptProducts.DataSource = Dt;
                RptProducts.DataBind();
                lblMsg.Visible = false;
                lblMsg.Text = "";
            }
        }
    }
}