<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estadisticas.aspx.cs" Inherits="ComiteEvaluativo.estadisticas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>


<html>
<head>
    <title>Universidad Alberto Hurtado</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="assets/css/main.css" />
    <link type="image/x-icon" href="images/favicon.png" rel="icon" />
</head>

<body class="is-preload">

    <!-- Header -->
    <div id="header">

        <div class="top">

            <!-- Logo -->
            <div id="logo">
                <img src="images/avatar.png" alt="" />
            </div>

            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="#top" id="top-link"><span class="icon solid fa-home">Inicio</span></a></li>
                    <li><a href="#portfolio" id="portfolio-link"><span class="icon solid fa-th">Dashboard</span></a></li>
                </ul>
            </nav>

        </div>

        <div class="bottom">

            <!-- Social Icons -->
            <ul class="icons">
                <li><a href="inicio.aspx" class="icon solid fa-home fa-2x"></a></li>
            </ul>
        </div>
    </div>

    <!-- Main -->
    <div id="main">

        <!-- Intro -->
        <section id="top" class="one dark cover">
            <div class="container">
                <header>
                    <h2 class="alt"><strong>Comité Consultivo</strong><br />
                    </h2>
                    <br />
                    <br />
                    <br />
                </header>
            </div>
        </section>

        <!-- Información -->
        <section id="portfolio" class="two">
            <div class="container">

                <header>
                    <h2>Dashboard Panel de Gestión</h2>
                </header>
                <form id="form1" runat="server">
                    <asp:Label ID="lblUserID" runat="server" Text="Label" hidden="true"></asp:Label>
                    <div class="form-group">
                        <label for="planta">Estadística Dimensión Planta</label>
                        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSourceEstadisticaPlanta" Palette="EarthTones" ToolTip="Estadística Dimensión Planta" Width="450px">
                            <Series>
                                <asp:Series Name="Series1" XValueMember="PLANTA" YValueMembers="TOTAL"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourceEstadisticaPlanta" runat="server" ConnectionString="<%$ ConnectionStrings:conexionComiteUAH %>" SelectCommand="ESTADISTICA_PLANTA" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>

                    <div class="form-group">
                        <label for="fecha">Estadística Respuestas</label>
                        <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSourceEstFecha" Width="964px" Height="473" Palette="EarthTones" ToolTip="Estadística Transacciones Diarias">
                            <Series>
                                <asp:Series Name="Series1" XValueMember="FECHA" YValueMembers="TOTAL" YValuesPerPoint="2"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>

                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourceEstFecha" runat="server" ConnectionString="<%$ ConnectionStrings:conexionComiteUAH %>" SelectCommand="ESTADISTICA_FECHA" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <label for="nombre">Información Comité Consultivo</label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" DataSourceID="SqlDataSourceReport" Font-Size="Small" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" ReadOnly="True" SortExpression="NOMBRE" />
                                        <asp:BoundField DataField="CORREO ELECTRONICO" HeaderText="CORREO ELECTRONICO" ReadOnly="True" SortExpression="CORREO ELECTRONICO" />
                                        <asp:BoundField DataField="PLANTA" HeaderText="PLANTA" ReadOnly="True" SortExpression="PLANTA" />
                                        <asp:BoundField DataField="OPINION" HeaderText="OPINION" ReadOnly="True" SortExpression="OPINION" />
                                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" ReadOnly="True" SortExpression="FECHA" />
                                        <asp:BoundField DataField="HORA" HeaderText="HORA" ReadOnly="True" SortExpression="HORA" />
                                    </Columns>
                                    <PagerSettings Mode="NextPrevious" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceReport" runat="server" ConnectionString="<%$ ConnectionStrings:conexionComiteUAH %>" SelectCommand="REPORTE" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Button ID="ButtonExport" runat="server" Text="Exportar" class="form-control" OnClick="ButtonExport_Click" />
                    </div>
                    <div style="width: 1px; height: 1px; overflow: scroll;">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" Font-Size="Small">
                            <Columns>
                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" ReadOnly="True" SortExpression="NOMBRE" />
                                <asp:BoundField DataField="CORREO ELECTRONICO" HeaderText="CORREO ELECTRONICO" ReadOnly="True" SortExpression="CORREO ELECTRONICO" />
                                <asp:BoundField DataField="PLANTA" HeaderText="PLANTA" ReadOnly="True" SortExpression="PLANTA" />
                                <asp:BoundField DataField="OPINION" HeaderText="OPINION" ReadOnly="True" SortExpression="OPINION" />
                                <asp:BoundField DataField="FECHA" HeaderText="FECHA" ReadOnly="True" SortExpression="FECHA" />
                                <asp:BoundField DataField="HORA" HeaderText="HORA" ReadOnly="True" SortExpression="HORA" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>
            </div>
        </section>
    </div>

    <!-- Footer -->
    <div id="footer">
        <!-- Copyright -->
        <ul class="copyright">
            <li>&copy; Universidad Alberto Hurtado. Almirante Barroso 10, Santiago de Chile. Teléfono (2) 2692 0200.</li>
        </ul>
    </div>
    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.scrolly.min.js"></script>
    <script src="assets/js/jquery.scrollex.min.js"></script>
    <script src="assets/js/browser.min.js"></script>
    <script src="assets/js/breakpoints.min.js"></script>
    <script src="assets/js/util.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>
