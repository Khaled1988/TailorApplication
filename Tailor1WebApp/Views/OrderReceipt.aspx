<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderReceipt.aspx.cs" Inherits="Tailor1WebApp.Views.OrderReceipt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div id="divOrderReceipt" runat="server">
        <rsweb:ReportViewer ID="rptViewer" runat="server" Width="90%">
        </rsweb:ReportViewer>
    </div>
    <div id="divCustomerMeasurement" runat="server">
        <rsweb:ReportViewer ID="rptViewerMeasurement" runat="server" Width="90%">
        </rsweb:ReportViewer>
    </div>    
</asp:Content>
