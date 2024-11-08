using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class ListadoTransaccionesConAsientos
    {
        private DBCONTE dbConte;

        public ListadoTransaccionesConAsientos()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ListadoTransaccionesConAsiento(DateTime FechaInicio1, DateTime FechaFin1)
        {
            return dbConte.ListadoTransaccionesConAsientos(FechaInicio1, FechaFin1);
        }
    }
}
