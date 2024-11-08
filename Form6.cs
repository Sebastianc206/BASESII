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

namespace CINEBD
{
    public partial class Form6 : Form
    {
        private sp_LogTransacciones_RangoFecha logTran;
        public DateTime FechaInicio;
        public DateTime FechaFin;
        public Form6(DateTime FechaInicio1, DateTime FechaFin1)
        {
            InitializeComponent();
            logTran = new sp_LogTransacciones_RangoFecha();
            FechaInicio = FechaInicio1;
            FechaFin = FechaFin1;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DataTable transacciones = logTran.sp_LogTransacciones_RangoFech(FechaInicio, FechaFin);

            if (transacciones != null && transacciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = transacciones;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No se enotraron logs de Transacciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
