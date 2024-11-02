using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEBD.View
{
    public partial class Submenu : Form
    {
        private string usuarioRol;

        public Submenu(String rol)
        {
            InitializeComponent();
            usuarioRol = rol;
            ConfigurarAccesoPorRol();
        }

        private void ConfigurarAccesoPorRol()
        {
            if (usuarioRol == "Operador")
            {
                // Habilitar todos los botones
                btn_pelicula.Enabled = false;
                btn_anulacion.Enabled = false;
                // Agregar aquí más botones si es necesario
            }        
        }

            private void button1_Click(object sender, EventArgs e)
        {
            View.ComprarEntrada compra = new View.ComprarEntrada();
            compra.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            View.CrearPelicula crearPelicula = new View.CrearPelicula();
            crearPelicula.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            View.AsignarSesion asignarSesion = new View.AsignarSesion();
            asignarSesion.Show();
        }
    }
}
