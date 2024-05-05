<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineFarm.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Sale & Revenue Start -->
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                    <i class="fa fa-chart-line fa-3x text-primary"></i>
                    <div class="ms-3">
                        <p class="mb-2">Total Billing</p>
                        <h6 class="mb-0"><asp:Label runat="server" ID="lblTotalBilling"></asp:Label></h6>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                    <i class="fa fa-chart-bar fa-3x text-primary"></i>
                    <div class="ms-3">
                        <p class="mb-2">Total Revenue</p>
                        <h6 class="mb-0"><asp:Label runat="server" ID="lblRevenue"></asp:Label></h6>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                    <i class="fa fa-chart-area fa-3x text-primary"></i>
                    <div class="ms-3">
                        <p class="mb-2">Total Orders</p>
                        <h6 class="mb-0"><asp:Label runat="server" ID="lblOrders"></asp:Label></h6>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                    <i class="fa fa-chart-pie fa-3x text-primary"></i>
                    <div class="ms-3">
                        <p class="mb-2">Total Products</p>
                        <h6 class="mb-0"><asp:Label runat="server" ID="lblProducts"></asp:Label></h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Sale & Revenue End -->

    <div class="container-fluid pt-4 px-4">
        <div class="bg-light text-center rounded p-4">
            <div class="d-flex align-items-center justify-content-between mb-4">
                <h6 class="mb-0">Recent Added Products</h6>
                <a href="#">Show All</a>
            </div>
            <div class="table-responsive">
                <asp:Repeater runat="server" ID="RptProducts">
                    <HeaderTemplate>
                        <table class="table text-start align-middle table-bordered table-hover mb-0">
                            <thead>
                                <tr class="text-dark">
                                    <th scope="col">Sr.No</th>
                                    <th scope="col">Image</th>
                                    <th scope="col">Category</th>
                                    <th scope="col">Product</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">Quantity</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("ProductId")%></td>
                                <td><img src='<%#Eval("ProductImg")%>' width="80" /></td>
                                <td><%#Eval("Category")%></th>
                                <td><%#Eval("Product")%></th>
                                <td><%#Eval("Price")%></th>
                                <td><%#Eval("Qty")%></th>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


    <!-- Recent Sales Start -->
    <div class="container-fluid pt-4 px-4">
        <div class="bg-light text-center rounded p-4">
            <div class="d-flex align-items-center justify-content-between mb-4">
                <h6 class="mb-0">Recent Orders</h6>
                <a href="#">Show All</a>
            </div>
            <div class="table-responsive">
                <asp:Repeater runat="server" ID="RptOrders">
                    <HeaderTemplate>
                        <table class="table text-start align-middle table-bordered table-hover mb-0">
                            <thead>
                                <tr class="text-dark">
                                     <th scope="col">Order Id</th>   
                                    <th scope="col">Product</th>    
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">TotalPrice</th>
                                    <th scope="col">Order Status</th>
                                    <th scope="col">Order Date</th>
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
        </div>
    </div>
    <!-- Recent Sales End -->


</asp:Content>
