<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderUI.aspx.cs" Inherits="Tailor1WebApp.Views.OrderUI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             $(".datepicker").datepicker();
         });
    </script>
    <div class="form-horizontal">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Order Entry</legend>
            <%--<div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label"><h3>Order</h3></asp:Label>
            <hr />
            <div class="col-md-10">
            </div>
        </div>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>--%>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Invoice No</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtOrderNo" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOrderNo" CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Customer</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlCustomerList" runat="server" CssClass="form-control" Width="20em" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomerList_SelectedIndexChanged">
                        <asp:ListItem Text="-Select Customer-" Value="0" />
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Name</asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblCustomerName" CssClass="form-control" Enabled="false" Width="20em"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Designation</asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblDesignation" CssClass="form-control" Enabled="false" Width="20em"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:ListView ID="lvCustomerMeasurement" runat="server" DataKeyNames="DressMeasurementID" OnItemDataBound="lvCustomerMeasurement_ItemDataBound">
                        <LayoutTemplate>
                            <table class="table table-bordered">
                                <tr id="trHead" runat="server">
                                    <th id="th3" runat="server" align="center" width="5%">SL#
                                    </th>
                                    <th id="th2" runat="server" align="center" width="15%">Dress Type
                                    </th>
                                    <th id="th4" runat="server" align="center" width="15%">Price
                                    </th>
                                    <th id="th5" runat="server" align="center" width="15%">No. of Piece
                                    </th>
                                    <th id="th6" runat="server" visible="false"></th>
                                </tr>
                                <tbody id="itemPlaceholder" runat="server">
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="trBody" runat="server" class="dGridRowClass">
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPrice" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDressQuantity" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" id="td9" runat="server" visible="false">
                                    <asp:Label ID="lblDressTypeID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trBody" runat="server" class="dGridRowClass">
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPrice" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDressQuantity" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" id="td9" runat="server" visible="false">
                                    <asp:Label ID="lblDressTypeID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>No Data...
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnCalculate" Text="Calculate" CssClass="btn btn-primary" OnClick="btnCalculate_Click" CausesValidation="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Total Price</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtTotalPrice" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Paid Amount</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtPaidAmount" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPaidAmount" CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Discount</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDiscount" CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Due</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDue" CssClass="form-control" />
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Delivery Date</asp:Label>
                <div class="col-md-10">
                    <%--<asp:TextBox runat="server" ID="txtDelivereyDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />--%>
                    <asp:TextBox runat="server" ID="txtDelivereyDate" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDelivereyDate" Format="yyyy-MM-dd" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Remarks</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" Width="25em" />
                </div>
            </div>
            <div id="quantityDiv" runat="server">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Total Quantity</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtTotalQuantity" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label runat="server" ID="txtMessage" CssClass="control-label"></asp:Label>
                    <asp:Label runat="server" ID="txtOrderNohidden" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnReceipt" Text="Generate Order Receipt" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnReceipt_Click" />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
