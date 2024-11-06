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

        public CambioAsiento()
        {
            InitializeComponent();

            asientoController = new VerAsientosController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text, out int idSesion) || !int.TryParse(textBox2.Text, out int idTransaccion))
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
    }
}
