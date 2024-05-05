<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ShoppingStore.aspx.cs" Inherits="OnlineFarm.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2 class="mb-4 text-center">Fresh Products</h2>
        <div class="row mb-4 mb-4">
            <div class="col-md-3">
                <h4>Select Category</h4>
            </div>
            <div class="col-md-4">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlcategory" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <asp:Label runat="server" ID="lblMsg" Visible="false"></asp:Label>
            <asp:Repeater runat="server" ID="RptProducts" OnItemCommand="RptProducts_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-3 mb-4">
                        <div class="card h-100 border-0">
                            <img src='<%# Eval("ProductImg") %>' class="card-img-top mx-auto d-block" style="max-width: 225px; max-height: 260px;" />
                            <div class="card-body text-center">
                                <h5 class="card-title"><span style="display: none;"><%# Eval("ProductId") %></span> <%# Eval("Product") %></h5>
                                <h5 class="card-title"><span>Rs</span> <%# Eval("Price") %> <span>Per Kg</span></h5>
                                <h5 class="card-title"><span>Avail. Qty : </span><%# Eval("Qty") %> <span><%#Eval("Unit")%></span></h5>

                                <p class="card-text" style="display: block; text-overflow: ellipsis; width: 300px; overflow: hidden; white-space: nowrap;"><%# Eval("Description") %></p>

                                <asp:LinkButton runat="server" class="btn btn-success" CommandArgument='<%# Eval("ProductId") %>' CommandName="View">View Details</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
