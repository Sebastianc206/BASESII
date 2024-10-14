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
    public partial class Compra : Form
    {
        public Compra()
        {
            InitializeComponent();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cINEBDDataSet.Asiento' Puede moverla o quitarla según sea necesario.
            this.asientoTableAdapter.Fill(this.cINEBDDataSet.Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBDDataSet.SALA' Puede moverla o quitarla según sea necesario.
            this.sALATableAdapter.Fill(this.cINEBDDataSet.SALA);
            // TODO: esta línea de código carga datos en la tabla 'cINEBDDataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter.Fill(this.cINEBDDataSet.Pelicula);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.asientoTableAdapter.FillBy(this.cINEBDDataSet.Asiento);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
