using CINEBD.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEBD
{
    public partial class Form5 : Form
    {
        private Top5PeliculasMayorPromedioAsientosVendidos top5;
  
        public Form5()
        {
            InitializeComponent();
            top5 = new Top5PeliculasMayorPromedioAsientosVendidos();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable transacciones = top5.Top5PeliculasMayorPromedioAsientosVendido();

            if (transacciones != null && transacciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = transacciones;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No se encontraron Peliculas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
