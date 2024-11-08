using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class PromedioAsientosOcupadosYCantidadSesiones
    {
        private DBCONTE dbConte;

        public PromedioAsientosOcupadosYCantidadSesiones()
        {
            dbConte = new DBCONTE();
        }

        public DataTable PromedioAsientosOcupadosYCantidadSesione(string Sala)
        {
            return dbConte.PromedioAsientosOcupadosYCantidadSesiones(Sala);
        }
    }
}
