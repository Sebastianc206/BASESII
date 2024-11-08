namespace CINEBD
{
    partial class Form1
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
            this.listadoSesionesConAsientosOcupadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_aadccb_cinebdDataSet = new CINEBD.db_aadccb_cinebdDataSet();
            this.listadoSesionesConAsientosOcupadosTableAdapter = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.ListadoSesionesConAsientosOcupadosTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDSesionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDSalaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDPeliculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePeliculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asientosOcupadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listadoSesionesConAsientosOcupadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoSesionesConAsientosOcupadosBindingSource
            // 
            this.listadoSesionesConAsientosOcupadosBindingSource.DataMember = "ListadoSesionesConAsientosOcupados";
            this.listadoSesionesConAsientosOcupadosBindingSource.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // db_aadccb_cinebdDataSet
            // 
            this.db_aadccb_cinebdDataSet.DataSetName = "db_aadccb_cinebdDataSet";
            this.db_aadccb_cinebdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listadoSesionesConAsientosOcupadosTableAdapter
            // 
            this.listadoSesionesConAsientosOcupadosTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDSesionDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.fechaFinDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.iDSalaDataGridViewTextBoxColumn,
            this.iDPeliculaDataGridViewTextBoxColumn,
            this.nombrePeliculaDataGridViewTextBoxColumn,
            this.clasificacionDataGridViewTextBoxColumn,
            this.duracionDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.capacidadDataGridViewTextBoxColumn,
            this.asientosOcupadosDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listadoSesionesConAsientosOcupadosBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1291, 440);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDSesionDataGridViewTextBoxColumn
            // 
            this.iDSesionDataGridViewTextBoxColumn.DataPropertyName = "ID_Sesion";
            this.iDSesionDataGridViewTextBoxColumn.HeaderText = "ID_Sesion";
            this.iDSesionDataGridViewTextBoxColumn.Name = "iDSesionDataGridViewTextBoxColumn";
            this.iDSesionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Inicio";
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "Fecha_Inicio";
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            // 
            // fechaFinDataGridViewTextBoxColumn
            // 
            this.fechaFinDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Fin";
            this.fechaFinDataGridViewTextBoxColumn.HeaderText = "Fecha_Fin";
            this.fechaFinDataGridViewTextBoxColumn.Name = "fechaFinDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // iDSalaDataGridViewTextBoxColumn
            // 
            this.iDSalaDataGridViewTextBoxColumn.DataPropertyName = "ID_Sala";
            this.iDSalaDataGridViewTextBoxColumn.HeaderText = "ID_Sala";
            this.iDSalaDataGridViewTextBoxColumn.Name = "iDSalaDataGridViewTextBoxColumn";
            // 
            // iDPeliculaDataGridViewTextBoxColumn
            // 
            this.iDPeliculaDataGridViewTextBoxColumn.DataPropertyName = "ID_Pelicula";
            this.iDPeliculaDataGridViewTextBoxColumn.HeaderText = "ID_Pelicula";
            this.iDPeliculaDataGridViewTextBoxColumn.Name = "iDPeliculaDataGridViewTextBoxColumn";
            // 
            // nombrePeliculaDataGridViewTextBoxColumn
            // 
            this.nombrePeliculaDataGridViewTextBoxColumn.DataPropertyName = "Nombre_Pelicula";
            this.nombrePeliculaDataGridViewTextBoxColumn.HeaderText = "Nombre_Pelicula";
            this.nombrePeliculaDataGridViewTextBoxColumn.Name = "nombrePeliculaDataGridViewTextBoxColumn";
            // 
            // clasificacionDataGridViewTextBoxColumn
            // 
            this.clasificacionDataGridViewTextBoxColumn.DataPropertyName = "Clasificacion";
            this.clasificacionDataGridViewTextBoxColumn.HeaderText = "Clasificacion";
            this.clasificacionDataGridViewTextBoxColumn.Name = "clasificacionDataGridViewTextBoxColumn";
            // 
            // duracionDataGridViewTextBoxColumn
            // 
            this.duracionDataGridViewTextBoxColumn.DataPropertyName = "Duracion";
            this.duracionDataGridViewTextBoxColumn.HeaderText = "Duracion";
            this.duracionDataGridViewTextBoxColumn.Name = "duracionDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // capacidadDataGridViewTextBoxColumn
            // 
            this.capacidadDataGridViewTextBoxColumn.DataPropertyName = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.HeaderText = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.Name = "capacidadDataGridViewTextBoxColumn";
            // 
            // asientosOcupadosDataGridViewTextBoxColumn
            // 
            this.asientosOcupadosDataGridViewTextBoxColumn.DataPropertyName = "Asientos_Ocupados";
            this.asientosOcupadosDataGridViewTextBoxColumn.HeaderText = "Asientos_Ocupados";
            this.asientosOcupadosDataGridViewTextBoxColumn.Name = "asientosOcupadosDataGridViewTextBoxColumn";
            this.asientosOcupadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.asientosOcupadosDataGridViewTextBoxColumn.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 440);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listadoSesionesConAsientosOcupadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource listadoSesionesConAsientosOcupadosBindingSource;
        private db_aadccb_cinebdDataSet db_aadccb_cinebdDataSet;
        private db_aadccb_cinebdDataSetTableAdapters.ListadoSesionesConAsientosOcupadosTableAdapter listadoSesionesConAsientosOcupadosTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSesionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSalaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPeliculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePeliculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asientosOcupadosDataGridViewTextBoxColumn;
    }
}