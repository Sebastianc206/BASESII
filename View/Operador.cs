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
    public partial class Operador : Form
    {
        public Operador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.Sesiones compra = new View.Sesiones();
            compra.Show();
            this.Hide();
        }
    }
}
