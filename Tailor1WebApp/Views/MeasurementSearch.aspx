<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeasurementSearch.aspx.cs" Inherits="Tailor1WebApp.Views.MeasurementSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-inline">
        <br />
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Measurement View</legend>
            <%--<h4>Measurement View</h4>--%>
            <div style="text-align: right">
                <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </div>            
            <%--<asp:HyperLink runat="server" Text="New Measurement Entry" NavigateUrl="~/Views/MeasurementUI.aspx" Font-Underline="true"></asp:HyperLink>--%>
            <br />
            <br />
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
                    <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" Width="200px" placeholder="Enter Customer Name" />
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" Width="200px" placeholder="Enter Customer Mobile No." />
                    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnAddMeasurement" Text="+ Add New Measurement" CssClass="btn btn-success" OnClick="btnAddMeasurement_Click"/>
                    <asp:Label ID="lblCustomerID" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <br /><br />
            <%--</div>   CustomerMeasurementID    
    <div>--%>
            <asp:ListView ID="lvAllMeasurementList" runat="server" DataKeyNames="MeasurementID" OnItemCommand="lvAllMeasurementList_ItemCommand"
                OnItemDataBound="lvAllMeasurementList_ItemDataBound" OnPagePropertiesChanging="OnPagePropertyChanging">
                <LayoutTemplate>
                    <table class="table table-bordered table-responsive">
                        <tr id="trHead" runat="server">
                            <th id="th3" runat="server" align="center" width="5%">SL #
                            </th>
                            <th id="th1" runat="server" text-align="center">Customer Name
                            </th>
                            <th id="th16" runat="server" text-align="center">ID
                            </th>
                            <th id="th17" runat="server" text-align="center">Mobile No.
                            </th>
                            <th id="th2" runat="server" align="center">Dress Type
                            </th>
                            <th id="th4" runat="server" align="center">Length
                            </th>
                            <th id="th5" runat="server" align="center">Chest
                            </th>
                            <th id="th6" runat="server" align="center">Waist/ Belly
                            </th>
                            <th id="th7" runat="server" align="center">Hip
                            </th>
                            <th id="th8" runat="server" align="center">Shoulder
                            </th>
                            <th id="th9" runat="server" align="center">Sleeve Length
                            </th>
                            <th id="th10" runat="server" align="center">Cuff Opening
                            </th>
                            <th id="th11" runat="server" align="center">Neck
                            </th>
                            <th id="th12" runat="server" align="center">All Round Rise 
                            </th>
                            <th id="th13" runat="server" align="center">Thaigh
                            </th>
                            <th id="th14" runat="server" align="center">Bottom Opening
                            </th>
                            <th id="th15" runat="server" align="center" colspan="2">Action
                            </th>
                            <%--<th id="th16" runat="server" align="center"></th>--%>
                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <tr>
                            <td colspan="18">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvAllMeasurementList" PageSize="10">
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
                            <asp:Label ID="lblCustomerName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCustomerID" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobileNo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblLength" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblChest" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblWaist" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblHip" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblShoulder" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSleeve" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCuff" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNeck" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAllRoundRise" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblThaigh" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBottomOpening" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkPrint" runat="server" CausesValidation="false" Text="Print"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td align="center">
                            <asp:Label ID="lblSerialNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </td>
                        <td align="left">                            
                            <asp:Label ID="lblCustomerName" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCustomerID" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobileNo" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDressType" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblLength" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblChest" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblWaist" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblHip" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblShoulder" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSleeve" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCuff" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNeck" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAllRoundRise" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblThaigh" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBottomOpening" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit"></asp:LinkButton>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkPrint" runat="server" CausesValidation="false" Text="Print"></asp:LinkButton>
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
