namespace CINEBD.View
{
    partial class Compra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compra));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.peliculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cINEBDDataSet = new CINEBD.CINEBDDataSet();
            this.peliculaTableAdapter = new CINEBD.CINEBDDataSetTableAdapters.PeliculaTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.sALABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.sALATableAdapter = new CINEBD.CINEBDDataSetTableAdapters.SALATableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Sala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKAsientoIDSala3B75D760BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asientoTableAdapter = new CINEBD.CINEBDDataSetTableAdapters.AsientoTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.sesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sesionTableAdapter = new CINEBD.CINEBDDataSetTableAdapters.SesionTableAdapter();
            this.fKTransacciIDSe5AEE82B9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transaccion_AsientoTableAdapter = new CINEBD.CINEBDDataSetTableAdapters.Transaccion_AsientoTableAdapter();
            this.fKSesionIDPelic440B1D61BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sesionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Fecha_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKAsientoIDSala3B75D760BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTransacciIDSe5AEE82B9BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSesionIDPelic440B1D61BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.peliculaBindingSource;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // peliculaBindingSource
            // 
            this.peliculaBindingSource.DataMember = "Pelicula";
            this.peliculaBindingSource.DataSource = this.cINEBDDataSet;
            // 
            // cINEBDDataSet
            // 
            this.cINEBDDataSet.DataSetName = "CINEBDDataSet";
            this.cINEBDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // peliculaTableAdapter
            // 
            this.peliculaTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ELIJA UNA PELICULA";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.sALABindingSource;
            this.comboBox2.DisplayMember = "ID_Sala";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(199, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(159, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // sALABindingSource
            // 
            this.sALABindingSource.DataMember = "SALA";
            this.sALABindingSource.DataSource = this.cINEBDDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ELIJA UNA SALA";
            // 
            // sALATableAdapter
            // 
            this.sALATableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filaDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.ID_Sala});
            this.dataGridView1.DataSource = this.fKAsientoIDSala3B75D760BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 406);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(749, 172);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // filaDataGridViewTextBoxColumn
            // 
            this.filaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filaDataGridViewTextBoxColumn.DataPropertyName = "Fila";
            this.filaDataGridViewTextBoxColumn.HeaderText = "Fila";
            this.filaDataGridViewTextBoxColumn.Name = "filaDataGridViewTextBoxColumn";
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "NumeroAsiento";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            // 
            // ID_Sala
            // 
            this.ID_Sala.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_Sala.DataPropertyName = "ID_Sala";
            this.ID_Sala.HeaderText = "NoSala";
            this.ID_Sala.Name = "ID_Sala";
            // 
            // fKAsientoIDSala3B75D760BindingSource
            // 
            this.fKAsientoIDSala3B75D760BindingSource.DataMember = "FK__Asiento__ID_Sala__3B75D760";
            this.fKAsientoIDSala3B75D760BindingSource.DataSource = this.sALABindingSource;
            // 
            // asientoBindingSource
            // 
            this.asientoBindingSource.DataMember = "Asiento";
            this.asientoBindingSource.DataSource = this.cINEBDDataSet;
            // 
            // asientoTableAdapter
            // 
            this.asientoTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(748, 318);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(817, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TIPO DE SELECCION";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(820, 114);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Automatica";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(820, 149);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(61, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Manual";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(817, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "INGRESE FILA";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(797, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(799, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "INGRESE NOASIENTO";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(797, 280);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(820, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "APARTAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha_Inicio,
            this.Fecha_Fin});
            this.dataGridView2.DataSource = this.fKSesionIDPelic440B1D61BindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(385, 9);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(376, 70);
            this.dataGridView2.TabIndex = 15;
            // 
            // sesionBindingSource
            // 
            this.sesionBindingSource.DataMember = "Sesion";
            this.sesionBindingSource.DataSource = this.cINEBDDataSet;
            // 
            // sesionTableAdapter
            // 
            this.sesionTableAdapter.ClearBeforeFill = true;
            // 
            // fKTransacciIDSe5AEE82B9BindingSource
            // 
            this.fKTransacciIDSe5AEE82B9BindingSource.DataMember = "FK__Transacci__ID_Se__5AEE82B9";
            this.fKTransacciIDSe5AEE82B9BindingSource.DataSource = this.sesionBindingSource;
            // 
            // transaccion_AsientoTableAdapter
            // 
            this.transaccion_AsientoTableAdapter.ClearBeforeFill = true;
            // 
            // fKSesionIDPelic440B1D61BindingSource
            // 
            this.fKSesionIDPelic440B1D61BindingSource.DataMember = "FK__Sesion__ID_Pelic__440B1D61";
            this.fKSesionIDPelic440B1D61BindingSource.DataSource = this.peliculaBindingSource;
            // 
            // sesionBindingSource1
            // 
            this.sesionBindingSource1.DataMember = "Sesion";
            this.sesionBindingSource1.DataSource = this.cINEBDDataSet;
            // 
            // Fecha_Inicio
            // 
            this.Fecha_Inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha_Inicio.DataPropertyName = "Fecha_Inicio";
            this.Fecha_Inicio.HeaderText = "Fecha_Inicio";
            this.Fecha_Inicio.Name = "Fecha_Inicio";
            // 
            // Fecha_Fin
            // 
            this.Fecha_Fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha_Fin.DataPropertyName = "Fecha_Fin";
            this.Fecha_Fin.HeaderText = "Fecha_Fin";
            this.Fecha_Fin.Name = "Fecha_Fin";
            this.Fecha_Fin.ReadOnly = true;
            // 
            // Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 590);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Compra";
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.Compra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKAsientoIDSala3B75D760BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTransacciIDSe5AEE82B9BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSesionIDPelic440B1D61BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private CINEBDDataSet cINEBDDataSet;
        private System.Windows.Forms.BindingSource peliculaBindingSource;
        private CINEBDDataSetTableAdapters.PeliculaTableAdapter peliculaTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource sALABindingSource;
        private CINEBDDataSetTableAdapters.SALATableAdapter sALATableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource asientoBindingSource;
        private CINEBDDataSetTableAdapters.AsientoTableAdapter asientoTableAdapter;
        private System.Windows.Forms.BindingSource fKAsientoIDSala3B75D760BindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn filaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Sala;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource sesionBindingSource;
        private CINEBDDataSetTableAdapters.SesionTableAdapter sesionTableAdapter;
        private System.Windows.Forms.BindingSource fKTransacciIDSe5AEE82B9BindingSource;
        private CINEBDDataSetTableAdapters.Transaccion_AsientoTableAdapter transaccion_AsientoTableAdapter;
        private System.Windows.Forms.BindingSource fKSesionIDPelic440B1D61BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Fin;
        private System.Windows.Forms.BindingSource sesionBindingSource1;
    }
}