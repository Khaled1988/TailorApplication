<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderMaterialSearch.aspx.cs" Inherits="Tailor1WebApp.Views.OrderMaterialSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <div class="form-inline">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Accesories Requisition Search</legend>
            <%--<h4>Customer Search</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <%--<asp:HyperLink runat="server" Text="New Customer" NavigateUrl="~/Views/CustomerUI.aspx" Font-Underline="true"></asp:HyperLink>--%>
            <br />
            <br />            
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-4 control-label">From Date</asp:Label>
                <div class="col-md-8">
                    <%--<asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control col-md-2 datepicker" data-provide="datepicker" />--%>
                    <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="yyyy/MM/dd" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-4 control-label">To Date</asp:Label>
                <div class="col-md-8">
                    <%--<asp:TextBox runat="server" ID="txtToDate" CssClass="form-control col-md-2 datepicker" data-provide="datepicker" />--%>
                    <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="yyyy/MM/dd" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-4 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:Label ID="txtMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <br />
            <br />
            
            <asp:ListView ID="lvOrderMaterial" runat="server" DataKeyNames="OrderMaterialID" OnItemDataBound="lvOrderMaterial_ItemDataBound">
                <%--OnItemCommand="lvOrderMaterial_ItemCommand"  OnPagePropertiesChanging="OnPagePropertyChanging">--%>
                <LayoutTemplate>
                    <table class="table table-bordered table-responsive">
                        <tr id="trHead" runat="server">
                            <th id="th3" runat="server" align="center" width="5%">SL #
                            </th>
                            <th id="th6" runat="server" align="center" width="5%">Select
                            </th>
                            <th id="th1" runat="server" text-align="center">Invoice No.
                            </th>
                            <th id="th2" runat="server" align="center">Material Code
                            </th>
                            <th id="th4" runat="server" align="center">Material Quantity
                            </th>
                            <th id="th7" runat="server" align="center">Unit
                            </th>
                            <th id="th5" runat="server" align="center">Material Out Date
                            </th>
                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <%--<tr>
                            <td colspan="7">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvOrderMaterial" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                            ShowNextPageButton="false" />
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>--%>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="chkboxInvoice" runat="server" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
                            <asp:Label ID="lblOrderID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialQuantity" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialUnit" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialOutDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="chkboxInvoice" runat="server" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
                            <asp:Label ID="lblOrderID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialQuantity" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialUnit" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialOutDate" runat="server" ForeColor="Black"></asp:Label>
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
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-5 control-label"></asp:Label>
                <div class="col-md-7">
                    <asp:Button ID="btnModify" runat="server" CssClass="btn btn-primary" Text="Modify" OnClick="btnModify_Click" />
                    <asp:Label ID="lblorderIdHidden" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
