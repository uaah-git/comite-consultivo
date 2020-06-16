<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ComiteEvaluativo.inicio" %>

<!DOCTYPE html>
<html>
<head>
    <title>Universidad Alberto Hurtado</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="stylesheet" href="assets/css/main.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>
    <script>
        function countChar(val) {
            $('#TextOpinion').keyup(function () {
                var max = 3000;
                var len = $(this).val().length;
                if (len >= max) {
                    $('#charNum').text(' Límite de caracteres permitidos.');
                } else {
                    var char = max - len;
                    $('#charNum').text(char + ' Caracteres restantes.');
                }
            });
        };
    </script>
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
                    <li><a href="#portfolio" id="portfolio-link"><span class="icon solid fa-th">Información</span></a></li>
                    <li><a href="#about" id="about-link"><span class="icon solid fa-user">Respuesta</span></a></li>
                </ul>
            </nav>
        </div>
        <div class="bottom">
            <ul class="icons">
                <li><a href="estadisticas.aspx" class="fas fa-chart-bar fa-2x"></a></li>
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
                    <h2>Comité Consultivo</h2>
                </header>
                <p>Tal como se informó a la comunidad universitaria, el Directorio de la Universidad ha constituido un comité consultivo, a objeto de recibir sugerencias de posibles cambios en los procedimientos para el nombramiento de Decanos y Rector, así como la integración del Consejo Académico y el Directorio de la Universidad, de tal modo que estos procesos queden actualizados a los nuevos contextos y desafíos que experimentamos como Universidad y sociedad en general, siempre en el marco de la identidad jesuita de la Universidad Alberto Hurtado.</p>
            </div>
        </section>
        <!-- Evaluación -->
        <section id="about" class="three">
            <div class="container">
                <header>
                    <h2>Comité Consultivo</h2>
                </header>
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div class="form-group">
                        <label for="nombre" class="icon solid fa-user"> Te conectaste como:</label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" placeholder="Nombre Colaborador" class="form-control" disabled="true"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="correo" class="icon solid fa-envelope"> Tu dirección de correo electrónico es:</label>
                        <asp:TextBox ID="TextBoxCorreo" runat="server" placeholder="Correo Electrónico Corporativo" class="form-control" disabled="true"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="planta" class="icon solid fa-home"> Perteneces al tipo planta:</label>
                        <asp:DropDownList ID="DropDownListPlanta" runat="server" DataSourceID="SqlDataSourcePlanta" DataTextField="NOMBRE" DataValueField="ID_PLANTA"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourcePlanta" runat="server" ConnectionString="<%$ ConnectionStrings:conexionComiteUAH %>" SelectCommand="SELECT_PLANTA" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="opinion">¿Qué aspectos consideras relevantes sobre los nombramientos del Rectores/as y Decanos/as, así como sobre la integración del Consejo Académico y del Directorio?</label>
                        <textarea id="TextOpinion" name="TextOpinion" placeholder="Mi opinión es..." runat="server" cols="50" rows="7" class="form-control" onkeyup="countChar(this)" maxlength="3000"></textarea>
                        <div id="charNum"></div>
                    </div>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar Respuesta" class="form-control" OnClick="ButtonEnviar_Click"></asp:Button>
                            <asp:Label ID="lblUserID" runat="server" Text="Label" hidden="true"></asp:Label>
                            <div runat="server" id="divAlert">
                                <asp:Label ID="lblAlerta" runat="server" Visible="true" Text=""></asp:Label>
                            </div>
                            <div runat="server" id="divPlanta">
                                <asp:Label ID="LabelPlanta" runat="server" Visible="true" Text=""></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <%--VALIDACIONES--%>
                    <asp:CompareValidator ID="CompareValidatorPlanta" runat="server" ControlToValidate="DropDownListPlanta" ValueToCompare="0" Operator="NotEqual" Type="Integer" ErrorMessage="Por favor ingresa el tipo de planta a la que perteneces." />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpinion" runat="server" ControlToValidate="TextOpinion" ErrorMessage="Por favo ingresa tu opinión."></asp:RequiredFieldValidator>
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
