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
    public partial class Rep3 : Form
    {
        public Rep3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Sesion = textBox1.Text.Trim();
            Form3 Reporte1 = new Form3(Sesion);
            Reporte1.sala = Sesion;
            Reporte1.ShowDialog();
        }
    }
}
