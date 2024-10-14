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
    public partial class Form1 : Form
    {
        private LoginController loginController;

        public Form1()
        {
            InitializeComponent();
            loginController = new LoginController();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y contraseña del formulario
            string nombre = textBox1.Text;
            string contraseña = textBox2.Text;

            try
            {
                // Instanciar el helper de base de datos (DatabaseHelper es la clase que creaste antes)
                DBCONTE dBCONTE = new DBCONTE();

                // Verificar el usuario llamando al procedimiento almacenado
                (int resultado, string rol) = dBCONTE.VerificarUsuario(nombre, contraseña);

                // Si el resultado es 1, significa que el usuario y contraseña son correctos
                if (resultado == 1)
                {
                    if (rol == "Admin")
                    {
                        MessageBox.Show("Bienvenido Administrador");
                        View.Operador form2 = new View.Operador();  // Crear instancia del segundo formulario
                        form2.Show();               // Mostrar el segundo formulario
                        this.Hide();
                    }
                    else if (rol == "Operador")
                    {
                        MessageBox.Show("Bienvenido Operador");

                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
