using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEBD.Controller
{
    public class LoginController
    {
        private DBCONTE dBCONTE;

        public LoginController()
        {
            dBCONTE = new DBCONTE();
        }

        public (bool, string) IniciarSesion(string nombre, string contraseña)
        {
            var resultado = dBCONTE.VerificarUsuario(nombre, contraseña);

            if (resultado.Item1 == 1)
            {
                return (true, resultado.Item2);  // Sesión iniciada con éxito, devuelve el rol
            }
            else if (resultado.Item1 == -1)
            {
                return (false, "El usuario no existe.");
            }
            else if (resultado.Item1 == -2)
            {
                return (false, "Contraseña incorrecta.");
            }
            else
            {
                return (false, "Error en el inicio de sesión.");
            }
        }
    }
}
