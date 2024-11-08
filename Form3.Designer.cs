namespace CINEBD
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_aadccb_cinebdDataSet = new CINEBD.db_aadccb_cinebdDataSet();
            this.promedioAsientosOcupadosYCantidadSesionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.promedioAsientosOcupadosYCantidadSesionesTableAdapter = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.PromedioAsientosOcupadosYCantidadSesionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promedioAsientosOcupadosYCantidadSesionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // db_aadccb_cinebdDataSet
            // 
            this.db_aadccb_cinebdDataSet.DataSetName = "db_aadccb_cinebdDataSet";
            this.db_aadccb_cinebdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // promedioAsientosOcupadosYCantidadSesionesBindingSource
            // 
            this.promedioAsientosOcupadosYCantidadSesionesBindingSource.DataMember = "PromedioAsientosOcupadosYCantidadSesiones";
            this.promedioAsientosOcupadosYCantidadSesionesBindingSource.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // promedioAsientosOcupadosYCantidadSesionesTableAdapter
            // 
            this.promedioAsientosOcupadosYCantidadSesionesTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promedioAsientosOcupadosYCantidadSesionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource promedioAsientosOcupadosYCantidadSesionesBindingSource;
        private db_aadccb_cinebdDataSet db_aadccb_cinebdDataSet;
        private db_aadccb_cinebdDataSetTableAdapters.PromedioAsientosOcupadosYCantidadSesionesTableAdapter promedioAsientosOcupadosYCantidadSesionesTableAdapter;
    }
}