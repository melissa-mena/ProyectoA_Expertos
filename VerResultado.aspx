﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerResultado.aspx.cs" Inherits="Login_InfoToolsSV.VerResultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resultados</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Recursos/CSS/Estilos.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
</head>
<script>
   
</script>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Mi Aplicación</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#"><i class="fas fa-user"></i> Logout</a>
                    </li>
                </ul>
            </div>
        </nav>
   </form>

         <div style="display: flex; justify-content: center; align-items: center; height: 100vh;">
             <h1>Su tipo de inteligencia es:</h1>
            <asp:Label ID="lblTipoInteligencia" runat="server" Text="" style="font-size: 20px; font-weight: bold;"></asp:Label>
         </div>
    <div>
        <h3>Lista de personas que tienen el mismo tipo de inteligencia que tu</h3>
    <form id="form2" runat="server">
        <table>
            <tr>
                <th>Nombre del usuario</th>
                <th>Inteligencia</th>
                <th>Cercania a su inteligencia</th>
            </tr>
            <asp:Repeater ID="rptPersonas" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Apellido") %></td>
                        <td><%# Eval("Edad") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
        </div>
</body>
</html>