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
    public partial class Form3 : Form
    {

        private PromedioAsientosOcupadosYCantidadSesiones Prom;
        public string sala;
       
        public Form3(string Sala1)
        {
            InitializeComponent();
            Prom = new PromedioAsientosOcupadosYCantidadSesiones();
            sala = Sala1;
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable transacciones = Prom.PromedioAsientosOcupadosYCantidadSesione(sala);

            if (transacciones != null && transacciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = transacciones;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No se encontraron Salas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
