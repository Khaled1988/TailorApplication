<%@ Page Title="USBF Tailor" Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="Tailor1WebApp.Views.LoginUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8"> 
    <title>Login Page</title>   
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/reset.css" rel="stylesheet" />
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <form runat="server" style="padding-top:50px">
                    <div class="form-horizontal">                        
                        
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>                        
                        <div class="form-group">                            
                            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Image id="Image1" runat="server" AlternateText="Image text" ImageAlign="Middle" class="img-responsive" CssClass="col-lg-offset-2 .col-xs-6 .col-sm-4" ImageUrl="~/Image/logo.jpg"/>
                            <div class="col-md-10">                                
                            </div>
                            <br />
                        </div>
                        <div class="form-group">                           
                            <asp:Label runat="server" CssClass="col-md-3 control-label">UserName</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtUserID" CssClass="form-control" placeholder="Enter Username" />
                                <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ControlToValidate="txtUserID" ErrorMessage="User Name  is required." />
                            </div>
                        </div>
                        <div class="form-group">                            
                            <asp:Label runat="server" CssClass="col-md-3 control-label">Password</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password"  />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="Password is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="txtMessage" CssClass="text-danger"></asp:Label>                                
                            </div>
                        </div>
                        <div class="form-group">
                            <%--<div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnLogIn" Text="Log in" CssClass="btn btn-primary" OnClick="btnLogIn_Click" />
                            </div>--%>
                            <asp:Label runat="server" CssClass="col-md-3 control-label"></asp:Label>                               
                                <div class="col-md-9" style="padding-left:220px">
                                    <asp:Button runat="server" ID="btnLogIn" Text="Login" CssClass="btn btn-primary" OnClick="btnLogIn_Click" Width="80px" />
                                </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>

</html>
