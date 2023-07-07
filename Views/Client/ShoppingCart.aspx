<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Client/ClientMaster.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="MedicalStore.Views.Client.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: linear-gradient(to bottom, #000000, #333333);
            margin: 0;
            padding: 0;
        }

        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
            color: #ffffff;
            font-family: Arial, sans-serif;
        }

        .row {
            margin-bottom: 20px;
        }

        .col-md-6 {
            color: #ffffff;
        }

        .table {
            color: #ffffff;
            background-color: #111111;
            border-collapse: collapse;
            width: 100%;
        }

        .table th,
        .table td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ffffff;
        }

        .table th {
            background-color: #222222;
        }

        .total-price {
            display: inline-block;
            margin-right: 10px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container fluid">
        <div class="row">
            <h4 style="color: #ffffff; font-size:32px;"><u>Your Cart</u></h4>
        </div>
        <div class="row">
            <div class="col-md-6">
                <h2 style="color: #ffffff; font-size:24px;">Medicines List</h2>
                <asp:GridView ID="cartview" class="table" runat="server"></asp:GridView>
            </div>
        </div>
        <div class="row">
            <div style="display: inline-block; font-size:24px;">
                <span class="total-price" style="color: #ffffff;">Total price:</span>
                <asp:Label ID="Total_price" runat="server" Text="0" Style="display: inline-block; color: #ffffff;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
