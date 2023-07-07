<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Client/ClientMaster.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="MedicalStore.Views.Client.Shop" %>
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

        .medicines-list {
            margin-top: 10px;
            text-align: center;
        }

        .col-md-6,
        .col-md-8 {
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

        .selected-medicine {
            text-align: center;
        }

        .buy-button {
            display: block;
            margin-top: 10px;
            background-color: #ff69b4;
            color: #ffffff;
            border: none;
            padding: 5px 20px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            border-radius: 20px;
        }

        .buy-button:hover {
            background-color: #ff55a1;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container">
        <div class="row mb-3">
            <h4 class="medicines-list">Select Your Required Medicines</h4>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <h2 class="medicines-list" style="color: #ffffff;">Medicines List</h2>
                <asp:GridView ID="MedicineList" class="table" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="MedicineList_SelectedIndexChanged"></asp:GridView>
            </div>
            <div class="col-md-6">
                <h2 class="selected-medicine" style="color: #ffffff;">Selected List</h2>
                <asp:GridView ID="SelectedMedicine" class="table" runat="server"></asp:GridView>
            </div>
        </div>
        <div style="font-size: 24px; font-weight: 600;">
            <span class="total-price">Total price:</span>
            <asp:Label ID="Total_price" runat="server" Text="0" CssClass="total-price"></asp:Label>
        </div>
        <div class="row mb-3">
           <asp:Button ID="Cart" runat="server" Text="BUY" OnClick="Cart_Click" CssClass="buy-button" />
        </div>
    </div>
</asp:Content>
