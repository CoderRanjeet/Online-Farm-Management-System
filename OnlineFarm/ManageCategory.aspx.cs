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
    public partial class ManageCategory : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (txtCategory.Value == "")
            {
                ShowMessage("oops?", "Please Enter Category", MessageType.info);
                return;
            }
            if (Session["Id"] != null)
            {
                int Id = Convert.ToInt32(Session["Id"]);

                CategoryMaster BMP = new CategoryMaster
                {
                    CatId = Id,
                    Category = txtCategory.Value,
                    CreatedDate = DateTime.Now
                };
                BMP.Update();
                GetCategories();
                Clear();
                BtnSubmit.InnerText = "Submit";
                Session["Id"] = null;
                Session.Remove("Id");
            }
            else
            {
                CategoryMaster BM = new CategoryMaster
                {
                    Category = txtCategory.Value,
                    CreatedDate = DateTime.Now
                };
                BM.Add();
                Clear();
                GetCategories();
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        public void Clear()
        {
            txtCategory.Value = "";
        }

        public void GetCategories()
        {
            DataTable dt = CategoryMaster.GetCategories();
            if (dt.Rows.Count > 0)
            {
                RptCategories.DataSource = dt;
                RptCategories.DataBind();
            }
            else
            {
                Response.Write("No Records Found");
            }
        }

        protected void RptCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Id = Convert.ToInt32(e.CommandArgument);
                if (Id != null)
                {
                    CategoryMaster edit = CategoryMaster.GetCategory(Id);
                    if (edit != null)
                    {
                        txtCategory.Value = edit.Category.ToString();
                        BtnSubmit.InnerText = "Update";

                        Session["Id"] = Id;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                var Id = Convert.ToInt32(e.CommandArgument);

                if (Id != null)
                {
                    CategoryMaster del = new CategoryMaster();
                    bool IsDeleted = del.Delete(Id);
                    if (IsDeleted)
                    {
                        Response.Write("<script>alert('Deleted SuccessFully.');</script>");
                        GetCategories();
                    }
                }
            }
        }
    }
}