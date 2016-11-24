<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierUI.aspx.cs" Inherits="Tailor1WebApp.Views.SupplierUI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <br />
    <div class="form-horizontal">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Supplier Information</legend>

            <%--<h4>Supplier Information</h4>
            <hr />
            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label runat="server" ID="txtMessage" CssClass="col-md-2 control-label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Supplier Code</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtSupplierCode" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerIDNo" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Supplier Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtSupplierName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSupplierName" CssClass="text-danger" ErrorMessage="Supplier Name is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Address</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtSupplierAddress" CssClass="form-control" TextMode="MultiLine" Width="450px" Height="70px" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartment" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Mobile</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtSupplierMobile" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerMobile" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSupplierMobile" ErrorMessage="Enter Correct Mobile No" ValidationExpression="^(?:\d|[,\+])+$" CssClass="text-danger"></asp:RegularExpressionValidator><br />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Accessories / Material</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMaterialName" CssClass="form-control" TextMode="MultiLine" Width="450px" Height="70px" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMaterialName" CssClass="text-danger" ErrorMessage="Accessories / Material information is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Price</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMaterialPrice" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtMaterialPrice" CssClass="text-danger" ErrorMessage="This field is required." />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtMaterialPrice" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <div class="form-inline">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Quantity</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" />
                        <asp:DropDownList runat="server" ID="ddlMeasurementUnit" CssClass="form-control" Width="150px" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="sl1">-SELECT Unit-</asp:ListItem>
                            <asp:ListItem Value="meter">Meter</asp:ListItem>
                            <asp:ListItem Value="inch">Inches</asp:ListItem>
                            <asp:ListItem Value="centimeter">CentiMeter</asp:ListItem>
                            <asp:ListItem Value="piece">Piece</asp:ListItem>
                            <asp:ListItem Value="gauge">Gauge</asp:ListItem>
                            <asp:ListItem Value="yard">Yard</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtQuantity" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Enter numbers in Quantity" runat="server" CssClass="text-danger" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Material Code</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMaterialCode" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMaterialCode" CssClass="text-danger" ErrorMessage="Material Code is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Purchase Date</asp:Label>
                <div class="col-md-10">
                    <%--<asp:TextBox runat="server" ID="txtPurchaseDate" CssClass="form-control col-md-2 datepicker" data-provide="datepicker" />--%>
                    <asp:TextBox runat="server" ID="txtPurchaseDate" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPurchaseDate" Format="dd-MM-yyyy" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Other Information</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtOtherSupplierInfo" CssClass="form-control" TextMode="MultiLine" Width="450px" Height="100px" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    <asp:Label ID="lblMaterialIDHidden" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSupplierSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSupplierSave_Click" />
                    &nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false"/>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
