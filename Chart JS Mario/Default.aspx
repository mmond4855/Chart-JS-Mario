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
                <canvas id="carSalesAmount"></canvas>
            </div>
        </div>
    </div>
  
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        $(document).ready(function () {
            fillChart('carSalesAmount');
        });

        function fillChart(id) {
            var url = '<%: Page.ResolveUrl("~/Default.aspx/GetCarSalesAmountData") %>';

            $.ajax({
                type: "POST",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (carData) {
                    var obj = carData.d; //The JSON String returned from CreateChartJSConfig. 
                    var jsonData = JSON.parse(obj); //Deserializes JSON String into object. 

                    console.log(jsonData);

                    //Chart Data Information.
                    var chartType = jsonData.type;
                    var chartData = jsonData.datasets;
                    var chartLabels = jsonData.datasets.labels;
                    var chartTitle = jsonData.datasets.mainChartTitle;
                    
                    var monthDataSets = [];

                    //Add all returned datasets. 
                    chartData.datasets.forEach(o => monthDataSets.push({
                        label: o.label,
                        data: o.data,
                        borderColor: o.borderColor,
                        backgroundColor: o.backgroundColor
                    })
                    );

                    //Draws out the Chart.js
                    var ctx = document.getElementById(id).getContext('2d');

                    var myChart = new Chart(ctx, {
                        type: chartType,
                        data: {
                            labels: chartLabels,
                            datasets: monthDataSets
                        },
                        options: {
                            plugins: {
                                legend: { display: true },
                                title: { display: true, text: chartTitle }
                            },
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                }
            });
        }
    </script>
</asp:Content>
