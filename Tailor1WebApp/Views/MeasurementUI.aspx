<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeasurementUI.aspx.cs" Inherits="Tailor1WebApp.Views.MeasurementUI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Measurement Entry</legend>
            <%--<h4>Measurement</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <%--<hr />--%>
            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>--%>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Customer ID</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control" Width="400px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                        <asp:ListItem Text="-Select Customer-" Value="0" />
                    </asp:DropDownList>
                    <asp:Label ID="lblhiddenCustomerID" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Name</asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblCustomerName" CssClass="form-control" Enabled="false" Width="400px" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Designation</asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblDesignation" CssClass="form-control" Enabled="false" Width="400px" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Work Station</asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblWorkStation" CssClass="form-control" Enabled="false" Width="400px" />
                </div>
            </div>
            <%--<div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Date</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMeasurementDate" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtMeasurementDate" Format="yyyy-MM-dd" />
                </div>
            </div>--%>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Dress Type</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlDressType" runat="server" CssClass="form-control" Width="280px" AppendDataBoundItems="true">
                        <asp:ListItem Text="-Select Dress-" Value="0" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlDressType" InitialValue="0" runat="server" ErrorMessage="Please select Dress type" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Length</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtLength" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtLength" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Chest</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtChest" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtChest" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Waist/Belly</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtWaistBelly" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtWaistBelly" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Hip</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtHip" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtHip" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Shoulder</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtShoulder" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtShoulder" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Sleeve Length</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtSleeveLength" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtSleeveLength" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Cuff Opening</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCuffopening" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtCuffopening" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Neck</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtNeck" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtNeck" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">All Round Rise</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtAllroundRise" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtAllroundRise" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Thaigh</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtThaigh" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtThaigh" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Bottom Opening</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtBottomOpening" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtBottomOpening" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <%--<asp:Label runat="server" ID="txtMessage" CssClass="control-label"></asp:Label>--%>
                    <asp:Label runat="server" ID="txtMessage" CssClass="control-label"></asp:Label>
                    <asp:Label runat="server" ID="lblMeasurementHiddenID" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancil" Text="Cancil" CssClass="btn btn-primary" OnClick="btnCancil_Click"/>
                <asp:HyperLink runat="server" ID="hlMeasurementSearch" Text="Go to Measurement List" NavigateUrl="~/Views/MeasurementSearch.aspx" Font-Underline="true"></asp:HyperLink>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
