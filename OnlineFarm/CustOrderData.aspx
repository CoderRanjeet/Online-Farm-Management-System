<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CustOrderData.aspx.cs" Inherits="OnlineFarm.CustOrderData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row mt-5">
            <h5>
                <label class="col-form-label">Enter Email </label>
            </h5>
            <div class="col-md-6">
                <input type="text" class="form-control" id="txtemail" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:Button runat="server" CssClass="btn btn-success" Text="Get Data" ID="BtnGetData" OnClick="BtnGetData_Click" />
            </div>
        </div>


        <section class="section mt-4">
            <h3 class="card-title text-center">All Orders</h3>
            <div class="card mt-2">
                <asp:Repeater runat="server" ID="RptOrders">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Order Id</th>
                                    <th>Name</th>
                                    <th>Product</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>TotalPrice</th>
                                    <th>Order Status</th>
                                    <th>Order Date</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th><%#Eval("OrderId")%></th>
                                <th><%#Eval("Name")%></th>
                                <th><%#Eval("ProductName")%></th>
                                <th><%#Eval("Quantity")%></th>
                                <th><%#Eval("Price")%></th>
                                <th><%#Eval("TotalPrice")%></th>
                                <th><%#Eval("OrderStatus")%></th>
                                <th><%#Eval("CreatedDate")%></th>
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
