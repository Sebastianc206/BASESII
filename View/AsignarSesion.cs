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
    public partial class AsignarSesion : Form
    {
        private SesionController sesionController;

        public AsignarSesion()
        {
            InitializeComponent();
            sesionController = new SesionController();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AsignarSesion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.SALA' Puede moverla o quitarla según sea necesario.
            this.sALATableAdapter.Fill(this.cINEBD2DataSet.SALA);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter.Fill(this.cINEBD2DataSet.Pelicula);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            DateTime fechaInicio = dateTimePicker1.Value;
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala y una película válidas.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idSala = (int)comboBox2.SelectedValue;
            int idPelicula = (int)comboBox1.SelectedValue;


            // Llamar al controlador para crear la sesión
            string resultado = sesionController.CrearSesion(fechaInicio, idSala, idPelicula);

            // Mostrar el resultado en un MessageBox
            if (resultado.Contains("ERROR"))
            {
                MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya un elemento seleccionado
            if (comboBox1.SelectedValue != null && comboBox1.SelectedItem is DataRowView selectedRow)
            {
                // Obtener la duración de la película seleccionada
                int duracion = Convert.ToInt32(selectedRow["Duracion"]);

                // Mostrar la duración en el TextBox
                textBox1.Text = duracion.ToString();
            }
        }
    }
}
