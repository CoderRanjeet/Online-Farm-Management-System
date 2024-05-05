<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="OnlineFarm.ManageCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-4 px-4">
        <h3 class="mb-4 text-center">Manage Category</h3>
        <div class="row g-4">
            <div class="col-sm-12 col-xl-12">
                <div class="bg-light rounded h-100 p-4">

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label text-center">Category</label>
                        <div class="col-sm-12 col-xl-6">
                            <input type="text" class="form-control" id="txtCategory" runat="server">
                        </div>
                    </div>
                    <div class="text-center">
                        <button type="submit" class="btn btn-primary" runat="server" id="BtnSubmit" onserverclick="BtnSubmit_ServerClick">Submit</button>
                    </div>
                </div>
            </div>
        </div>

        <section class="section">
            <div class="card mt-4">
                <h3 class="card-title text-center">All Categories</h3>
                <asp:Repeater runat="server" ID="RptCategories" OnItemCommand="RptCategories_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped table-responsive">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Category Name</th>
                                    <th>Created Date</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th><%#Eval("CatId")%></th>
                                <th><%#Eval("Category")%></th>
                                <td><%#Eval("CreatedDate")%></td>
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("CatId")%>'>Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("CatId")%>'>Delete</asp:LinkButton>
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
