using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class SesionController
    {
        private DBCONTE dBCONTE;

        public SesionController()
        {
            dBCONTE = new DBCONTE();
        }

        public string CrearSesion(DateTime fechaInicio, int idSala, int idPelicula)
        {
            // Llamar al método del modelo para crear la sesión
            return dBCONTE.CrearSesion(fechaInicio, idSala, idPelicula);
        }
    }
}
