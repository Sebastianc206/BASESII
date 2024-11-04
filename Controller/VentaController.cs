using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class VentaController
    {
        private DBCONTE dbConte;

        public VentaController()
        {
            dbConte = new DBCONTE();
        }
        public string VentaBoletos(int idSesion, string nombreUsuario, int cantAsientos, int idTipoAsignacion, string asientosTipoManual = null)
        {
            // Llamar al método del modelo para crear la sesión
            return dbConte.VentaBoletos(idSesion, nombreUsuario, cantAsientos, idTipoAsignacion, asientosTipoManual);
        }
    }
}
