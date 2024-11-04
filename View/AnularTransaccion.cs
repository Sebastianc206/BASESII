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
    public partial class AnularTransaccion : Form
    {
        private AnulacionController controller;
        private ObtenerTranController ObtenerTranController;
        public AnularTransaccion()
        {
            InitializeComponent();
            controller = new AnulacionController();
            ObtenerTranController = new ObtenerTranController();
            // Aplicar un filtro imposible para que el DataGridView esté vacío al iniciar
        }

        private void AnularTransaccion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Transaccion_Asiento' Puede moverla o quitarla según sea necesario.
            this.transaccion_AsientoTableAdapter.Fill(this.cINEBD2DataSet.Transaccion_Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Transaccion' Puede moverla o quitarla según sea necesario.
            this.transaccionTableAdapter.Fill(this.cINEBD2DataSet.Transaccion);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroTransaccion = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numeroTransaccion))
            {
                MessageBox.Show("Por favor ingrese un número de transacción.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validar que el valor ingresado sea numérico
                if (!int.TryParse(numeroTransaccion, out int idTransaccion))
                {
                    MessageBox.Show("Por favor ingrese un número válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los datos de las asignaciones mediante el procedimiento almacenado
                DataTable asignaciones = ObtenerTranController.ObtenerTransaccion(idTransaccion);

                // Verificar si se encontraron registros
                if (asignaciones.Rows.Count > 0)
                {
                    // Asignar el DataTable al DataGridView
                    dataGridView1.DataSource = asignaciones;

                    dataGridView1.Columns["ID_Transaccion"].HeaderText = "NoTransaccion";
                    dataGridView1.Columns["Estado_Asignacion"].HeaderText = "Estado de Asignación";
                    dataGridView1.Columns["Fecha_Hora_Asignacion"].HeaderText = "Fecha y Hora de Asignación";
                    dataGridView1.Columns["Fila"].HeaderText = "Fila";
                    dataGridView1.Columns["Numero"].HeaderText = "Número de Asiento";
                    dataGridView1.Columns["ID_Sala"].HeaderText = "Número de Sala";
                    dataGridView1.Columns["Usuario"].HeaderText = "Usuario";

                    // Configurar el DataGridView para ser solo de lectura
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ClearSelection();
                    dataGridView1.Enabled = true; // Mantener habilitado para permitir el desplazamiento
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna asignación con el número de transacción ingresado.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; // Limpiar el DataGridView si no se encontraron registros
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el número de transacción del TextBox
            string numeroTransaccion = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numeroTransaccion) || !int.TryParse(numeroTransaccion, out int idTransaccion))
            {
                MessageBox.Show("Por favor ingrese un número de transacción válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al método para anular la transacción
            string resultado = controller.AnularTransaccion(idTransaccion);

            // Mostrar el resultado en un MessageBox
            if (resultado.Contains("ERROR"))
            {
                MessageBox.Show(resultado, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar el DataGridView con los datos más recientes
                DataTable asignacionesActualizadas = ObtenerTranController.ObtenerTransaccion(idTransaccion);
                dataGridView1.DataSource = asignacionesActualizadas;
                dataGridView1.Refresh();
            }
            textBox1.Text = string.Empty;
        }
    }
}
