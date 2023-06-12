using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using AccesoData;

namespace Login_InfoToolsSV
{ 
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void BtnRegistrar_Click (object sender,EventArgs e)
        {
            string user = tbUsuario.Text;
            string pass = tbPassword.Text;
            string email = tbEmail.Text;

            ConexionDatos conexionDatos = new ConexionDatos();
            if (conexionDatos.registrarse(user, pass, email)>0)
            {
                lblError.Text = "Registro completado";
            }
            else
            {
                lblError.Text = "Error con el registro, por favor, intente nuevamente";
            }
        }

        protected void BtnIrAIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_InfoToolsSV.aspx");
        }
    }
}