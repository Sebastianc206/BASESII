using CINEBD.Controller;
using CINEBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CINEBD
{
    public partial class InicioSesion : Form
    {
        private LoginController loginController;
        public InicioSesion()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombreUsuario = textBox1.Text.Trim();
            string contraseña = textBox2.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("El campo 'Nombre de Usuario' no puede estar vacío.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("El campo 'Contraseña' no puede estar vacío.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al controlador para verificar el usuario
            string rol;
            string resultado = loginController.VerificarUsuario(nombreUsuario, contraseña, out rol);

            // Mostrar el resultado en un MessageBox
            if (resultado.Contains("ERROR"))
            {
                MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar el usuario actual para el contexto de sesión
                Model.SesionContext.CurrentUser = nombreUsuario;  // Aquí guardamos el nombre del usuario en una clase estática

                View.Submenu operador = new View.Submenu(rol);
                operador.Show();
                this.Hide();
            }

        }
    }
    }
   
