<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderMaterialCollection.aspx.cs" Inherits="Tailor1WebApp.Views.OrderMaterialCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <div class="form-horizontal">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Accesories Requisition for Order</legend>
            <%--<h4>Add Accesories for Order</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <br />
            <br />

            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>--%>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Invoice No</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlOrderNo" runat="server" CssClass="form-control" Width="400px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged">
                        <asp:ListItem Text="-Select Order-" Value="0" />
                    </asp:DropDownList>
                    <asp:Label ID="lblorderIDSearch" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lblOrderNoSearch" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group" id="divCustomerName" runat="server">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Customer Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtCustomerName" runat="server" Text="" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="div1" runat="server">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Designation</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtDesignation" runat="server" Text="" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:ListView ID="lvCustomerDressOrder" runat="server" DataKeyNames="" OnItemDataBound="lvCustomerDressOrder_ItemDataBound">
                        <LayoutTemplate>
                            <table class="table table-bordered table-responsive">
                                <tr id="trHead" runat="server">
                                    <th id="th3" runat="server" align="center" width="5%">SL#
                                    </th>
                                    <th id="th2" runat="server" align="center" width="15%" visible="false">Invoice No.
                                    </th>
                                    <th id="th4" runat="server" align="center" width="15%" visible="false">Customer
                                    </th>
                                    <th id="th5" runat="server" align="center" width="15%">Dress
                                    </th>
                                    <th id="th1" runat="server" align="center" width="15%">Invoice Date
                                    </th>
                                    <th id="th7" runat="server" align="center" width="15%">Delivery Date
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
                                    <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </td>
                                <td align="left" id="orderno" runat="server" visible="false">
                                    <asp:Label ID="lblOrderNo" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left" id="customer" runat="server" visible="false">
                                    <asp:Label ID="lblCustomer" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDress" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblOrderDate" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trBody" runat="server" class="dGridRowClass">
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </td>
                                <td align="left" id="orderno" runat="server" visible="false">
                                    <asp:Label ID="lblOrderNo" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left" id="customer" runat="server" visible="false">
                                    <asp:Label ID="lblCustomer" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDress" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblOrderDate" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
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
                <div class="form-inline">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Accesories Code</asp:Label>
                    <div class="col-md-7">
                        <asp:DropDownList runat="server" ID="ddlMaterialCode" CssClass="form-control" Width="250px" AppendDataBoundItems="true">
                            <asp:ListItem Text="-Select Accessories-" Value="0" />
                        </asp:DropDownList>
                        Quantity
                    <asp:TextBox runat="server" ID="txtMaterialQuantity" CssClass="form-control" Width="80px" />
                        <asp:Button ID="btnMaterialAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnMaterialAdd_Click" CausesValidation="false" />
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtMaterialQuantity" ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" CssClass="text-danger" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:ListView ID="lvMaterialList" runat="server" DataKeyNames="MaterialID" OnItemDataBound="lvMaterialList_ItemDataBound">
                        <LayoutTemplate>
                            <table class="table table-bordered table-responsive">
                                <tr id="trHead" runat="server">
                                    <th id="th3" runat="server" align="center" width="5%">SL#
                                    </th>
                                    <th id="th2" runat="server" align="center" width="15%">Material Code
                                    </th>
                                    <th id="th4" runat="server" align="center" width="15%">Quantity
                                    </th>
                                    <th id="th5" runat="server" align="center" width="15%">Unit
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
                                    <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblQuantity" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblUnit" runat="server" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="lblMaterialID" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trBody" runat="server" class="dGridRowClass">
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblQuantity" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblUnit" runat="server" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="lblMaterialID" runat="server" Visible="false"></asp:Label>
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
                <asp:Label runat="server" CssClass="col-md-2 control-label"> Material Out Date</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtOrderMaterialDate" CssClass="form-control col-md-2 datepicker" data-provide="datepicker" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:Label runat="server" ID="lblMessage" CssClass="text-danger" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSaveOrderMaterial" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveOrderMaterial_Click" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
