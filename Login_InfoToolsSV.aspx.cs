﻿using AccesoData;
using System;

namespace Login_InfoToolsSV
{
    public partial class Login_InfoToolsSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string user = tbUsuario.Text;
            string pass = tbPassword.Text;

            ConexionDatos conexionDatos = new ConexionDatos();
            if (conexionDatos.loguearse(user, pass))
            {
                Response.Redirect("Formulario.aspx");
            }
            else
            {
                lblError.Text = "Error con el inicio de sesión, por favor revise los datos ingresados";
            }
            
        }

        protected void BtnIrARegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}