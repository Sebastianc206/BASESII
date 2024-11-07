namespace CINEBD.View
{
    partial class AsignarSesion
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.peliculaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.db_aadccb_cinebdDataSet = new CINEBD.db_aadccb_cinebdDataSet();
            this.peliculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cINEBD2DataSet = new CINEBD.CINEBD2DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.sALABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sALABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.peliculaTableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.PeliculaTableAdapter();
            this.sesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sesionTableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.SesionTableAdapter();
            this.sALATableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.SALATableAdapter();
            this.peliculaTableAdapter1 = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.PeliculaTableAdapter();
            this.sALATableAdapter1 = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.SALATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECCIONE LA PELICULA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.peliculaBindingSource1;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "ID_Pelicula";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // peliculaBindingSource1
            // 
            this.peliculaBindingSource1.DataMember = "Pelicula";
            this.peliculaBindingSource1.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // db_aadccb_cinebdDataSet
            // 
            this.db_aadccb_cinebdDataSet.DataSetName = "db_aadccb_cinebdDataSet";
            this.db_aadccb_cinebdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // peliculaBindingSource
            // 
            this.peliculaBindingSource.DataMember = "Pelicula";
            this.peliculaBindingSource.DataSource = this.cINEBD2DataSet;
            // 
            // cINEBD2DataSet
            // 
            this.cINEBD2DataSet.DataSetName = "CINEBD2DataSet";
            this.cINEBD2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SELECCIONE UNA SALA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "SELECCIONE UNA \r\nFECHA DE INICIO\r\n(FORMATO 24H)\r\n";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sALABindingSource, "ID_Sala", true));
            this.comboBox2.DataSource = this.sALABindingSource1;
            this.comboBox2.DisplayMember = "ID_Sala";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(200, 161);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.ValueMember = "ID_Sala";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // sALABindingSource
            // 
            this.sALABindingSource.DataMember = "SALA";
            this.sALABindingSource.DataSource = this.cINEBD2DataSet;
            // 
            // sALABindingSource1
            // 
            this.sALABindingSource1.DataMember = "SALA";
            this.sALABindingSource1.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 222);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2024, 11, 2, 1, 9, 20, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "DURACION DE LA PELICULA\r\nEN (MIN)\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "ASIGNAR SESION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // peliculaTableAdapter
            // 
            this.peliculaTableAdapter.ClearBeforeFill = true;
            // 
            // sesionBindingSource
            // 
            this.sesionBindingSource.DataMember = "Sesion";
            this.sesionBindingSource.DataSource = this.cINEBD2DataSet;
            // 
            // sesionTableAdapter
            // 
            this.sesionTableAdapter.ClearBeforeFill = true;
            // 
            // sALATableAdapter
            // 
            this.sALATableAdapter.ClearBeforeFill = true;
            // 
            // peliculaTableAdapter1
            // 
            this.peliculaTableAdapter1.ClearBeforeFill = true;
            // 
            // sALATableAdapter1
            // 
            this.sALATableAdapter1.ClearBeforeFill = true;
            // 
            // AsignarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 353);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "AsignarSesion";
            this.Text = "AsignarSesion";
            this.Load += new System.EventHandler(this.AsignarSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private CINEBD2DataSet cINEBD2DataSet;
        private System.Windows.Forms.BindingSource peliculaBindingSource;
        private CINEBD2DataSetTableAdapters.PeliculaTableAdapter peliculaTableAdapter;
        private System.Windows.Forms.BindingSource sesionBindingSource;
        private CINEBD2DataSetTableAdapters.SesionTableAdapter sesionTableAdapter;
        private System.Windows.Forms.BindingSource sALABindingSource;
        private CINEBD2DataSetTableAdapters.SALATableAdapter sALATableAdapter;
        private db_aadccb_cinebdDataSet db_aadccb_cinebdDataSet;
        private System.Windows.Forms.BindingSource peliculaBindingSource1;
        private db_aadccb_cinebdDataSetTableAdapters.PeliculaTableAdapter peliculaTableAdapter1;
        private System.Windows.Forms.BindingSource sALABindingSource1;
        private db_aadccb_cinebdDataSetTableAdapters.SALATableAdapter sALATableAdapter1;
    }
}