<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="OnlineFarm.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid pt-4 px-4">
        <h3 class="mb-2 text-center">Manage Products</h3>
            <div class="card">
                <div class="card-body">
                    <div class="row g-3  mb-1 mt-1">
                        <div class="col-lg-6">
                            <div class="col-12">
                                <label class="form-label">Category</label>
                                <asp:DropDownList runat="server" ID="ddlCategories" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-12 mt-2">
                                <label class="form-label">Product Title</label>
                                <input type="text" runat="server" class="form-control" id="txtProductTitle">
                            </div>
                            <div class="col-12 mt-2">
                                <label class="form-label">Product Image</label>
                                <input type="file" runat="server" class="form-control" id="txtProductImg">
                                <asp:Image ID="Image1" runat="server" Width="100" />
                            </div>

                             <div class="col-12 mt-2">
                                <label class="form-label">Discount</label>
                                <input type="text" runat="server" class="form-control" id="txtDiscount">
                            </div>

                        </div>

                        <div class="col-lg-6">
                            <div class="col-12">
                                <label class="form-label">Price</label>
                                <input type="text" runat="server" class="form-control" id="txtPrice">
                            </div>

                            <div class="col-12 mt-2">
                                <label class="form-label">Quantity</label>
                                <input type="text" runat="server" class="form-control" id="txtQty">
                            </div>

                              <div class="col-12 mt-2">
                                <label class="form-label">Description</label>
                                <input type="text" runat="server" class="form-control" id="txtDescription">
                            </div>

                             <div class="col-12 mt-4">
                                <label class="form-label">Select Unit</label>   
                                 <asp:DropDownList runat="server" CssClass="form-control" ID="ddlUnit">
                                     <asp:ListItem Value="0">-- select Unit --</asp:ListItem>
                                      <asp:ListItem Value="Kg"></asp:ListItem>
                                      <asp:ListItem Value="Dozen"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="text-center  mb-3 mt-1">
                    <button type="submit" class="btn btn-primary" runat="server" id="BtnSubmit" onserverclick="BtnSubmit_ServerClick">Submit</button>
                    <button type="reset" class="btn btn-secondary" runat="server" id="BtnReset" onserverclick="BtnReset_ServerClick">Reset</button>
                </div>
            </div>

   
        <section class="section mt-4">
            <h3 class="card-title text-center">All Products</h3>
            <div class="card mt-2">
                <asp:Repeater runat="server" ID="RptProducts" OnItemCommand="RptProducts_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped table-responsive">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Image</th>
                                    <th>Category</th>
                                    <th>Discount</th>
                                    <th>Product</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th><%#Eval("ProductId")%></th>
                                <td><img src='<%#Eval("ProductImg")%>' width="80" /></td>
                                <th><%#Eval("Category")%></th>
                                <th><%#Eval("Discount")%></th>
                                <th><%#Eval("Product")%></th>
                                <th><%#Eval("Price")%> <span>Per <%#Eval("Unit")%></span></th>
                                <th><%#Eval("Qty")%></th>
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("ProductId")%>'>Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("ProductId")%>'>Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </section>
    </div>
</asp:Content>
