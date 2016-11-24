<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerUI.aspx.cs" Inherits="Tailor1WebApp.Views.CustomerUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Customer Information</legend>
            <%--<h4>Customer Information</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            
            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>--%>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Customer Type</asp:Label>
                <div class="col-md-10">
                    <asp:RadioButton ID="rbEmployee" GroupName="CustomerType" Text="Employee" runat="server" Checked="true" AutoPostBack="True" OnCheckedChanged="rbEmployee_CheckedChanged" />
                    &nbsp;
                <asp:RadioButton ID="rbGeneral" GroupName="CustomerType" Text="General" runat="server" AutoPostBack="True" OnCheckedChanged="rbEmployee_CheckedChanged" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Customer ID</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCustomerIDNo" CssClass="form-control" placeholder="Enter Employee ID" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerIDNo" CssClass="text-danger" ErrorMessage="Employee ID is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Full Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Enter Full Name" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullName" CssClass="text-danger" ErrorMessage="Full Name is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Department</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDepartment" CssClass="form-control" placeholder="Enter Department name" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartment" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Designation</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control" placeholder="Enter Employee Designation" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartment" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Work Station</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtWorkStation" CssClass="form-control" placeholder="Enter Work Station" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartment" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Gender</asp:Label>
                <div class="col-md-10">
                    <asp:RadioButton ID="rbMale" GroupName="GenderType" Text="Male" runat="server" Checked="true" /><br />
                    <asp:RadioButton ID="rbFemale" GroupName="GenderType" Text="Female" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Mobile</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCustomerMobile" CssClass="form-control" placeholder="Enter Mobile No."/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerMobile" CssClass="text-danger" ErrorMessage="Contact No. is required." />
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomerMobile" ErrorMessage="Enter Correct Mobile No" ValidationExpression="^\d{11}" CssClass="text-danger"></asp:RegularExpressionValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomerMobile" ErrorMessage="Enter Correct Mobile No" ValidationExpression="^(?:\d|[,\+])+$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Address</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCustomerAddress" CssClass="form-control" TextMode="MultiLine" Width="450px" Height="100px" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <%--<asp:Label runat="server" ID="txtMessage" CssClass="control-label"></asp:Label>--%>
                    <asp:Label runat="server" ID="txtMessage" ForeColor="Green"></asp:Label>
                    <asp:Label runat="server" ID="lblCustomerHiddenID" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCancil" Text="Cancil" CssClass="btn btn-primary" OnClick="btnCancil_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink runat="server" ID="hlCustomerSearch" Text="Go to Customer List" NavigateUrl="~/Views/CustomerSearch.aspx" Font-Underline="true"></asp:HyperLink>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
