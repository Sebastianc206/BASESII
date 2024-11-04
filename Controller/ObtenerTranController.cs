using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class ObtenerTranController
    {
        private DBCONTE dbConte;

        public ObtenerTranController()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ObtenerTransaccion(int idTransaccion)
        {
            return dbConte.ObtenerAsignaciones(idTransaccion);
        }
    }
}
