using CINEBD.Controller;
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
    public partial class CrearPelicula : Form
    {
        private PeliculaController Peliculacontroller;
        public CrearPelicula()
        {
            InitializeComponent();
            Peliculacontroller = new PeliculaController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombrePelicula = textBox1.Text.Trim();
            string clasificacion = listBox1.Text.Trim();
            int duracion;
            string descripcion = textBox3.Text.Trim();


            if (!int.TryParse(textBox2.Text, out duracion))
            {
                MessageBox.Show("Por favor ingrese una duración válida (número entero).", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(nombrePelicula))
            {
                MessageBox.Show("El campo 'Nombre' no puede estar vacío.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(clasificacion))
            {
                MessageBox.Show("Debe seleccionar una clasificación.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("El campo 'Descripción' no puede estar vacío.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al controlador para crear la película
            string resultado = Peliculacontroller.CrearPelicula(nombrePelicula, clasificacion, duracion, descripcion);

            // Mostrar el resultado en un MessageBox
            if (resultado.Contains("ERROR"))
            {
                MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar los campos después de crear la película
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                listBox1.ClearSelected();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View.AsignarSesion asignarSesion = new View.AsignarSesion();
            asignarSesion.Show();
            this.Close();
        }
    }
}
    
