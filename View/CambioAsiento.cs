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
    public partial class CambioAsiento : Form
    {
        private VerAsientosController asientoController;
        private CambioController cambioController;
        public CambioAsiento()
        {
            InitializeComponent();
            cambioController = new CambioController();
            asientoController = new VerAsientosController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox2.Text, out int idSesion) || !int.TryParse(textBox1.Text, out int idTransaccion))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para el ID de Sesión y ID de Transacción.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable asientos = asientoController.ObtenerAsientosPorSesionYTransaccion(idSesion, idTransaccion);

                if (asientos != null && asientos.Rows.Count > 0)
                {
                    dataGridView1.DataSource = asientos;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No se encontraron asientos para la sesión y transacción seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ver los asientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se hayan ingresado los ID de sesión y transacción
                if (!int.TryParse(textBox4.Text, out int idSesion) || !int.TryParse(textBox1.Text, out int idTransaccion))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para el ID de Sesión y ID de Transacción.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los asientos antiguos
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione los asientos que desea cambiar.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string asientosAntiguos = string.Join(",", dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(row => $"{row.Cells["Fila"].Value}{row.Cells["Numero"].Value}"));

                // Validar el formato de los nuevos asientos ingresados
                string nuevosAsientos = textBox3.Text.Trim();
                if (string.IsNullOrEmpty(nuevosAsientos))
                {
                    MessageBox.Show("Por favor, ingrese los nuevos asientos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar el formato de los nuevos asientos (Ejemplo: A1,A2,...)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nuevosAsientos, @"^[A-Z]\d+(,[A-Z]\d+)*$"))
                {
                    MessageBox.Show("Por favor, ingrese los nuevos asientos en el formato correcto (Ejemplo: A1,A2,...).", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método del controlador para cambiar los boletos
                string resultado = cambioController.CambiarBoletos(idTransaccion, idSesion, asientosAntiguos, nuevosAsientos);

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
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar los asientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
