using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{

    internal class Top5PeliculasMayorPromedioAsientosVendidos
    {
        private DBCONTE dbConte;

        public Top5PeliculasMayorPromedioAsientosVendidos()
        {
            dbConte = new DBCONTE();
        }

        public DataTable Top5PeliculasMayorPromedioAsientosVendido()
        {
            return dbConte.Top5PeliculasMayorPromedioAsientosVendidos();
        }
    }
}
