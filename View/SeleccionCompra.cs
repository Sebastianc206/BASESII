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
    public partial class SeleccionCompra : Form
    {
        public SeleccionCompra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.ComprarEntrada compra = new View.ComprarEntrada(false);
            compra.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View.ComprarEntrada compra = new View.ComprarEntrada(true);
            compra.Show();
            this.Hide();
        }
    }
}
