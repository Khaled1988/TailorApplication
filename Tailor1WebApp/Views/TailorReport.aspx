<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TailorReport.aspx.cs" Inherits="Tailor1WebApp.Views.TailorReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <br />
    <br />
    <h3>Tailor All Reports</h3>
    <br />
    <div class="panel-group" id="accordion">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseDNF">Order Report Datewise
                    </a>
                </h4>
            </div>
            <div id="collapseDNF" class="panel-collapse collapse in">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">From Date</asp:Label>
                            <div class="col-md-10">
                                <%--<asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />--%>
                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="yyyy/MM/dd" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">To Date</asp:Label>
                            <div class="col-md-10">
                                <%--<asp:TextBox runat="server" ID="txtToDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />--%>
                                <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="yyyy/MM/dd" />
                            </div>
                        </div>                        
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnShowOrderReport" Text="Show" CssClass="btn btn-primary" OnClick="btnShowOrderReport_Click" />&nbsp;&nbsp;
                                <asp:Label ID="lblmessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="form-group" id="divOrderReport" runat="server">
                            <div class="col-md-offset-2 col-md-10">
                                <rsweb:ReportViewer ID="ReportViewerOrderReport" runat="server" Width="90%">
                                </rsweb:ReportViewer>
                                <asp:Button ID="btnORhidden" runat="server" Text="" Width="0em" BorderColor="White" BackColor="White" ForeColor="White" Height="0em" />
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseITF">Customerwise Order Details Report
                    </a>
                </h4>
            </div>
            <div id="collapseITF" class="panel-collapse collapse in">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Customer ID</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtCustomerID" CssClass="form-control autosuggest" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnCustomerWiseDeliveryRpt" Text="Show" CssClass="btn btn-primary" OnClick="btnCustomerWiseDeliveryRpt_Click" />&nbsp;&nbsp;
                                <asp:Label ID="lblCustomerMsg" runat="server" Text="" CssClass="text-danger" ></asp:Label>
                            </div>
                        </div>
                        <div class="form-group" id="divCustomerWiseDelivery" runat="server">
                            <div class="col-md-offset-2 col-md-10">
                                <rsweb:ReportViewer ID="ReportViewerCustomerWiseDelivery" runat="server" Width="90%">
                                </rsweb:ReportViewer>
                                <asp:Button ID="btnCWDHidden" runat="server" Text="" Width="0em" BorderColor="White" BackColor="White" ForeColor="White" Height="0em" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseDNF">Accesories Status Datewise
                    </a>
                </h4>
            </div>
            <div id="collapseASD" class="panel-collapse collapse in">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Report Type</asp:Label>
                            <div class="col-md-10">
                                <asp:RadioButton ID="rbInQuantity" GroupName="MaterialInOut" Text="InQuantity" runat="server" Checked="true" />
                                <%--AutoPostBack="True" OnCheckedChanged="rbInQuantity_CheckedChanged" />--%>
                                &nbsp;
                                <asp:RadioButton ID="rbOutQuantity" GroupName="MaterialInOut" Text="OutQuantity" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">From Date</asp:Label>
                            <div class="col-md-10">
                                <%--<asp:TextBox runat="server" ID="txtFromDateASD" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />--%>
                                <asp:TextBox runat="server" ID="txtFromDateASD" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDateASD" Format="yyyy/MM/dd" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">To Date</asp:Label>
                            <div class="col-md-10">
                                <%--<asp:TextBox runat="server" ID="txtToDateASD" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />--%>
                                <asp:TextBox runat="server" ID="txtToDateASD" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDateASD" Format="yyyy/MM/dd" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnShowReportASD" Text="Show" CssClass="btn btn-primary" OnClick="btnShowReportASD_Click" />&nbsp;&nbsp;
                                <asp:Label ID="lblmessageASD" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="form-group" id="divMaterialStatusDatewise" runat="server">
                            <div class="col-md-offset-2 col-md-10">
                                <rsweb:ReportViewer ID="ReportViewerASD" runat="server" Width="90%">
                                </rsweb:ReportViewer>
                                <asp:Button ID="btnhiddenASD" runat="server" Text="" Width="0em" BorderColor="White" BackColor="White" ForeColor="White" Height="0em" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseITF">Accesories Status Codewise
                    </a>
                </h4>
            </div>
            <div id="collapseAS" class="panel-collapse collapse in">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">Accesories Code</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtMaterialCode" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnShowMaterialStatus" Text="Show" CssClass="btn btn-primary" OnClick="btnShowMaterialStatus_Click" />&nbsp;&nbsp;
                                <asp:Label ID="lblMaterialStatusMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group" id="divMaterialStatus" runat="server">
                            <div class="col-md-offset-2 col-md-10">
                                <rsweb:ReportViewer ID="MaterialStatusReportViewer" runat="server" Width="90%">
                                </rsweb:ReportViewer>
                                <asp:Button ID="btnMShidden" runat="server" Text="" Width="0em" BorderColor="White" BackColor="White" ForeColor="White" Height="0em" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
