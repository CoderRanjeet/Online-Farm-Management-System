<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="OnlineFarm.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <style>
        .bgImgCenter{
    background-image: url('images1/car_bg_image.jpg');
    background-repeat: no-repeat;
    background-position: center; 
    position: relative;
}
    </style>--%>

    <%--<div class="bgImgCenter">--%>
     <asp:Repeater runat="server" ID="RptProduct" OnItemCommand="RptProduct_ItemCommand">
        <ItemTemplate>
            <div class="col-md-4 mb-4 offset-3">
                <div class="card h-100 border-0">
                    <img src='<%# Eval("ProductImg") %>' class="card-img-top mx-auto mt-4 d-block" style="width: 225px;" />
                    <div class="card-body text-center">
                        <h5 class="card-title"><%# Eval("Product") %></h5>
                        <p class="card-text"><span>Rs</span> <%# Eval("Price") %> <span>Per <%#Eval("Unit")%></span></p>
                        <p class="card-text"><%# Eval("Description") %></p>
                    </div>
                    <div class="row offset-2 mb-4">             
                    <asp:LinkButton runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Product") +"," + Eval("Price") +","+ Eval("ProductImg") %>' CommandName="AddToCart">Add To Cart</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-info ml-3" CommandArgument='<%# Eval("Product") +"," + Eval("Price") +","+ Eval("ProductImg") %>' CommandName="Buy">Buy Now</asp:LinkButton>

                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
        <%--</div>--%>
</asp:Content>
