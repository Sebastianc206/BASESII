using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class CambioController
    {
        private DBCONTE dBCONTE;

        public CambioController()
        {
            dBCONTE = new DBCONTE();
        }

        public string CambiarBoletos(int idTransaccion, int idSesion, string asientosAntiguos, string nuevosAsientos)
        {
            // Llamar al método del modelo para crear la sesión
            return dBCONTE.CambiarBoletos(idTransaccion, idSesion, asientosAntiguos, nuevosAsientos);
        }
    }
}
