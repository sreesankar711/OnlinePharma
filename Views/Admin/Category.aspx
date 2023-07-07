<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="MedicalStore.Views.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: linear-gradient(to bottom, #000000, #111111);
        }

        .container-fluid {
            color: #ffffff;
        }

        .form-control {
            background-color: #222222;
            border: none;
            color: #ffffff;
        }

        .btn {
            background-color: #1a1a1a;
            border-color: #1a1a1a;
            color: #ffffff;
        }

        .btn:hover {
            background-color: #333333;
            border-color: #333333;
            color: #ffffff;
        }

        .table {
            background-color: #222222;
            color: #ffffff;
        }

        .text-danger {
            color: #ff4081;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row mt-5">
            <div class="col-md-6">
                <div class="row mb-3">
                    <div class="col">
                        <input type="text" class="form-control" autocomplete="off" placeholder="Category Name"  id ="CatName" runat ="server">
                    </div>
                </div>
                <div class="row mb-3">
                    <label id="ErrMsg" class="text-danger" runat="server"></label>
                    <div class="col d-grid">
                        <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-success btn-block" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="SaveBtn" runat="server" Text="Save" class="btn btn-primary btn-block" OnClick="SaveBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="DelBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DelBtn_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <h2>Categories List</h2>
                <asp:GridView ID="CategoriesList" class="table" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoriesList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
