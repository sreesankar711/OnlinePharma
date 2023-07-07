<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MedicalStore.Views.Admin.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/bootstrap.min.css" />

    <style>
        body {
            background: linear-gradient(to bottom, #000000, #1a1a1a);
            color: #ffffff;
            height: 100%;
        }

        html {
            height: 100%;
        }

        .container-fluid {
            min-height: 100%;
            position: relative;
            padding-bottom: 100px; 
        }

        .text-center {
            margin-bottom: 30px;
        }

        h4 {
            font-size: 24px;
            font-weight: bold;
        }

        p {
            font-size: 26px;
            font-weight: 600;
        }

        form {
            background-color: transparent;
        }

        .form-label {
            color: #ffffff;
        }

        .form-control {
            background-color: transparent;
            border-color: #ffffff;
            color: #ffffff;
        }

            .form-control:focus {
                background-color: transparent;
                border-color: #ffffff;
                color: #ffffff;
                box-shadow: none;
            }

        .form-text {
            color: #ffffff;
        }

        .btn-success {
            background-color: #ff4081;
            border-color: #ff4081;
        }

            .btn-success:hover,
            .btn-success:focus,
            .btn-success:active {
                background-color: #ff4081 !important;
                border-color: #ff4081 !important;
            }

        .footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            background-color: #1a1a1a;
            padding: 10px 0;
            text-align: center; 
        }

            .footer p {
                color: #ffffff;
                margin-bottom: 0;
            }

            .footer .social-media {
                margin-top: 20px;
            }

                .footer .social-media a {
                    color: #ffffff;
                    margin-right: 10px;
                }

        .awesome-images {
            display: none; 
        }

        .back-button {
            position: absolute;
            top: 20px;
            left: 20px;
            background-color: transparent;
            border: none;
            color: #ffffff;
            font-weight: bold;
            font-size: 18px;
            padding: 0;
            cursor: pointer;
            text-decoration: none;
        }

            .back-button:hover,
            .back-button:focus,
            .back-button:active {
                outline: none;
            }

            .back-button .fa-arrow-left {
                margin-right: 1px;
            }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container-fluid">
            <a class="back-button" href="../Home"><i class="fas fa-arrow-left"></i>Back</a>
            <div class="row mt-5 mb-3">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="text-center">
                        <h4>WELCOME to</h4>
                        <p style="font-size: 26px; font-weight: 600;">ONLINEPHARMA</p>
                    </div>
                </div>
            </div>
            <div class="row mt-5 mb-3">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <form>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Email address</label>
                            <input type="email" class="form-control" id="email_field" runat="server" />
                            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">Password</label>
                            <input type="password" class="form-control" id="pwd_field" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="errlabel" runat="server"></asp:Label>
                        </div>
                        <div class="mb-3 d-grid">
                            <asp:Button ID="submit" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="submit_Click" />
                        </div>
                    </form>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>

        <footer class="footer">
            <div class="container">
                <p style="font-size: 18px;">OnlinePharma &copy; 2023. All rights reserved.</p>
                <div class="social-media">
                    <a href="#"><i class="fab fa-facebook-f"></i></a>
                    <a href="#"><i class="fab fa-twitter"></i></a>
                    <a href="#"><i class="fab fa-instagram"></i></a>
                    <a href="#"><i class="fab fa-linkedin-in"></i></a>
                </div>
            </div>
        </footer>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js" crossorigin="anonymous"></script>
</body>
</html>
