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
    public partial class CheckOut : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void BtnOrder_Click1(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                CustomerMaster CM = new CustomerMaster();
                CM.Name = txtname.Text;
                CM.Email = txtemail.Text;
                CM.Address = txtaddress.Text;
                CM.AltMobileNo = txtAltMobileNo.Text;
                CM.BuildingNo = txtHouse.Text;
                CM.City = txtcity.Text;
                CM.CreatedDate = DateTime.Now;
                CM.MobileNo = txtphone.Text;
                CM.State = txtstate.Text;
                CM.ZipCode = txtzipcode.Text;
                CM.Add();

                if (CM.CustomerId > 0)
                {
                    string orderIds = string.Empty;
                    if (Session["data"] != null)
                    {
                        DataTable data = (DataTable)Session["data"];

                        foreach (DataRow row in data.Rows)
                        {
                            var daa = row.ItemArray[0].ToString();
                            OrderMaster orders = new OrderMaster
                            {
                                ProductName = row.ItemArray[0].ToString(),
                                Quantity = Convert.ToInt32(row.ItemArray[3]),
                                Price = Convert.ToDecimal(row.ItemArray[2]),
                                TotalPrice = Convert.ToDecimal(row.ItemArray[4]),
                                CustomerId = Convert.ToInt32(CM.CustomerId),
                                CreatedDate = DateTime.Now,
                                OrderStatus = "Processing"
                            };
                            orders.Add();
                            orderIds += orders.OrderId;

                            if(row.ItemArray[0].ToString() !=null || row.ItemArray[0].ToString() != "")
                            {
                                var product = row.ItemArray[0].ToString();
                                ProductMaster pm = ProductMaster.GetQty(product);
                                var qty = pm.Qty - Convert.ToInt32(row.ItemArray[3]);
                                pm.Qty = qty;
                                pm.UpdateQty();
                            }
                        }
                    }
                    if(Session["BillData"] != null)
                    {
                        DataTable data = (DataTable)Session["BillData"];

                        foreach (DataRow row in data.Rows)
                        {
                            BillingMaster BM = new BillingMaster
                            {
                                Total = Convert.ToDecimal(row.ItemArray[0]),
                                Discount = Convert.ToDecimal(row.ItemArray[1]),
                                FinalAmt = Convert.ToDecimal(row.ItemArray[2]),
                                OrderId = orderIds,
                                CustomerId = Convert.ToInt32(CM.CustomerId),
                                CreatedDate = DateTime.Now
                            };
                            BM.Add();
                        }
                    }
                    Clear();
                    Response.Redirect("~/OrderMsg.aspx");
                }
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        public void Clear()
        {
            txtname.Text = "";
            txtaddress.Text = "";
            txtAltMobileNo.Text = "";
            txtcity.Text = "";
            txtemail.Text = "";
            txtHouse.Text = "";
            txtphone.Text = "";
            txtstate.Text = "";
            txtzipcode.Text = "";
        }
        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtname.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Name", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Email", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtphone.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Mobile Number", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtaddress.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Address", MessageType.info);
                return msg;
            }
            return msg;
        }



        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            divupi.Visible = true;
            divpaymentcard.Visible = false;
            CheckBox2.Checked = false;
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //lblAmount.Text = lblTotalAmt.Text;
            divpaymentcard.Visible = true;
            divupi.Visible = false;
            CheckBox3.Checked = false;
        }

        protected void BtnUpiPayment_ServerClick(object sender, EventArgs e)
        {
            ShowMessage("oops?", "UPI option Available soon.....", MessageType.info);
            CheckBox2.Checked = false;
            divupi.Visible = false;
        }

        protected void BtnCardPayment_ServerClick(object sender, EventArgs e)
        {
            ShowMessage("oops?", "Credit card/ Debit card payment option Available soon.....", MessageType.info);
            CheckBox3.Checked = false;
            divpaymentcard.Visible = false;
        }
    }
}