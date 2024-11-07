using CINEBD.Controller;
using CINEBD.Model;
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
    public partial class DesactivarSesion : Form
    {
        private ObtenerSesionesController ObtenerSesionesController;
        private DesactivarSesionController DesactivarSesionController;
        public DesactivarSesion()
        {
            InitializeComponent();
            ObtenerSesionesController = new ObtenerSesionesController();
            DesactivarSesionController = new DesactivarSesionController();
        }

        private void DesactivarSesion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'db_aadccb_cinebdDataSet.SALA' Puede moverla o quitarla según sea necesario.
            this.sALATableAdapter1.Fill(this.db_aadccb_cinebdDataSet.SALA);
            // TODO: esta línea de código carga datos en la tabla 'db_aadccb_cinebdDataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter1.Fill(this.db_aadccb_cinebdDataSet.Pelicula);
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados de los ComboBox
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una película y una sala.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPelicula = Convert.ToInt32(comboBox1.SelectedValue);
            int idSala = Convert.ToInt32(comboBox2.SelectedValue);

            try
            {
                // Obtener los datos de las sesiones mediante el procedimiento almacenado
                DataTable sesiones = ObtenerSesionesController.ObtenerSesiones(idPelicula, idSala);

                // Verificar si se encontraron registros
                if (sesiones.Rows.Count > 0)
                {
                    // Asignar el DataTable al DataGridView
                    dataGridView1.DataSource = sesiones;

                    // Configurar encabezados para las columnas
                    dataGridView1.Columns["ID_Sesion"].HeaderText = "ID Sesión";
                    dataGridView1.Columns["Fecha_Inicio"].HeaderText = "Fecha de Inicio";
                    dataGridView1.Columns["Fecha_Fin"].HeaderText = "Fecha de Fin";
                    dataGridView1.Columns["Estado"].HeaderText = "Estado";
                    dataGridView1.Columns["ID_Sala"].HeaderText = "NoSala";
                    dataGridView1.Columns["NombrePelicula"].HeaderText = "Película";
                    dataGridView1.Columns["Clasificacion"].HeaderText = "Clasificación";
                    dataGridView1.Columns["Duracion"].HeaderText = "Duración";
                    dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";

                    // Configurar el DataGridView para ser solo de lectura
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false; // Permitir solo una selección a la vez
                    dataGridView1.ClearSelection();
                    dataGridView1.Enabled = true; // Mantener habilitado para permitir el desplazamiento
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna sesión para la película y sala seleccionadas.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; // Limpiar el DataGridView si no se encontraron registros
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una sesión para desactivar.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID_Sesion de la fila seleccionada
            int idSesion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Sesion"].Value);

            // Llamar al método para desactivar la sesión
            string resultado = DesactivarSesionController.DesactivarSesion(idSesion);

            // Mostrar el resultado en un MessageBox
            if (resultado.Contains("ERROR"))
            {
                MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar el DataGridView para reflejar los cambios
                button1_Click(sender, e);
            }
        }
    }
}
