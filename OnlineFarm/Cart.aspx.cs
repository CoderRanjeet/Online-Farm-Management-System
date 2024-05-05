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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["data"] != null)
                {
                    DataTable dt = (DataTable)Session["data"];
                    RptCart.DataSource = dt;
                    RptCart.DataBind();

                    if (dt.Rows.Count <= 0)
                    {
                        DivCart.Visible = false;
                        lblmsg.Visible = true;
                        lblmsg.Text = "No Data Present.";
                    }
                    else
                    {
                        txtTotal.Text = dt.AsEnumerable().Sum(rw => Convert.ToDecimal(rw["TotalPrice"])).ToString();
                        decimal Discount = (Convert.ToDecimal(txtTotal.Text) * 10 / 100);
                        txtFinalAmt.Text = (Convert.ToDecimal(txtTotal.Text) - Discount).ToString();
                    }

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
                    //Response.Redirect("Dashboard.aspx");
                    DivCart.Visible = false;
                    lblmsg.Visible = true;
                    lblmsg.Text = "No Data Present.";
                }
            }
        }

        protected void RptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BtnMinus")
            {
                var Product = e.CommandArgument.ToString();

                DataTable dt = (DataTable)Session["data"];
                DataRow[] r = dt.Select("Product='" + Product + "'");
                if (r.Count() > 1)
                {
                    dt.Rows.RemoveAt(1);
                    dt.AcceptChanges();
                }
                foreach (DataRow rr in r)
                {
                   rr["Qty"] = Convert.ToInt32(rr["Qty"]) - 5;
                   if (Convert.ToInt32(rr["Qty"]) <= 1)
                   {
                       Response.Write("<script>alert('" + "Quantity Cannot be Zero, you can remove your product." + "');</script>");
                        return;
                   }
                   rr["TotalPrice"] = Convert.ToInt32(rr["Qty"]) * Convert.ToDecimal(rr["Price"]);
                   dt.AcceptChanges();
                }

                txtTotal.Text = dt.AsEnumerable().Sum(rw => Convert.ToDecimal(rw["TotalPrice"])).ToString();
                decimal Discount = (Convert.ToDecimal(txtTotal.Text) * 10 / 100);
                txtFinalAmt.Text = (Convert.ToDecimal(txtTotal.Text) - Discount).ToString();

                DataTable BillingData = new DataTable();
                DataRow drData = null;
                BillingData.Columns.Add("Total", typeof(decimal));
                BillingData.Columns.Add("Discount", typeof(decimal));
                BillingData.Columns.Add("FinalAmt", typeof(decimal));
                drData = BillingData.NewRow();
                drData["Total"] = txtTotal.Text;
                drData["Discount"] = txtDiscount.Text;
                drData["FinalAmt"] = txtFinalAmt.Text;
                BillingData.Rows.Add(drData);
                Session["BillData"] = BillingData;

                Session["data"] = dt;
                RptCart.DataSource = dt;
                RptCart.DataBind();
            }
            if (e.CommandName == "BtnPlus")
            {
                var Product = e.CommandArgument.ToString();

                DataTable dt = (DataTable)Session["data"];

                DataRow[] r = dt.Select("Product='" + Product + "'");
                if (r.Count() > 1)
                {
                    dt.Rows.RemoveAt(1);
                    dt.AcceptChanges();
                }
                foreach (DataRow rr in r)
                {
                    if (Product != null || Product != "")
                    {
                        ProductMaster pm = ProductMaster.GetQty(Product);
                        if (pm.Qty <= 0 || pm.Qty < (Convert.ToInt32(rr["Qty"]) + 1))
                        {
                            Response.Write("<script>alert('" + "Stock Not Available." + "');</script>");
                            return;
                        }
                    }

                    rr["Qty"] = Convert.ToInt32(rr["Qty"]) + 5;

                    if (Convert.ToInt64(rr["Qty"]) > 50)
                    {
                        Response.Write("<script>alert('" + "Quantity cannot be more that 50kg." + "');</script>");
                        return;
                    }

                    rr["TotalPrice"] = Convert.ToInt32(rr["Qty"]) * Convert.ToDecimal(rr["Price"]);
                }
                dt.AcceptChanges();
             
                txtTotal.Text = dt.AsEnumerable().Sum(rw => Convert.ToDecimal(rw["TotalPrice"])).ToString();
                decimal Discount = (Convert.ToDecimal(txtTotal.Text) * 10 / 100);
                txtFinalAmt.Text = (Convert.ToDecimal(txtTotal.Text) - Discount).ToString();

                DataTable BillingData = new DataTable();
                DataRow drData = null;
                BillingData.Columns.Add("Total", typeof(decimal));
                BillingData.Columns.Add("Discount", typeof(decimal));
                BillingData.Columns.Add("FinalAmt", typeof(decimal));
                drData = BillingData.NewRow();
                drData["Total"] = txtTotal.Text;
                drData["Discount"] = txtDiscount.Text;
                drData["FinalAmt"] = txtFinalAmt.Text;
                BillingData.Rows.Add(drData);
                Session["BillData"] = BillingData;

                Session["data"] = dt;
                RptCart.DataSource = dt;
                RptCart.DataBind();
            }

            if (e.CommandName == "BtnDelete")
            {
                var Product = e.CommandArgument.ToString();

                DataTable dt = (DataTable)Session["data"];

                //  DataRow[] r = dt.Select("BookName='" + bookname + "'");
                DataRow rowToDelete = dt.AsEnumerable()
                                   .FirstOrDefault(row => row.Field<string>("Product").Contains(Product));
                if (rowToDelete != null)
                {
                    dt.Rows.Remove(rowToDelete);
                }

                dt.AcceptChanges();

                if (dt.Rows.Count == 0)
                {
                    Session["data"] = null;
                    Response.Redirect("ShoppingStore.aspx");
                }

                txtTotal.Text = dt.AsEnumerable().Sum(rw => Convert.ToDecimal(rw["TotalPrice"])).ToString();
                decimal Discount = (Convert.ToDecimal(txtTotal.Text) * 10 / 100);
                txtFinalAmt.Text = (Convert.ToDecimal(txtTotal.Text) - Discount).ToString();

                DataTable BillingData = new DataTable();
                DataRow drData = null;
                BillingData.Columns.Add("Total", typeof(decimal));
                BillingData.Columns.Add("Discount", typeof(decimal));
                BillingData.Columns.Add("FinalAmt", typeof(decimal));
                drData = BillingData.NewRow();
                drData["Total"] = txtTotal.Text;
                drData["Discount"] = txtDiscount.Text;
                drData["FinalAmt"] = txtFinalAmt.Text;
                BillingData.Rows.Add(drData);
                Session["BillData"] = BillingData;

                Session["data"] = dt;
                RptCart.DataSource = dt;
                RptCart.DataBind();
            }
        }

        protected void BtnProceed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }
    }
}