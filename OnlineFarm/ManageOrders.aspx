<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="OnlineFarm.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <section class="section mt-4">
            <h3 class="card-title text-center">All Orders</h3>
            <div class="card mt-2">
                <asp:Repeater runat="server" ID="RptOrders" OnItemCommand="RptOrders_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped table-responsive">
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
                                    <th>Change Status</th>
                                    <th>Action</th>
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
                                <td>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlstatus">
                                        <asp:ListItem  Value="0">-- Select Status --</asp:ListItem>
                                        <asp:ListItem Text="Cancelled">Cancel</asp:ListItem>
                                        <asp:ListItem Text="Shipped">Shipped</asp:ListItem>
                                        <asp:ListItem Text="Delivered">Delivered</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:LinkButton runat="server" class="btn btn-success" CommandArgument='<%# Eval("OrderId") %>' ID="BtnBookStatus" CommandName="View" Text="Change"></asp:LinkButton>
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
