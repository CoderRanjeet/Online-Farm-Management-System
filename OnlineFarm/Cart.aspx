<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="OnlineFarm.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="h-100" style="background-color: #eee;">
        <div class="container h-100 py-5">
            
            <asp:Label runat="server" ID="lblmsg" Visible="false"></asp:Label>

            <div class="row d-flex justify-content-center align-items-center h-100" runat="server" id="DivCart" visible="true">
                <div class="col-12">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h2 class="fw-normal mb-0 text-muted font-weight-bold text-center">Shopping Cart</h2>

                        <div>
                            <p class="mb-0">
                                <span class="text-muted">Sort by:</span> <a href="#!" class="text-body">price <i
                                    class="fas fa-angle-down mt-1"></i></a>
                            </p>
                        </div>
                    </div>

                    <div class="row d-flex justify-content-between align-items-center">
                        <p>Product </p>
                        <p>Product Name</p>
                        <p>Quantity</p>
                        <p>Price</p>
                        <p>Total</p>
                        <p>Action</p>
                    </div>

                    <asp:Repeater runat="server" ID="RptCart" OnItemCommand="RptCart_ItemCommand">
                        <ItemTemplate>
                            <div class="card rounded-3 mb-4">
                                <div class="card-body p-4">
                                    <div class="row d-flex justify-content-between align-items-center">

                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <img src='<%# Eval("ProductImg") %>' class="img-fluid rounded-3">
                                        </div>
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <p class="lead fw-normal mb-2"><%# Eval("Product") %></p>
                                        </div>

                                        <div class="col-md-2 col-lg-2 col-xl-2 d-flex">

                                            <asp:LinkButton runat="server" class="btn-primary btn-sm" CommandArgument='<%# Eval("Product") %>' CommandName="BtnMinus">-</asp:LinkButton>

                                            <input id="txtQty" runat="server" value='<%# Eval("Qty") %>' type="text" readonly="readonly" class="form-control w-50" />

                                            <asp:LinkButton runat="server" class="btn-primary btn-sm" CommandArgument='<%# Eval("Product") %>' CommandName="BtnPlus">+</asp:LinkButton>

                                        </div>
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <h5 class="mb-0"><%# Eval("Price") %></h5>
                                        </div>
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <h5 class="mb-0"><%# Eval("TotalPrice") %></h5>
                                        </div>
                                        <div class="col-md-2 col-lg-2 col-xl-2 text-end">
                                            <asp:LinkButton runat="server" class="btn btn-danger" CommandArgument='<%# Eval("Product") %>' CommandName="BtnDelete">Delete</asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="card">
                        <div class="card-body">
                              <h4 class="Form-Group mb-4 text-center">Billing Details</h4>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <asp:Label ID="Label3" CssClass="col-md-4" runat="server" Text="Total"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtTotal" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <asp:Label ID="Label1" CssClass="col-md-4" runat="server" Text="Final Amount"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtFinalAmt" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 offset-2">
                                     <div class="form-group row">
                                        <asp:Label ID="Label2" CssClass="col-md-4" runat="server" Text="Discount"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:Label runat="server" ID="txtDiscount" Text="10">10</asp:Label><span>%</span>
                                           <%-- <asp:TextBox ID="" Enabled="false" Text="10%" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        </div>
                                    </div>

                                    <button type="button" class="btn btn-warning float-right w-50 text-white mt-5" style="font-size:18px;" runat="server" id="BtnProceed" onserverclick="BtnProceed_ServerClick">Proceed to Order</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
