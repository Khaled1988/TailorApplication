<%@ Page Title="USBF Tailor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutTailor.aspx.cs" Inherits="Tailor1WebApp.Views.AboutTailor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href='https://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Raleway:500' rel='stylesheet' type='text/css'>
    <div class="jumbotron">
        <div>
            <p style="text-align: center">
                <img src="../Image/Tailor.jpg" alt="TailorPicture" class="img-rounded center-block" style="width:180px;height:180px"></p>
        </div>
        <h2><b> Welcome to Tailor Solution </b></h2>  
              
        <%--<div class="lead">
            <%--<img src="../Image/SewingMachine.png" class="img-responsive right" alt="Tailor Picture" width="304" height="236">
            <img src="../Image/SewingMachine.png" class="img-rounded center-block" alt="Tailor Picture">
        </div>--%>
        <br />
        <%--<p class="lead">--%>
        <p style="text-align: center">
            The Tailor Solution is a specialized solution for maintaining Inventory,
             Customer Information with their Dress Measurement, Order Invoice creation, different parameter wise Search
             facility and Reports generation for all operations.
        </p>
        
    </div>    

</asp:Content>