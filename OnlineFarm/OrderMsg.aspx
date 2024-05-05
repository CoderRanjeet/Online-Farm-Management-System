<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderMsg.aspx.cs" Inherits="OnlineFarm.OrderMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
        body {
            text-align: center;
        }

        h1 {
            color: #88B04B;
            font-family: "Nunito Sans", "Helvetica Neue", sans-serif;
            font-weight: 900;
            font-size: 40px;
            margin-bottom: 10px;
        }

        p {
            color: #404F5E;
            font-family: "Nunito Sans", "Helvetica Neue", sans-serif;
            font-size: 20px;
            margin: 0;
        }

        i {
            color: #9ABC66;
            font-size: 100px;
            line-height: 200px;
            margin-left: -15px;
        }

        .card {
            background: white;
            padding: 60px;
            border-radius: 4px;
            box-shadow: 0 2px 3px #C8D0D8;
            display: inline-block;
            margin: 22px auto;
            max-height: 470px;
        }

        .card-header {
            border-radius: 200px;
            height: 200px;
            width: 200px;
            background: #5c7a1f;
            margin: 0 auto;
        }
    </style>

    <div class="card">
        <div class="card-header">
            <i class="checkmark">✓</i>
        </div>
        <h1>Success</h1>
        <p>You Have placed order successfully,<br />
            Please Visit Again!
            <br />
            <br />
            Thanks</p>
    </div>
</asp:Content>
