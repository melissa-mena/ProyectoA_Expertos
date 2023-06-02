<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Login_InfoToolsSV.Formulario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Formulario - Preguntas sobre los 12 tipos de inteligencia</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Recursos/CSS/Estilos.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
</head>
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

        <div class="container">
            <h2 class="mt-4">Preguntas sobre los 12 tipos de inteligencia</h2>

            <asp:Repeater ID="rptPreguntas" runat="server" OnItemDataBound="rptPreguntas_ItemDataBound">
                <ItemTemplate>
                    <div class="card mt-4 <%# GetCardColor(Container.ItemIndex) %>">
                        <div class="card-body">
                            <h5 class="card-title">Pregunta <%# Container.ItemIndex + 1 %>:</h5>
                            <p class="card-text"><%# Eval("PreguntaText") %></p>
                            <asp:DropDownList ID="ddlRespuesta" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecciona una respuesta" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="mt-4">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar Respuestas" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            </div>
        </div>
    </form>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>