﻿using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public string VerificarUsuario(string nombre, string contraseña, out string rol)
        {
            // Llamar al método del modelo para verificar el usuario
            return dBCONTE.VerificarUsuario(nombre, contraseña, out rol);
        }
    }
}
