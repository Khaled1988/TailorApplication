<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderReport.aspx.cs" Inherits="Tailor1WebApp.Report.OrderReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">--%>
        <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
        
        //$(document).ready(function () {
        //    $("a[title='PDF']").parent().hide();  // Remove from export dropdown.
        //    $("a[title='MHTML (web archive)']").parent().hide();
        //    $("a[title='TIFF file']").parent().hide();
        //});

        <%--function doPrint() {
            var prtContent = document.getElementById('<%= rptViewer.ClientID %>');
            prtContent.border = 0; //set no border here
            var WinPrint = window.open('', '', 'left=150,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }--%>

    </script>
    <%--</asp:ScriptManager>--%>
    <div class="form-horizontal">
        <h4>Order Report</h4>        
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">From Date</asp:Label>
            <div class="col-md-10">
                <%--<asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control" />--%>
                <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerIDNo" CssClass="text-danger" ErrorMessage="This field is required." />--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">To Date</asp:Label>
            <div class="col-md-10">
                <%--<asp:TextBox runat="server" ID="txtToDate" CssClass="form-control"/>--%>
                <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker"/>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
            </div>
        </div>
        <%--<div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Delivery Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDelivereyDate" CssClass="form-control col-md-3 datepicker" data-provide="datepicker"/>
            </div>
        </div>  --%>      
        <div class="form-group">            
            <div class="col-md-10">                
                <asp:Label runat="server" ID="txtMessage" CssClass="control-label" ></asp:Label>                
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnShowReport" Text="Show" CssClass="btn btn-primary" OnClick="btnShowReport_Click" />                
                <%--<br />
                <br />
                <rsweb:ReportViewer ID="rptViewer" runat="server" Width="90%">
                </rsweb:ReportViewer>    --%>           
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <br />
                <br />
                <rsweb:ReportViewer ID="rptViewer" runat="server" Width="90%">
                </rsweb:ReportViewer>    
            </div>
        </div>
    </div>
</asp:Content>
