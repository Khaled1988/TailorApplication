<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DressTypeUI.aspx.cs" Inherits="Tailor1WebApp.Views.DressTypeUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Dress Type Entry</legend>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Dress Type</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDressType" CssClass="form-control" placeholder="Enter Dress Type" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDressType" CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Dress Price</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtDressPrice" CssClass="form-control" placeholder="Enter Dress Price" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDressPrice" CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="btnSaveDress" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveDress_Click" />
                    <asp:Label ID="lbldresstypeIDhidden" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:ListView ID="lvAllDressType" runat="server" DataKeyNames="DressTypeID" OnItemCommand="lvAllDressType_ItemCommand"
                        OnItemDataBound="lvAllDressType_ItemDataBound" OnPagePropertiesChanging="OnPagePropertyChanging">
                        <LayoutTemplate>
                            <table class="table table-bordered table-responsive">
                                <tr id="trHead" runat="server">
                                    <th id="th3" runat="server" align="center" width="5%">SL #
                                    </th>
                                    <th id="th1" runat="server" text-align="center">Dress Type
                                    </th>
                                    <th id="th2" runat="server" align="center">Dress Price
                                    </th>
                                    <th id="th7" runat="server" align="center">Action
                                    </th>
                                </tr>
                                <tbody id="itemPlaceholder" runat="server">
                                </tbody>
                                <tr>
                                    <td colspan="7">
                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvAllDressType" PageSize="10">
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
                                    <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDressPrice" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trBody" runat="server" class="dGridRowClass">
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDressPrice" runat="server" ForeColor="Black"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
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
        </fieldset>
    </div>
</asp:Content>
