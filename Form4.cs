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
    public partial class Form4 : Form
    {
        private SesionesAsientosOcupadosBajoPorcentaje listSesi;
        public string sala1;
        public string prom1;
        public Form4(string sala, string prom)
        {
            InitializeComponent();
            listSesi = new SesionesAsientosOcupadosBajoPorcentaje();
            sala1 = sala;
            prom1 = prom;
        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable transacciones = listSesi.SesionesAsientosOcupadosBajoPorcentaj(sala1, prom1);

            if (transacciones != null && transacciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = transacciones;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No se encontraron asientos para la sesión seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
