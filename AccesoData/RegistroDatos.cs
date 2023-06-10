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
       
        public List<UsuariosTest> obtenerTestUsuarios(float distancia,String inteligencia)
        {
            List<UsuariosTest> listaUsuarios = new List<UsuariosTest>();
            SqlConnection sqlConnection = conexionDatos.conexion();

            SqlCommand sqlCommand = new SqlCommand(
                "SELECT  [IntelligenceType],[Username] , [Distance]  " +
                "FROM[dbo].[TestResult] " +
                "LEFT JOIN[dbo].[User] ON[IdUser] = [dbo].[User].[Id] " +
                "ORDER BY CASE WHEN [Distance] = "+ distancia +" THEN 0  "+
                "WHEN[IntelligenceType] = "+ "'" + inteligencia + "'" + " THEN 0  ELSE 1 END, [Distance],[IntelligenceType];"
                , sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                UsuariosTest dato= new UsuariosTest();
                dato.nombre = (reader["Username"].ToString());
                dato.IntelligenceType = (reader["IntelligenceType"].ToString());
                dato.Distance = Convert.ToSingle(reader["Distance"]);
                listaUsuarios.Add(dato);

            }
            sqlConnection.Close();
            return listaUsuarios;
        }
        
        public bool registrarTestUsuario(UsuariosTest nuevoUsuario)
        {
            SqlConnection sqlConnection = conexionDatos.conexion();
            sqlConnection.Open();
           
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[TestResult]"
                    + "()"
                    , sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IntelligenceType", nuevoUsuario.nombre);
                sqlCommand.Parameters.AddWithValue("@IdUser", nuevoUsuario.IdUser);
                sqlCommand.Parameters.AddWithValue("@Distance", (float)(nuevoUsuario.Distance));
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
