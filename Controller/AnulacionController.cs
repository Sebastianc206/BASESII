using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class AnulacionController
    {
        private DBCONTE dbConte;

        public AnulacionController()
        {
            dbConte = new DBCONTE();
        }
        public string AnularTransaccion(int idTransaccion)
        {
            // Llamar al método del modelo para crear la película
            return dbConte.AnularTransaccion(idTransaccion);
        }
    }
}
