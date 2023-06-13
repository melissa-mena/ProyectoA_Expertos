<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_InfoToolsSV.aspx.cs" Inherits="Login_InfoToolsSV.Login_InfoToolsSV" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Recursos/CSS/Estilos.css" rel="stylesheet" />
    <title>Login</title>
    <style>
        .background-radial-gradient {
            background-color: hsl(218, 41%, 15%);
            background-image: radial-gradient(650px circle at 0% 0%,
                hsl(218, 41%, 35%) 15%,
                hsl(218, 41%, 30%) 35%,
                hsl(218, 41%, 20%) 75%,
                hsl(218, 41%, 19%) 80%,
                transparent 100%),
                radial-gradient(1250px circle at 100% 100%,
                hsl(218, 41%, 45%) 15%,
                hsl(218, 41%, 30%) 35%,
                hsl(218, 41%, 20%) 75%,
                hsl(218, 41%, 19%) 80%,
                transparent 100%);
        }

        #radius-shape-1 {
            height: 220px;
            width: 220px;
            top: -60px;
            left: -130px;
            background: radial-gradient(#44006b, #ad1fffa);
            overflow: hidden;
        }

        #radius-shape-2 {
            border-radius: 38% 62% 63% 37% / 70% 33% 67% 30%;
            bottom: -60px;
            right: -110px;
            width: 300px;
            height: 300px;
            background: radial-gradient(#44006b, #ad1fff);
            overflow: hidden;
        }

        .bg-glass {
            background-color: hsla(0, 0%, 100%, 0.9) !important;
            backdrop-filter: saturate(200%) blur(25px);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="background-radial-gradient overflow-hidden">
            <div class="container px-4 py-5 px-md-5 text-center text-lg-start my-5">
                <div class="row gx-lg-5 align-items-center mb-5">
                    <div class="col-lg-6 mb-5 mb-lg-0" style="z-index: 10">
                        <h1 class="my-5 display-5 fw-bold ls-tight" style="color: hsl(218, 81%, 95%)">
                            Test de <br />
                            <span style="color: hsl(218, 81%, 75%)">Inteligencias múltiples</span>
                        </h1>
                        <p class="mb-4 opacity-70" style="color: hsl(218, 81%, 85%)">
                            Bienvenido al test de inteligencias múltiples. Si no tienes un usuario, te invitamos a registrarte.
                            Se te presentará una serie de preguntas, deberás contestarlas de acuerdo a la que se adapte más a tu persona. Al final, se te mostrará tu tipo de inteligencia.
                        </p>
                    </div>
                    <div class="col-lg-6 mb-5 mb-lg-0 position-relative">
                        <div id="radius-shape-1" class="position-absolute rounded-circle shadow-5-strong"></div>
                        <div id="radius-shape-2" class="position-absolute shadow-5-strong"></div>
                        <div class="card bg-glass">
                            <div class="card-body px-4 py-5 px-md-5">
                                
                                <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" type="text" name="user" placeholder="Nombre de Usuario"></asp:TextBox>
                    
                                <br /> 
                                <asp:TextBox ID="tbPassword" CssClass="form-control" TextMode="Password" runat="server" type="text" name="pass" placeholder="Password" ></asp:TextBox>
                                <br />
                                 <hr />
                                    <div class="row">
                                        <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                                    </div>
                                    <br />
                               
                               <div class="row" style="padding: 10px;">
                                    <asp:Button ID="BtnIngresar" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Ingresar" type="submit" value="Submit" OnClick="BtnIngresar_Click" />
                                </div>
                                 <div class="row" style="padding: 10px;">
                                    <asp:Button ID="BtnRegistrarse" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Registrarse" type="submit" value="Submit" OnClick="BtnIrARegistro_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>

