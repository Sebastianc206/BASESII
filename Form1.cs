using CINEBD.db_aadccb_cinebdDataSetTableAdapters;
using CINEBD.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEBD
{
    public partial class Form1 : Form
    {
        private DBCONTE dbConte;

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Form1(DateTime FechaInicio1, DateTime FechaFin1)
        {
            InitializeComponent();
            dbConte = new DBCONTE();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable miDataTable = dbConte.ListadoSesionesConAsientosOcupados(FechaInicio, FechaFin);

            // Crear un ReportDataSource y asignar el DataTable
            ReportDataSource dataSource = new ReportDataSource("DataSet1", miDataTable);

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = miDataTable;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
