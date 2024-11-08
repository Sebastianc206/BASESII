using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class sp_LogTransacciones_RangoFecha
    {
        private DBCONTE dbConte;

        public sp_LogTransacciones_RangoFecha()
        {
            dbConte = new DBCONTE();
        }

        public DataTable sp_LogTransacciones_RangoFech(DateTime FechaInicio1, DateTime FechaFin1)
        {
            return dbConte.sp_LogTransacciones_RangoFecha(FechaInicio1, FechaFin1);
        }
    }
}
