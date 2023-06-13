<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Login_InfoToolsSV.Formulario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Formulario - Tipos de inteligencia</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Recursos/CSS/Estilos.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Test</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                 <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <asp:Button ID="logoutButton" runat="server" CssClass="btn btn-link nav-link" Text="Logout" OnClick="logoutButton_Click" />
                    </li>
                 </ul>
             </div>
        </nav>

        <div class="container">
            <div class="alert-container"></div>
            <h2 class="mt-4">Test de Inteligencias Múltiples</h2>

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
</body>
</html>