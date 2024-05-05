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
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrders();
            }
        }
        public void GetOrders()
        {
            DataTable dt = OrderMaster.GetOrders();
            if (dt.Rows.Count > 0)
            {
                RptOrders.DataSource = dt;
                RptOrders.DataBind();
            }
            else
            {
                Response.Write("No Records Found");
            }
        }

        protected void RptOrders_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int BookId = Convert.ToInt32(e.CommandArgument.ToString());
                DropDownList selectList = e.Item.FindControl("ddlstatus") as DropDownList;
                var status = selectList.SelectedItem.Text;
                if (selectList.SelectedValue == "0")
                {
                    Response.Write("<script language='javascript'>alert('Please Select Status');</" + "script>");
                }
                else
                {
                    OrderMaster BM = new OrderMaster();
                    BM.OrderStatus = status;
                    BM.OrderId = BookId;
                    BM.Update();
                    GetOrders();
                }

            }
        }
    }
}