using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData
{
    public class Datos
    {
        private ConexionDatos conexionDatos = new ConexionDatos();
       
        public List<Usuarios> obtenerUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            SqlConnection sqlConnection = conexionDatos.conexion();

            SqlCommand sqlCommand = new SqlCommand("select * from tabla;", sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Usuarios dato= new Usuarios();
                dato.usuario = (reader["usuario"].ToString());
                dato.contraseña = (reader["contraseña"].ToString());

                listaUsuarios.Add(dato);

            }
            sqlConnection.Close();
            return listaUsuarios;
        }
        
        public bool registrarUsuario(Usuarios nuevoUsuario)
        {
            SqlConnection sqlConnection = conexionDatos.conexion();
            sqlConnection.Open();
           
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tabla"
                    + "()"
                    , sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nombre", nuevoUsuario.usuario);
                sqlCommand.Parameters.AddWithValue("@contraseña", nuevoUsuario.contraseña);
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
