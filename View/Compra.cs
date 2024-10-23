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
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet1.Asiento' Puede moverla o quitarla según sea necesario.
            this.asientoTableAdapter1.Fill(this.cINEBD2DataSet1.Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Transaccion_Asiento' Puede moverla o quitarla según sea necesario.
            this.transaccion_AsientoTableAdapter1.Fill(this.cINEBD2DataSet.Transaccion_Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Asiento' Puede moverla o quitarla según sea necesario.
            this.asientoTableAdapter1.Fill(this.cINEBD2DataSet.Asiento);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.SALA' Puede moverla o quitarla según sea necesario.
            this.sALATableAdapter1.Fill(this.cINEBD2DataSet.SALA);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Sesion' Puede moverla o quitarla según sea necesario.
            this.sesionTableAdapter1.Fill(this.cINEBD2DataSet.Sesion);
            // TODO: esta línea de código carga datos en la tabla 'cINEBD2DataSet.Pelicula' Puede moverla o quitarla según sea necesario.
            this.peliculaTableAdapter1.Fill(this.cINEBD2DataSet.Pelicula);

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
