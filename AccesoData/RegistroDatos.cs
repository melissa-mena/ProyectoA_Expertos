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
       
        public List<UsuariosTest> obtenerTestUsuarios(float distancia,String inteligencia ,int id)
        {
            List<UsuariosTest> listaUsuarios = new List<UsuariosTest>();
            SqlConnection sqlConnection = conexionDatos.conexion();

            SqlCommand sqlCommand = new SqlCommand(
                "SELECT [IntelligenceType], [Username], [Distance] " +
                "FROM [dbo].[TestResult] " +
                "LEFT JOIN [dbo].[User] ON [IdUser] = [dbo].[User].[Id] WHERE [IdUser]<> @id " +
                "ORDER BY CASE WHEN [IntelligenceType] = @inteligencia THEN 0 ELSE 1 END, [Distance], [IntelligenceType];",
                sqlConnection);

            // Agregar parámetros
            sqlCommand.Parameters.AddWithValue("@distancia", distancia);
            sqlCommand.Parameters.AddWithValue("@inteligencia", inteligencia);
            sqlCommand.Parameters.AddWithValue("@id", id);
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
           
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM [dbo].[TestResult] WHERE [IdUser] = @IdUser;" +
                    "INSERT INTO [dbo].[TestResult]"
                    + "([IntelligenceType], [IdUser], [Distance]) VALUES (@IntelligenceType,@IdUser,@Distance);"
                    , sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IntelligenceType", nuevoUsuario.IntelligenceType);
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
        public int existe(string nombre, string password)
        {
            int id = 0;
            SqlConnection sqlConnection = conexionDatos.conexion();
            SqlCommand sqlCommand = new SqlCommand("SELECT [Id] FROM [dbo].[User] WHERE [Username] = "+"'"+nombre+"'"+" AND [Password]=" + "'" + password + "'", sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["Id"];
            }
            sqlConnection.Close();
            return id;
        }


    }
}
