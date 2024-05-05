using OnlineFarm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineFarm
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnSignIn_ServerClick(object sender, EventArgs e)
        {
            var Email = txtEmail.Value;
            var password = txtPassword.Value;
            AdminMaster Am = AdminMaster.ValidateUser(Email);
            if(Email==Am.Email && Am.Password == password)
            {
                Response.Redirect("Dashboard.aspx?email={0}" +Email);
                //Server.Transfer("Dashboard.aspx?email={0}" + Email);
            }
            else
            {
                Response.Write("<script>alert('Email or Password wrong')</script>");
            }
        }
    }
}