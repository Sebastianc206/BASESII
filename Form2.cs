using CINEBD.Controller;
using CINEBD.Model;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.DataProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEBD
{
    public partial class Form2 : Form
    {
        

        private ListadoTransaccionesConAsientos listTranAsi;
        public DateTime FechaInicio;
        public DateTime FechaFin;
        public Form2(DateTime FechaInicio1, DateTime FechaFin1)
        {
            InitializeComponent();
            listTranAsi = new ListadoTransaccionesConAsientos();
            FechaInicio = FechaInicio1;
            FechaFin = FechaFin1;
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable transacciones = listTranAsi.ListadoTransaccionesConAsiento(FechaInicio, FechaFin);

            if (transacciones != null && transacciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = transacciones;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No se encontraron asientos para la sesión y transacción seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
