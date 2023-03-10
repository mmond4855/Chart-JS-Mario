<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Chart_JS_Mario._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">

            <div class="col-sm-8">
                <div class="jumbotron bg-secondary rounded">
                    <h2 style="text-align:center">
                        Car Sales Data
                    </h2>
                </div>

            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <canvas></canvas>
            </div>
        </div>
    </div>
  
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>

    </script>
</asp:Content>
