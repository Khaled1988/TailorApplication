<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierSearch.aspx.cs" Inherits="Tailor1WebApp.Views.SupplierSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-inline">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Supplier Search</legend>

            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>

            <%--<asp:HyperLink runat="server" Text="Add New Supplier" NavigateUrl="~/Views/SupplierUI.aspx" Font-Underline="true"></asp:HyperLink>--%>
            <asp:Button runat="server" ID="btnAddSupplier" Text=" + Add New Supplier" CssClass="btn btn-success" OnClick="btnAddSupplier_Click" />
            <br />
            <br />


            <%--<div class="form-group">
                <asp:Label runat="server" CssClass="col-md-5 control-label">Enter Name</asp:Label>
                <div class="col-md-7">
                    <asp:TextBox runat="server" ID="txtSearchText" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            <br /><br />--%>

            <%--<div class="form-group">
                <div class="form-inline">
                    <asp:Label runat="server" CssClass="col-md-3 control-label">Supplier Name</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtSearchText" CssClass="form-control" Width="160px" placeholder="Enter Supplier Name" />
                        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <br />
            <br />--%>
            <div class="form-group">
                <div class="form-inline">
                    <asp:TextBox runat="server" ID="txtSuplierName" CssClass="form-control" Width="200px" placeholder="Enter Supplier Name" />
                    <asp:TextBox runat="server" ID="txtSuplierPhone" CssClass="form-control" Width="200px" placeholder="Enter Supplier Contact No." />
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            <br />
            <br />

            <asp:ListView ID="lvAllSupplierList" runat="server" DataKeyNames="SupplierProductID" OnItemCommand="lvAllSupplierList_ItemCommand"
                OnItemDataBound="lvAllSupplierList_ItemDataBound" OnPagePropertiesChanging="OnPagePropertyChanging">
                <LayoutTemplate>
                    <table class="table table-bordered table-responsive">
                        <tr id="trHead" runat="server">
                            <th id="th3" runat="server" align="center" width="5%">SL #
                            </th>
                            <th id="th1" runat="server" text-align="center">Supplier Code
                            </th>
                            <th id="th16" runat="server" text-align="center">Supplier Name
                            </th>
                            <th id="th17" runat="server" text-align="center">Address
                            </th>
                            <th id="th2" runat="server" align="center">Mobile
                            </th>
                            <th id="th4" runat="server" align="center">Accesories/Material
                            </th>
                            <th id="th5" runat="server" align="center">Price
                            </th>
                            <th id="th6" runat="server" align="center">Quantity
                            </th>
                            <th id="th7" runat="server" align="center">Unit
                            </th>
                            <th id="th8" runat="server" align="center">Material Code
                            </th>
                            <th id="th9" runat="server" align="center">Purchase Date
                            </th>
                            <th id="th10" runat="server" align="center">Other Info
                            </th>
                            <th id="th15" runat="server" align="center">Action
                            </th>
                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <tr>
                            <td colspan="18">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvAllSupplierList" PageSize="15">
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
                        <td align="left">
                            <asp:Label ID="lblSupplierCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSupplierName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAddress" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobile" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAccesories" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPrice" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblQuantity" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblUnit" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPurchaseDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOtherInfo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
                            <asp:Label ID="lblMaterialID" runat="server" ForeColor="Black" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSupplierCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSupplierName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAddress" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobile" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAccesories" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPrice" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblQuantity" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblUnit" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMaterialCode" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPurchaseDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOtherInfo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
                            <asp:Label ID="lblMaterialID" runat="server" ForeColor="Black" Visible="false"></asp:Label>
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
        </fieldset>
    </div>
</asp:Content>
