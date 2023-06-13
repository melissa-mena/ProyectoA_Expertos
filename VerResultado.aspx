<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerResultado.aspx.cs" Inherits="Login_InfoToolsSV.VerResultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resultados</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Recursos/CSS/Estilos.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style type="text/css">

        th, td {
           width: 25%;
           text-align: left;
           vertical-align: top;
           border: 1px solid #000;
           border-collapse: collapse;
           padding: 0.3em;
           caption-side: bottom;
        }

    </style>
</head>
<script>

</script>
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
   </form>

         <div style="display: flex; justify-content: center; align-items: center; height: 10vh;">
             
            <asp:Label ID="lblTipoInteligencia" runat="server" Text="" style="font-size: 20px; font-weight: bold;"></asp:Label>
             
         </div>
    <div style="display: flex; justify-content: center; align-items: center; height: 50vh;">
        <asp:Image ID="ImTipoInteligencia" runat="server" Height="200px" Width="300px"  />
    </div>
    <div style="overflow-x:auto; height: 50vh;" >
        <h2 style="display: flex; justify-content: center; align-items: center;">Lista de personas que tienen el mismo tipo de inteligencia que tú</h2>

        <table style="display: flex; justify-content: center; align-items: center;">
            
            <tr>
                <th >Nombre del usuario</th>
                <th >Inteligencia</th>
                <th>Cercania a su inteligencia</th>
            </tr>
            <asp:Repeater ID="rptPersonas" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("nombre") %></td>
                        <td><%# Eval("IntelligenceType") %></td>
                        <td><%# Eval("Distance") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
 
        </div>
 
</body>
</html>