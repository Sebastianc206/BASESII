using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class VerAsientosController
    {
        private DBCONTE dbConte;

        public VerAsientosController()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ObtenerAsientosPorSesionYTransaccion(int idSesion, int idTransaccion)
        {
            return dbConte.ObtenerAsientosPorSesionYTransaccion(idSesion, idTransaccion);
        }
    }
}
