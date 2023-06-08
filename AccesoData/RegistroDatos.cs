using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData
{
    public class DatosTest
    {
        private ConexionDatos conexionDatos = new ConexionDatos();
       
        public List<Usuarios> obtenerTestUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            SqlConnection sqlConnection = conexionDatos.conexion();

            SqlCommand sqlCommand = new SqlCommand(
                "SELECT  [IntelligenceType],[Username] , [Distance] " +
                "FROM [dbo].[TestResult] " +
                "LEFT JOIN [dbo].[User] ON [IdUser] = [dbo].[User].[Id];"
                , sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Usuarios dato= new Usuarios();
                dato.nombre = (reader["Username"].ToString());
                dato.contraseña = (reader["IntelligenceType"].ToString());
                dato.id = ((int)reader["Distance"]);
                listaUsuarios.Add(dato);

            }
            sqlConnection.Close();
            return listaUsuarios;
        }
        
        public bool registrarTestUsuario(Usuarios nuevoUsuario)
        {
            SqlConnection sqlConnection = conexionDatos.conexion();
            sqlConnection.Open();
           
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tabla"
                    + "()"
                    , sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IntelligenceType", nuevoUsuario.nombre);
                sqlCommand.Parameters.AddWithValue("@IdUser", nuevoUsuario.contraseña);
                sqlCommand.Parameters.AddWithValue("@Distance", (float)(nuevoUsuario.id));
                bool result = true;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    result = false;
                }
                sqlConnection.Close();
                return result;

            
        }
        public bool existe(int id, string nombre, string password)
        {
            SqlConnection sqlConnection = conexionDatos.conexion();
            SqlCommand sqlCommand = new SqlCommand("SELECT id FROM Login WHERE id=@idAND ...", sqlConnection);
            //sqlCommand.Parameters.AddWithValue("@id", id;
            //sqlCommand.Parameters.AddWithValue("@nombre", nombre);
            //sqlCommand.Parameters.AddWithValue("@contraseña", contraseña);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            return !reader.Read();
        }
    }
}
