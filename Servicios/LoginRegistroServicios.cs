using AccesoData;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class LoginRegistroServicios
    {
        private Datos datos = new Datos();
        
        public List<Usuarios> ObtenerUsuarios()
        {
            return datos.obtenerUsuarios();
        }
     
        public bool registrarUsuario(Usuarios nuevoUsuario)
        {
            bool valida = false;
            bool result = false;
            valida = existe(nuevoUsuario.id, nuevoUsuario.usuario, nuevoUsuario.contraseña);
            if (valida)
            {
                result = datos.registrarUsuario(nuevoUsuario);
            }
            
            return result;
        }

        public bool existe(int id, string nombre, string contraseña)
        {
            return datos.existe(id, nombre, contraseña);
        }
    }
}
