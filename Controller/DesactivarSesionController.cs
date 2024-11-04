using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    public class DesactivarSesionController
    {
        private DBCONTE dbConte;

        public DesactivarSesionController()
        {
            dbConte = new DBCONTE();
        }
        public string DesactivarSesion(int idSesion)
        {
            // Llamar al método del modelo para crear la sesión
            return dbConte.DesactivarSesion(idSesion);
        }
    }
}
