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
    public partial class Rep4 : Form
    {
        public Rep4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sesion = textBox1.Text.Trim();
            string Promedio = textBox2.Text.Trim();
            Form4 Reporte1 = new Form4(Sesion, Promedio);
            Reporte1.sala1 = Sesion;
            Reporte1.prom1 = Promedio;
            Reporte1.ShowDialog();
        }
    }
}
