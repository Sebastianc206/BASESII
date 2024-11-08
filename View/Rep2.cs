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
    public partial class Rep2 : Form
    {
        public Rep2()
        {
            InitializeComponent();
        }
        public DateTime FechaInicio;
        public DateTime FechaFin;

        private void button1_Click(object sender, EventArgs e)
        {
            FechaInicio = dateTimePicker1.Value;
            FechaFin = dateTimePicker2.Value;
            Form2 Reporte1 = new Form2(FechaInicio, FechaFin);
            Reporte1.FechaInicio = dateTimePicker1.Value;
            Reporte1.FechaFin = dateTimePicker2.Value;
            Reporte1.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
