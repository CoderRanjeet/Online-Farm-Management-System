using OnlineFarm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineFarm
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnSignUp_ServerClick(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                AdminMaster AM = new AdminMaster();
                AM.Name = txtName.Value;
                AM.Email = txtemail.Text;
                AM.MobileNo = txtmobileNo.Text;
                AM.Password = txtPassword.Value;
                AM.CreatedDate = DateTime.Now;
                AM.Add();
                Clear();
            }
        }
        public bool ValidateFields()
        {
            bool msg = true;

            if (string.IsNullOrEmpty(txtName.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Name", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtmobileNo.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Mobile number", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Email", MessageType.info);
                return msg;
            }

            if (string.IsNullOrEmpty(txtPassword.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Password", MessageType.info);
                return msg;
            }
           
            return msg;
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        public void Clear()
        {
            txtName.Value = "";
            txtPassword.Value = "";
            txtmobileNo.Text = "";
            txtemail.Text = "";
        }
    }
}