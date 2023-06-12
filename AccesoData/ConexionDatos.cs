using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData
{
    public class ConexionDatos
    {
        public SqlConnection conexion()
        {
            string serverName = "163.178.173.130";

            string databaseName = "IF-7103Proyecto1";

            string username = "basesdedatos";
            string password = "rpbases.2022";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={username};Password={password};";
            return new SqlConnection(connectionString);

        }
        

        public bool loguearse(String usuario, String contraseña)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ExpertosConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("select * from [User] where Username = @usuario;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {

                String user = reader.GetValue(1).ToString();
                String pass = reader.GetValue(3).ToString();

                if (user == usuario && pass == contraseña)
                {
                    return true;
                }
            }

            sqlConnection.Close();

            return false;
        }

        public int registrarse(String usuario, String contraseña, String email)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ExpertosConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [User] (Username, Password, Email) VALUES (@usuario, @contraseña, @email);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario);
            sqlCommand.Parameters.AddWithValue("@contraseña", contraseña);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return rowsAffected;
        }

    }
}