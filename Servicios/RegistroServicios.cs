using AccesoData;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class RegistroServicios
    {
        private DatosTest datos = new DatosTest();
        
        public List<UsuariosTest> ObtenerUsuarios()
        {
            return datos.obtenerTestUsuarios();
        }
     
        public bool registrarUsuario(Usuarios nuevoUsuario)
        {
            bool valida = false;
            bool result = false;
            valida = existe(nuevoUsuario.id, nuevoUsuario.nombre, nuevoUsuario.contraseña);
            if (valida)
            {
                result = datos.registrarTestUsuario(nuevoUsuario);
            }
            
            return result;
        }

        public bool existe(int id, string nombre, string contraseña)
        {
            return datos.existe(id, nombre, contraseña);
        }
    }
}
