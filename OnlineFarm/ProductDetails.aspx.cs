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
    public partial class ProductDetails : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                int ProdId = Convert.ToInt32(Request.QueryString["ProductId"]);
                DataTable Data = ProductMaster.GetProduct(ProdId);
                RptProduct.DataSource = Data;
                RptProduct.DataBind();

                if (Session["Name"] != null)
                {
                    Session["Name"] = Session["Name"].ToString();
                }
                if (Session["Email"] != null)
                {
                    Session["Email"] = Session["Email"].ToString();
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }


        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }

        protected void RptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string Product = commandArgs[0];
                string Price = commandArgs[1];
                string ProductImage = commandArgs[2];

                if (Product != null || Product != "")
                {
                    ProductMaster pm = ProductMaster.GetQty(Product);
                    if ( pm.Qty <= 0)
                    {
                        ShowMessage("Oops ? Product Out Of Stock", "please select Another Book ", MessageType.warning);
                    }
                }
                // string BuyData = BookImage +"," + Price +"," +  BookName;

                DataTable dt = new DataTable();
                if (Session["data"] != null)
                {
                    dt = (DataTable)Session["data"];
                    DataRow dr = null;
                    if (dt.Rows.Count > 0)
                    {
                        DataRow[] r = dt.Select("Product='" + Product + "'");
                        if (r.Count() >= 1)
                        {
                            Response.Redirect("Cart.aspx");
                        }
                        dr = dt.NewRow();
                        dr["Product"] = Product;
                        dr["ProductImg"] = ProductImage;
                        dr["Price"] = Price;
                        dr["TotalPrice"] = (Convert.ToDecimal(Price) * 5).ToString();
                        dr["Qty"] = 5;
                        dt.Rows.Add(dr);
                        Session["data"] = dt;
                    }
                }
                else
                {
                    dt.Columns.Add("Product", typeof(string));
                    dt.Columns.Add("ProductImg", typeof(string));
                    dt.Columns.Add("Price", typeof(decimal));
                    dt.Columns.Add("Qty", typeof(string));
                    dt.Columns.Add("TotalPrice", typeof(decimal));
                    DataRow dr1 = dt.NewRow();
                    dr1 = dt.NewRow();
                    dr1["Product"] = Product;
                    dr1["ProductImg"] = ProductImage;
                    dr1["Price"] = Price;
                    dr1["TotalPrice"] = (Convert.ToDecimal(Price) * 5).ToString();
                    dr1["Qty"] = 5;
                    dt.Rows.Add(dr1);
                    Session["data"] = dt;
                }

                if (Session["data"] != null)
                {
                    Response.Redirect("Cart.aspx");
                }
            }

            if (e.CommandName == "AddToCart")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string Product = commandArgs[0];
                string Price = commandArgs[1];
                string ProductImg = commandArgs[2];
                // string BuyData = BookImage +"," + Price +"," +  BookName;

                if (Product != null || Product != "")
                {
                    ProductMaster pm = ProductMaster.GetQty(Product);
                    if (pm.Qty <= 0)
                    {
                        ShowMessage("Oops ? Product Out Of Stock", "please select Another Book ", MessageType.warning);
                    }
                }

                DataTable dt = new DataTable();
                if (Session["data"] != null)
                {
                    dt = (DataTable)Session["data"];
                    DataRow dr = null;
                    if (dt.Rows.Count > 0)
                    {
                        DataRow[] r = dt.Select("Product='" + Product + "'");
                        if (r.Count() >= 1)
                        {
                            ShowMessage("Oops ? Book Already Added to Cart", "please select Another Book ", MessageType.warning);
                            // Response.Write("<script>alert('" + "Book Already Added to Cart, please select Another Book." + "');</script>");
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr["Product"] = Product;
                            dr["ProductImg"] = ProductImg;
                            dr["Price"] = Price;
                            dr["TotalPrice"] = (Convert.ToDecimal(Price) * 5).ToString();
                            dr["Qty"] = 5;
                            dt.Rows.Add(dr);
                            Session["data"] = dt;

                            ShowMessage(Product + "  Book  ", "  Added Successfully", MessageType.success);
                        }
                    }
                }
                else if (dt.Rows.Count <= 0)
                {
                    dt.Columns.Add("Product", typeof(string));
                    dt.Columns.Add("ProductImg", typeof(string));
                    dt.Columns.Add("Price", typeof(string));
                    dt.Columns.Add("Qty", typeof(string));
                    dt.Columns.Add("TotalPrice", typeof(string));
                    DataRow dr1 = dt.NewRow();
                    dr1 = dt.NewRow();
                    dr1["Product"] = Product;
                    dr1["ProductImg"] = ProductImg;
                    dr1["Price"] = Price;
                    dr1["TotalPrice"] = (Convert.ToDecimal(Price) * 5).ToString();
                    dr1["Qty"] = 5;
                    dt.Rows.Add(dr1);
                    Session["data"] = dt;

                    ShowMessage(Product + "  Book  ", " Added Successfully", MessageType.success);
                }

                Response.Redirect("ShoppingStore.aspx");
            }
        }
    }
}