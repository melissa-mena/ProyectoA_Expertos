using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Login_InfoToolsSV
{ 
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void BtnRegistrar_Click (object sender,EventArgs e)
        {
            
        }

        protected void BtnIrAIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_InfoToolsSV.aspx");
        }
    }
}