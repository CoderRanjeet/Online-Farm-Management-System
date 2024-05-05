using OnlineFarm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineFarm
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProducts();
                DataTable dt = CategoryMaster.GetCategories();
                ddlCategories.DataSource = dt;
                ddlCategories.DataTextField = "Category";
                ddlCategories.DataValueField = "CatId";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("-- Select Category --", string.Empty));
            }
        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (Session["Id"] != null)
                {
                    int Id = Convert.ToInt32(Session["Id"]);

                    try
                    {
                        ProductMaster PM = new ProductMaster();
                        PM.ProductId = Id;
                        PM.Product = txtProductTitle.Value;
                        PM.Category = ddlCategories.SelectedItem.Text;
                        PM.Price = Convert.ToDecimal(txtPrice.Value);
                        PM.Qty = Convert.ToInt32(txtQty.Value);
                        PM.CreatedDate = DateTime.Now;
                        PM.IsActive = true;
                        PM.Description = txtDescription.Value;
                        PM.Discount = Convert.ToDecimal(txtDiscount.Value);
                        PM.Unit = ddlUnit.SelectedValue;
                        var filename = (txtProductImg.PostedFile.FileName);
                        if (!string.IsNullOrEmpty(filename))
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                            txtProductImg.PostedFile.SaveAs(path);
                            var image = "Images/" + filename;
                            PM.ProductImg = image;
                        }
                        else if(Image1.ImageUrl.Length > 0)
                        {
                            PM.ProductImg = Image1.ImageUrl;
                        }

                        PM.Update();
                        GetProducts();
                        Clear();
                        BtnSubmit.InnerText = "Submit";
                        Session["Id"] = null;
                        Session.Remove("Id");
                    }
                    catch (Exception Ex)
                    {
                        ShowMessage("oops?", Ex.Message, MessageType.info);
                    }
                }
                else
                {
                    try
                    {
                        ProductMaster PM = new ProductMaster();
                        PM.Product = txtProductTitle.Value;
                        PM.Category = ddlCategories.SelectedItem.Text;
                        PM.Price = Convert.ToDecimal(txtPrice.Value);
                        PM.Qty = Convert.ToInt32(txtQty.Value);
                        PM.CreatedDate = DateTime.Now;
                        PM.IsActive = true;
                        PM.Description = txtDescription.Value;
                        PM.Discount = Convert.ToDecimal(txtDiscount.Value);
                        PM.Unit =ddlUnit.SelectedValue;

                        if (string.IsNullOrEmpty(txtProductImg.Value))
                        {
                            ShowMessage("oops?", "Please Upload Product Image", MessageType.info);
                        }
                        else
                        {
                            var filename = (txtProductImg.PostedFile.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                            txtProductImg.PostedFile.SaveAs(path);
                            var image = "Images/" + filename;
                            PM.ProductImg = image;

                            PM.Add();
                            GetProducts();
                            Clear();
                        }
                    }
                    catch (Exception Ex)
                    {

                    }
                }
            }
        }

        protected void BtnReset_ServerClick(object sender, EventArgs e)
        {
            Clear();
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }
        public void Clear()
        {
            txtPrice.Value = "";
            txtQty.Value = "";
            txtProductTitle.Value = "";
            ddlCategories.SelectedIndex = 0;
            Image1.ImageUrl = "";
            txtDescription.Value = "";
            txtDiscount.Value = "";
            ddlUnit.SelectedIndex = 0;
        }
        public bool ValidateFields()
        {
            bool msg = true;

            if (ddlCategories.SelectedValue == "0" || ddlCategories.SelectedValue == "")
            {
                msg = false;
                ShowMessage("oops?", "Please select Category", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtQty.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Qty", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtProductTitle.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Product Title", MessageType.info);
                return msg;
            }
            if (string.IsNullOrEmpty(txtPrice.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Price", MessageType.info);
                return msg;
            }
           
            if (string.IsNullOrEmpty(txtDescription.Value))
            {
                msg = false;
                ShowMessage("oops?", "Please Enter Description", MessageType.info);
                return msg;
            }
            if (ddlUnit.SelectedValue =="0")
            {
                msg = false;
                ShowMessage("oops?", "Please select Unit", MessageType.info);
                return msg;
            }
            return msg;
        }

        public void GetProducts()
        {
            DataTable dt = ProductMaster.GetProducts();
            if (dt.Rows.Count > 0)
            {
                RptProducts.DataSource = dt;
                RptProducts.DataBind();
            }
            else
            {
                Response.Write("No Record Found.");
            }
        }

        protected void RptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Id = e.CommandArgument.ToString();
                if (Id != null)
                {
                    DataTable dt = CategoryMaster.GetCategories();
                    ddlCategories.DataSource = dt;
                    ddlCategories.DataTextField = "Category";
                    ddlCategories.DataValueField = "CatId";
                    ddlCategories.DataBind();
                    ddlCategories.Items.Insert(0, new ListItem("-- Select Category --", string.Empty));

                    ProductMaster edit = ProductMaster.GetProductInfo(Id);
                    if (edit != null)
                    {
                        txtPrice.Value = edit.Price.ToString();
                        txtProductTitle.Value = edit.Product;
                        //ddlCategories.SelectedValue = edit.Category;
                        txtQty.Value = edit.Qty.ToString();
                        Image1.ImageUrl = edit.ProductImg;
                        txtDiscount.Value = edit.Discount.ToString();
                        txtDescription.Value = edit.Description;

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
                    ProductMaster del = new ProductMaster();
                    bool IsDeleted = del.Delete(Id);
                    if (IsDeleted)
                    {
                        Response.Write("<script>alert('Deleted SuccessFully.');</script>");
                        GetProducts();
                    }
                }
            }
        }
    }
}