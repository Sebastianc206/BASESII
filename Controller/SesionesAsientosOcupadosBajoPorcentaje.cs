using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class SesionesAsientosOcupadosBajoPorcentaje
    {
        private DBCONTE dbConte;

        public SesionesAsientosOcupadosBajoPorcentaje()
        {
            dbConte = new DBCONTE();
        }

        public DataTable SesionesAsientosOcupadosBajoPorcentaj(string Sala, string Porcentaje)
        {
            return dbConte.SesionesAsientosOcupadosBajoPorcentaje(Sala, Porcentaje);
        }
    }
}
