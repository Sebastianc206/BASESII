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

    public partial class ComprarEntrada : Form
    {
        private AsientoController asientoController; // Instancia del controlador
        private VentaController ventaController;
        private bool esCompraAutomatica;
        public ComprarEntrada(bool esAutomatica)
        {
            InitializeComponent();
            asientoController = new AsientoController(); // Inicializar el controlador en el constructor
            ventaController = new VentaController();
            this.esCompraAutomatica = esAutomatica;

            if (esCompraAutomatica)
            {
                // Desactivar la selección manual de asientos si es compra automática
                dataGridView1.Enabled = false;
            }
            else
            {
                // Activar la selección manual de asientos si es compra manual
                dataGridView1.Enabled = true;
            }
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'db_aadccb_cinebdDataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter2.Fill(this.db_aadccb_cinebdDataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'db_aadccb_cinebdDataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter2.Fill(this.db_aadccb_cinebdDataSet.Pelicula);
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
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una sesión primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Permitir solo números y teclas de control como retroceso

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
                    dataGridView1.Columns["ID_Sala"].HeaderText = "No.Sala";

                    dataGridView1.ClearSelection();

                }
                else
                {
                    MessageBox.Show("No se encontraron asientos para la sesión seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; // Limpiar el DataGridView si no se encontraron registros
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los asientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar una fila completa.
            dataGridView2.MultiSelect = false; // Deshabilita la selección múltiple.

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una sesión
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una sesión primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores ingresados por el usuario
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int idSesion = Convert.ToInt32(selectedRow.Cells["ID_Sesion"].Value);
                string nombreUsuario = SesionContext.CurrentUser; // Aquí debes obtener el nombre del usuario que ha iniciado sesión
                if (!int.TryParse(textBox1.Text, out int cantAsientos) || cantAsientos <= 0)
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida de asientos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string resultado = string.Empty;


                // Verificar el tipo de compra (manual o automática)
                if (esCompraAutomatica)
                {
                    int idTipoAsignacion = 1;
                    // Llamar al método para realizar la venta de boletos de forma automática
                    resultado = ventaController.VentaBoletos(idSesion, nombreUsuario, cantAsientos, idTipoAsignacion);

                    // Mostrar el resultado en un MessageBox
                    if (resultado.Contains("ERROR"))
                    {
                        MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar el DataGridView para reflejar los cambios en los asientos
                        button1_Click(sender, e);
                    }
                }
                else
                {
                    // Compra manual
                    int idTipoAsignacion = 2;
                    string asientosTipoManual = null;

                    if (dataGridView1.SelectedRows.Count < cantAsientos)
                    {
                        MessageBox.Show("La cantidad de asientos seleccionados no es suficiente.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dataGridView1.SelectedRows.Count != cantAsientos)
                    {
                        MessageBox.Show("La cantidad de asientos seleccionados no coincide con la cantidad ingresada.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    asientosTipoManual = string.Join(",", dataGridView1.SelectedRows.Cast<DataGridViewRow>().Take(cantAsientos).Select(row => $"{row.Cells["Fila"].Value}{row.Cells["Numero"].Value}"));

                    // Llamar al método para realizar la venta de boletos de forma manual
                    resultado = ventaController.VentaBoletos(idSesion, nombreUsuario, cantAsientos, idTipoAsignacion, asientosTipoManual);

                    // Mostrar el resultado en un MessageBox
                    if (resultado.Contains("ERROR"))
                    {
                        MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar el DataGridView para reflejar los cambios en los asientos
                        button1_Click(sender, e);
                        dataGridView1.ClearSelection(); // Limpiar la selección para reflejar que la compra se realizó correctamente.

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows.Count.ToString();
            }
            else
            {
                textBox1.Text = "0";
            }
            // En la compra automática no se permite seleccionar asientos manualmente
            if (esCompraAutomatica)
            {
                dataGridView1.ClearSelection();
                textBox1.Text = "0";
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true; // Permitir la selección de múltiples asientos
        }

       
    }
}