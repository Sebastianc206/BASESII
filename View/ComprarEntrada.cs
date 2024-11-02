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

    public partial class ComprarEntrada : Form
    {
        private AsientoController asientoController; // Instancia del controlador

        public ComprarEntrada()
        {
            InitializeComponent();
            asientoController = new AsientoController(); // Inicializar el controlador en el constructor

        }

        private void Compra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet1.Asiento' Puede moverla o quitarla según sea necesario.
            this.asientoTableAdapter1.Fill(this.cINEBD2DataSet1.Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Transaccion_Asiento' Puede moverla o quitarla según sea necesario.
            this.transaccion_AsientoTableAdapter1.Fill(this.cINEBD2DataSet.Transaccion_Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Asiento' Puede moverla o quitarla según sea necesario.
            this.asientoTableAdapter1.Fill(this.cINEBD2DataSet.Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.SALA' Puede moverla o quitarla según sea necesario.
            this.sALATableAdapter1.Fill(this.cINEBD2DataSet.SALA);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter1.Fill(this.cINEBD2DataSet.Pelicula);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.asientoTableAdapter.FillBy(this.cINEBDDataSet.Asiento);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una sesión primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extraer los valores seleccionados en el DataGridView
            int idSesion = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID_Sesion"].Value);
            int idSala = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID_Sala"].Value);

            // Obtener los asientos usando el controlador
            DataTable asientos = asientoController.ObtenerAsientosPorSala(idSala, idSesion);

            // Verificar si se obtuvieron datos
            if (asientos != null && asientos.Rows.Count > 0)
            {
                dataGridView1.DataSource = asientos; // Cargar los asientos en el segundo DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else
            {
                MessageBox.Show("No se encontraron asientos para la sesión seleccionada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar una fila completa.
            dataGridView2.MultiSelect = false; // Deshabilita la selección múltiple.

        }
    }
}