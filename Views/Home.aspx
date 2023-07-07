<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MedicalStore.Views.Home" %>

<!DOCTYPE html>

<html>
<head>
    <title>OnlinePharma - Home</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <style>
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        body {
            display: flex;
            flex-direction: column;
            background: linear-gradient(to bottom, #000000, #1a1a1a);
            color: #ffffff;
        }

        .content {
            flex: 1;
            padding-top: 50px;
        }

        .jumbotron {
            background-color: transparent;
            margin-bottom: 0;
        }

        .jumbotron h1 {
            font-size: 48px;
        }

        .jumbotron p {
            font-size: 24px;
            margin-bottom: 30px;
        }

        .btn-primary {
            background-color: #ff4081;
            border-color: #ff4081;
        }

        .btn-primary:hover,
        .btn-primary:focus,
        .btn-primary:active {
            background-color: #ff4081 !important;
            border-color: #ff4081 !important;
        }

        .footer {
            background-color: #1a1a1a;
            padding: 30px 0;
            color: #ffffff;
        }

        .footer p {
            margin-bottom: 0;
        }

        .footer .social-media {
            margin-top: 20px;
        }

        .footer .social-media a {
            color: #ffffff;
            margin-right: 10px;
        }

        .login-link {
            position: absolute;
            top: 20px;
            right: 20px;
            color: #ffffff;
        }
    </style>
</head>
<body>
    <div class="content">
        <div class="container">
            <div class="jumbotron text-center">
                <h1 class="mb-4">Welcome to OnlinePharma</h1>
                <p class="lead">Your Trusted Online Pharmacy</p>
                <a href="Views/Login.aspx" class="btn btn-primary login-link">Login</a>
            </div>
        </div>
    </div>

    <footer class="footer text-center">
        <div class="container">
            <p>OnlinePharma &copy; 2023. All rights reserved.</p>
            <div class="social-media">
                <a href="#"><i class="fab fa-facebook-f"></i></a>
                <a href="#"><i class="fab fa-twitter"></i></a>
                <a href="#"><i class="fab fa-instagram"></i></a>
                <a href="#"><i class="fab fa-linkedin-in"></i></a>
            </div>
        </div>
    </footer>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
</body>
</html>
