using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    public class AsientoController
    {
        private DBCONTE dbConte;

        public AsientoController()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ObtenerAsientosPorSala(int idSala, int idSesion)
        {
            return dbConte.ObtenerAsientosPorSala(idSala, idSesion);
        }
    }
}
