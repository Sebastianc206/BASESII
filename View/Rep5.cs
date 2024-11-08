using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace CINEBD.View
{
    public partial class Rep5 : Form
    {
        public Rep5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 Reporte1 = new Form5();
            Reporte1.ShowDialog();
        }
    }
}
