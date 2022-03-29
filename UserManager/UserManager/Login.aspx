<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="UserManager.Login" %>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
   
</head>
<body>
    <form id="Login" runat="server">
        <div class="container">
            <h1 class="form-heading">login Form</h1>
            <div class="login-form">
                <div class="main-div">
                    <div class="panel">
                        <h2>Admin Login</h2>
                        <p>Please enter username and password</p>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Message" BackColor="Yellow" ForeColor="#ff3300"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine" placeholder="Username"></asp:TextBox>
                        <%--<input type="text" class="form-control" id="inputUsername" placeholder="Username">--%>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        <%--<input type="password" class="form-control" id="inputPassword" placeholder="Password">--%>
                    </div>
                    <%--<button type="submit" class="btn btn-primary">Login</button>--%>
                    <div class="form-group">
                        <asp:Button
                            ID="BtnLogin"
                            runat="server"
                            CssClass="btn btn-primary textbox"
                            Text="Login"
                            Font-Bold="False"
                            OnClick="BtnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <style>
        body#LoginForm {
            background-image: url("https://hdwallsource.com/img/2014/9/blur-26347-27038-hd-wallpapers.jpg");
            background-repeat: no-repeat;
            background-position: center;
            background-size: cover;
            padding: 10px;
        }

        .form-heading {
            color: #fff;
            font-size: 23px;
        }

        .panel h2 {
            color: #444444;
            font-size: 18px;
            margin: 0 0 8px 0;
        }

        .panel p {
            color: #777777;
            font-size: 14px;
            margin-bottom: 30px;
            line-height: 24px;
        }

        .login-form .form-control {
            background: #f7f7f7 none repeat scroll 0 0;
            border: 1px solid #d4d4d4;
            border-radius: 4px;
            font-size: 14px;
            height: 50px;
            line-height: 50px;
        }

        .main-div {
            background: #fff5cc none repeat scroll 0 0;
            border-radius: 2px;
            margin: 10px auto 30px;
            max-width: 38%;
            padding: 50px 70px 70px 71px;
        }

        .login-form .form-group {
            margin-bottom: 10px;
        }

        .login-form {
            text-align: center;
        }

        .forgot a {
            color: #777777;
            font-size: 14px;
            text-decoration: underline;
        }

        .login-form .btn.btn-primary {
            background: #f0ad4e none repeat scroll 0 0;
            border-color: #f0ad4e;
            color: #ffffff;
            font-size: 14px;
            width: 100%;
            height: 50px;
            line-height: 50px;
            padding: 0;
        }

        .forgot {
            text-align: left;
            margin-bottom: 30px;
        }

        .botto-text {
            color: #ffffff;
            font-size: 14px;
            margin: auto;
        }

        .login-form .btn.btn-primary.reset {
            background: #ff9900 none repeat scroll 0 0;
        }

        .back {
            text-align: left;
            margin-top: 10px;
        }

            .back a {
                color: #444444;
                font-size: 13px;
                text-decoration: none;
            }
    </style>
</body>

</html>
