using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    public class Sala
    {
        private DBCONTE dbConte;

        public Sala()
        {
            dbConte = new DBCONTE();
        }

        public DataTable ObtenerAsientosPorSala(int idSala)
        {
            return dbConte.ObtenerAsientosPorSala(idSala);
        }
    }
}
