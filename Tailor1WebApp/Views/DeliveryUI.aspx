<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeliveryUI.aspx.cs" Inherits="Tailor1WebApp.Views.DeliveryUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <script type="text/javascript">

       function Confirm() {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_value";
           if (confirm("There is some Due...Do you want to Deliver?")) {
               confirm_value.value = "Yes";
           } else {
               confirm_value.value = "No";
           }
           document.forms[0].appendChild(confirm_value);
       }

       function alertCancel() {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_value";
           if (confirm("Are you sure about this Cancel?")) {
               confirm_value.value = "Yes";
           }
           else {
               confirm_value.value = "No";
           }
           document.forms[0].appendChild(confirm_value);
       }
    </script>
    <div class="form-inline">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Delivery Order</legend>

            <%--<h4>Delivery</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="form-group">
                <%--<asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>--%>
                <div class="col-md-12">
                    <asp:RadioButton ID="rbUnDelivered" GroupName="OrderType" Text="UnDelivered" runat="server" Checked="true" AutoPostBack="True" OnCheckedChanged="rbUnDelivered_CheckedChanged" />
                    &nbsp;<asp:RadioButton ID="rbDelivered" GroupName="OrderType" Text="Delivered" runat="server" AutoPostBack="True" OnCheckedChanged="rbDelivered_CheckedChanged" />
                    &nbsp;<asp:RadioButton ID="rbCancil" GroupName="OrderType" Text="Cancelled" runat="server" AutoPostBack="True" OnCheckedChanged="rbCancil_CheckedChanged" />
                </div>
            </div>
            <br />
            <br />
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-5 control-label">Enter Invoice No.</asp:Label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" ID="txtSearchText" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            <br />
            <br />
            <%--<div>--%>
            <asp:ListView ID="lvAllUnDeliveredList" runat="server" DataKeyNames="OrderID" OnItemCommand="lvAllUnDeliveredList_ItemCommand"
                OnItemDataBound="lvAllUnDeliveredList_ItemDataBound" OnPagePropertiesChanging="OnPagePropertyChanging">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <tr id="trHead" runat="server">
                            <th id="th3" runat="server" align="center" width="5%">SL #
                            </th>
                            <th id="th7" runat="server" align="center" width="5%">Select
                            </th>
                            <th id="th1" runat="server" text-align="center">Invoice No
                            </th>
                            <th id="th2" runat="server" align="center">Invoice Date
                            </th>
                            <th id="th4" runat="server" align="center">Delivery Date
                            </th>
                            <th id="th5" runat="server" align="center">Total Price
                            </th>
                            <th id="th6" runat="server" align="center">Paid Amount
                            </th>
                            <th id="th8" runat="server" align="center">Discount
                            </th>
                            <th id="th9" runat="server" align="center">Due Amount
                            </th>
                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <tr>
                            <td colspan="9">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvAllUnDeliveredList" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                            ShowNextPageButton="false" />
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="chkboxDelivery" runat="server" />
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkbtnOrderNo" runat="server" CausesValidation="false"></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOrderDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDeliveryDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotalPrice" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPaidAmount" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblOrderID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDiscount" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDueAmount" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="chkboxDelivery" runat="server" />
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkbtnOrderNo" runat="server" CausesValidation="false"></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOrderDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDeliveryDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotalPrice" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPaidAmount" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblOrderID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDiscount" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDueAmount" runat="server" ForeColor="Black"></asp:Label>
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
            <%--</div>--%>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label runat="server" ID="txtMessage" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <%--<asp:Button runat="server" ID="btnDelivery" Text="Delivered" CssClass="btn btn-primary" OnClick="btnDelivery_Click" AutoPostBack="true" />--%>
                <asp:Button runat="server" ID="btnDelivery" Text="Delivered" CssClass="btn btn-primary" OnClientClick = "Confirm()" OnClick="OnConfirm" />
                <div class="col-md-7">
                    <%--<asp:Button runat="server" ID="btnCancilOrder" Text="Cancel Order" CssClass="btn btn-primary" OnClick="btnCancilOrder_Click" />--%>
                    <asp:Button runat="server" ID="btnCancilOrder" Text="Cancel Order" CssClass="btn btn-primary" OnClientClick = "alertCancel()" OnClick="OnalertCancel" />
                </div>                
            </div>
        </fieldset>
    </div>
</asp:Content>
