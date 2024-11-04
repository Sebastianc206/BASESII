using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    public class ObtenerSesionesController
    {
        private DBCONTE dbConte;

        public ObtenerSesionesController()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ObtenerSesiones(int idPelicula, int idSala)
        {
            return dbConte.ObtenerSesiones(idPelicula, idSala);
        }
    }
}
