<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="MedicalStore.Client" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #000000;
            color: #ffffff;
        }

        .container-fluid {
            color: #000000;
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
        <div class="row" style="margin-top: 70px;">
            <div class="col-md-4">
                <div class="row mb-3" style="margin-top: 20px;">
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Client Email" id="email" runat="server">
                    </div>
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Id" id="Id" runat="server">
                    </div>
                </div>
                <div class="row mb-3">
                    <asp:Label ID="ErrMsg" runat="server" Text=""></asp:Label>
                </div>
                <div class="row mb-3">
                    <div class="col d-grid">
                        <asp:Button ID="Search" runat="server" Text="Search" CssClass="btn btn-danger btn-block" OnClick="Search_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="Reject" runat="server" Text="Reject" CssClass="btn btn-danger btn-block" OnClick="Reject_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="Accept" runat="server" Text="Accept" CssClass="btn btn-success btn-block" OnClick="Accept_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <h2 class="custom-header" style="color: white;">Client Cart</h2>
                <asp:GridView ID="List" CssClass="table" runat="server"></asp:GridView>
            </div>
        </div>
    </div>

    <script>
        function printGridView(ClientId) {
            var printContent = document.getElementById('<%= List.ClientID %>');
            var printWindow = window.open('', '', 'width=800,height=600');
            printWindow.document.write('<html><head><title>Print</title>');
            printWindow.document.write('<style>table { width: 90%; margin: 0 auto; }</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write('<div class="custom-header"><h2><u>Bill for ID: ' + ClientId + '</u></h2></div>');
            printWindow.document.write('<table>' + printContent.outerHTML + '</table>');
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
