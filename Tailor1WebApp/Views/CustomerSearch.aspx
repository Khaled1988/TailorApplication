<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerSearch.aspx.cs" Inherits="Tailor1WebApp.Views.TestListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-inline">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Customer Search</legend>
            <%--<h4>Customer Search</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>
            
            <asp:HyperLink runat="server" Text="Add New Customer" NavigateUrl="~/Views/CustomerUI.aspx" Font-Underline="true"></asp:HyperLink>
            <br /><br />
            <%--<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>--%>
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
            </div>--%>
            <%--<div class="form-group">
                <div class="form-inline">
                    <asp:Label runat="server" CssClass="col-md-3 control-label">Customer Name</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtSearchText" CssClass="form-control" Width="165px" placeholder="Enter Customer Name" />
                        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />                    
                    </div>                    
                </div>
            </div>--%>
            <div class="form-group">
                <div class="form-inline">                    
                    <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" Width="180px" placeholder="Enter Customer Name" />
                    <asp:TextBox runat="server" ID="txtCustomerID" CssClass="form-control" Width="180px" placeholder="Enter Customer ID" />
                    <asp:TextBox runat="server" ID="txtCustomerMobile" CssClass="form-control" Width="180px" placeholder="Enter Customer Mobile" />
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            
            <%--</div>--%>
            <br />
            <br />
            <%--<div>--%>
            <asp:ListView ID="lvAllBrandList" runat="server" DataKeyNames="CustomerID" OnItemCommand="lvAllBrandList_ItemCommand"
                OnItemDataBound="lvAllBrandList_ItemDataBound" OnPagePropertiesChanging="OnPagePropertyChanging">
                <LayoutTemplate>
                    <table class="table table-bordered table-responsive">
                        <tr id="trHead" runat="server">
                            <th id="th3" runat="server" align="center" width="5%">SL #
                            </th>
                            <th id="th1" runat="server" text-align="center">Customer Name
                            </th>
                            <th id="th2" runat="server" align="center">Emp./Cust. ID
                            </th>
                            <th id="th6" runat="server" align="center">Mobile No.
                            </th>
                            <th id="th4" runat="server" align="center">Department
                            </th>
                            <th id="th5" runat="server" align="center">Designation
                            </th>                            
                            <th id="th7" runat="server" align="center" colspan="2">Action
                            </th>
                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <tr>
                            <td colspan="8">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvAllBrandList" PageSize="15">
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
                            <asp:Label ID="lblName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCUstomerIDNo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobileNo" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblCustomerID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDepartment" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDesignation" runat="server" ForeColor="Black"></asp:Label>
                        </td>                        
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit Info."></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkMeasurement" runat="server" CausesValidation="false" Text="Go to Measurement"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="left">                            
                            <asp:Label ID="lblName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCUstomerIDNo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobileNo" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblCustomerID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDepartment" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDesignation" runat="server" ForeColor="Black"></asp:Label>
                        </td>                        
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit Info."></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkMeasurement" runat="server" CausesValidation="false" Text="Go to Measurement"></asp:LinkButton>
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
