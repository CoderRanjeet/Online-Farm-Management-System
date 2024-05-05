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
    public partial class CustOrderData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }
        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            var email = txtemail.Value;
            GetData(email);
        }
        public void GetData(string email)
        {
            DataTable dt = OrderMaster.GetOrders(email);
            if (dt.Rows.Count > 0)
            {
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