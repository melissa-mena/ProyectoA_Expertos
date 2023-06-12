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
        
        public List<UsuariosTest> ObtenerUsuarios(float distancia ,string intelignecia,int id)
        {
            return datos.obtenerTestUsuarios(distancia, intelignecia, id);
        }
     
        public bool registrarUsuarioTest(UsuariosTest nuevoUsuario, Usuarios user)
        {
            int valida ;
            bool result = false;
            valida = getuserId(user.usuario,user.contraseña);
            nuevoUsuario.IdUser = valida;
            result = datos.registrarTestUsuario(nuevoUsuario);
            return result;
        }

        public int getuserId(string name,string password)
        {
            return datos.existe(name,password);
        }
    }
}
