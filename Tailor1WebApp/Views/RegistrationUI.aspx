<%@ Page Title="USBF Tailor" Language="C#" AutoEventWireup="true" CodeBehind="RegistrationUI.aspx.cs" Inherits="Tailor1WebApp.Views.RegistrationUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>User Registration</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/reset.css" rel="stylesheet" />
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <form runat="server" style="padding-top: 50px">
                    <br /><br /><br /><br />
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-10">
                                 <asp:Label runat="server" CssClass="control-label" Text="User Registration" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
                                <%--<asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtuserID"
                                    CssClass="text-danger" ErrorMessage="User Name is required." />--%>
                            </div>
                        </div>
                        <br /><br />
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">UserName</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtuserID" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtuserID"
                                    CssClass="text-danger" ErrorMessage="User Name is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtUserPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPassword" CssClass="text-danger" ErrorMessage="Password is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Full Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtUserFullName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserFullName" CssClass="text-danger" ErrorMessage="FullName is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Mobile</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtUserMobile" CssClass="form-control" />                                
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserMobile" ErrorMessage="Enter Correct Mobile No" ValidationExpression="^\d{11}" CssClass="text-danger"></asp:RegularExpressionValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserMobile" ErrorMessage="Enter Correct Mobile No" ValidationExpression="^(?:\d|[,\+])+$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-md-10">
                                <asp:Label runat="server" ID="txtMessage" CssClass="col-md-2 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnCancil" Text="Cancil" CssClass="btn btn-primary" OnClick="btnCancil_Click" CausesValidation="false" />
                                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:HyperLink runat="server" Text="Go to LogIn Page" NavigateUrl="~/Views/TestLogin.aspx" Font-Underline="true"></asp:HyperLink>--%>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
