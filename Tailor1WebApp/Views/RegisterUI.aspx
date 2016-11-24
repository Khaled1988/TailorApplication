<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUI.aspx.cs" Inherits="Tailor1WebApp.Views.RegisterUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4> Registration</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">UserID</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtuserID" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtuserID"
                    CssClass="text-danger" ErrorMessage="The userID field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Passowrd" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Full Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserFullName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserFullName" CssClass="text-danger" ErrorMessage="The FullName field is required." />
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Mobile</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserMobile" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserMobile" CssClass="text-danger" ErrorMessage="The Mobile field is required." />
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
            </div>
        </div>
    </div>
</asp:Content>
