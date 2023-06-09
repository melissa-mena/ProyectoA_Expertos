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
        
        public List<UsuariosTest> ObtenerUsuarios(float distancia ,string intelignecia)
        {
            return datos.obtenerTestUsuarios(distancia, intelignecia);
        }
     
        public bool registrarUsuarioTest(UsuariosTest nuevoUsuario)
        {
            bool valida = false;
            bool result = false;
            //valida = existe(nuevoUsuario.IdUser, nuevoUsuario.Distance, nuevoUsuario.IntelligenceType);
            //if (valida)
            //{
                result = datos.registrarTestUsuario(nuevoUsuario);
            //}
            
            return result;
        }

        //public bool existe(int id, float distance, string contraseña)
        //{
        //    return datos.existe(id, distance, contraseña);
        //}
    }
}
