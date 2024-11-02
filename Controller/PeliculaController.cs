using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    internal class PeliculaController
    {
        private DBCONTE dbConte;

        public PeliculaController()
        {
            dbConte = new DBCONTE();
        }
        public string CrearPelicula(string nombre, string clasificacion, int duracion, string descripcion)
        {
            // Llamar al método del modelo para crear la película
            return dbConte.CrearPelicula(nombre, clasificacion, duracion, descripcion);
        }
    }
}
