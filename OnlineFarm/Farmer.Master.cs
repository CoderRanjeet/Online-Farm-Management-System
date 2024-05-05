using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineFarm
{
    public partial class Farmer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["email"] != null)
                //{
                //    Session["email"] = Request.QueryString["email"].ToString();
                //}
                //else
                //{
                //    Response.Redirect("~/AdminLogin.aspx");
                //}
            }
        }

        protected void BtnLogOut_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }
}