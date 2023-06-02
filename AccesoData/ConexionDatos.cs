﻿using System;
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
            return new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ExpertosConnectionString"].ConnectionString);
        }

        public object[] loguearse(String usuario)
        {
            object[] rolNombreCompleto = new object[2];
            SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["LOGINConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("select   from " +
                "   " +
                "where  " +
                " =  and  =  ;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {

                int rol = Int32.Parse(reader.GetValue(0).ToString());
                String nombreCompleto = reader.GetValue(1).ToString();

                rolNombreCompleto[0] = rol;
                rolNombreCompleto[1] = nombreCompleto;
            }

            sqlConnection.Close();

            return rolNombreCompleto;
        }
    }
}