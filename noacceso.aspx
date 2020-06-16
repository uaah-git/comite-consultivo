<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noacceso.aspx.cs" Inherits="ComiteEvaluativo.noacceso" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Universidad Alberto Hurtado</title>
    <link href='https://fonts.googleapis.com/css?family=Lato:300,400' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="css/style.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <link type="image/x-icon" href="images/favicon.png" rel="icon" />
</head>
<body>
    <div class='modal'>
        <div class='header'>
            <img src="images/logo_uah_negro.png" alt="" width="215" height="49" />
        </div>
        <div class='content'>
            <b>Estimado(a): No posee permisos para visualizar el panel de gestión.</b>
            <br />
            <b>Comité Consultivo.</b>
        </div>
        <div class='actions'>
            <a class='success' href='inicio.aspx'>Inicio</a>
        </div>
        <div class='loader-bar'>
            <div class='bar'></div>
        </div>
    </div>
</body>
</html>
