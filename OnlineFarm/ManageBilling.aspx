<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer.Master" AutoEventWireup="true" CodeBehind="ManageBilling.aspx.cs" Inherits="OnlineFarm.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <section class="section mt-4">
        <h3 class="card-title text-center">All Billings</h3>
        <div class="card mt-2">
            <asp:Repeater runat="server" ID="RptOrders">
                <HeaderTemplate>
                    <table class="table table-bordered table-striped table-responsive">
                        <thead>
                            <tr>
                                <th>Billing Id</th>
                                <th>Order Id</th>
                                <th>Name</th>
                                <th>Total</th>
                                <th>Discount</th>
                                <th>Total Amount</th>
                                <th>Order Date</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <th><%#Eval("BillingId")%></th>
                            <th><%#Eval("OrderId")%></th>
                            <th><%#Eval("Name")%></th>
                            <th><%#Eval("Total")%></th>
                            <th><%#Eval("Discount")%></th>
                            <th><%#Eval("FinalAmt")%></th>
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
