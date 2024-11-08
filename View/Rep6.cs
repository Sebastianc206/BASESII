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
    public partial class Rep6 : Form
    {
        public Rep6()
        {
            InitializeComponent();
        }

        public DateTime FechaInicio;
        public DateTime FechaFin;

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 Reporte1 = new Form6(FechaInicio, FechaFin);
            Reporte1.FechaInicio = dateTimePicker1.Value;
            Reporte1.FechaFin = dateTimePicker2.Value;

            Reporte1.ShowDialog();
        }
    }
}
