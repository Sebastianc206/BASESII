namespace CINEBD.View
{
    partial class DesactivarSesion
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.peliculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cINEBD2DataSet = new CINEBD.CINEBD2DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.sALABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.peliculaTableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.PeliculaTableAdapter();
            this.sALATableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.SALATableAdapter();
            this.db_aadccb_cinebdDataSet = new CINEBD.db_aadccb_cinebdDataSet();
            this.peliculaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.peliculaTableAdapter1 = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.PeliculaTableAdapter();
            this.sALABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sALATableAdapter1 = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.SALATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(642, 173);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECCIONE UNA PELICULA";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.peliculaBindingSource1;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "ID_Pelicula";
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
            this.label2.Location = new System.Drawing.Point(234, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SELECCIONE UNA SALA";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sALABindingSource, "ID_Sala", true));
            this.comboBox2.DataSource = this.sALABindingSource1;
            this.comboBox2.DisplayMember = "ID_Sala";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(237, 45);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.ValueMember = "ID_Sala";
            // 
            // sALABindingSource
            // 
            this.sALABindingSource.DataMember = "SALA";
            this.sALABindingSource.DataSource = this.cINEBD2DataSet;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "VER SESIONES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "DESACTIVAR SESION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // peliculaTableAdapter
            // 
            this.peliculaTableAdapter.ClearBeforeFill = true;
            // 
            // sALATableAdapter
            // 
            this.sALATableAdapter.ClearBeforeFill = true;
            // 
            // db_aadccb_cinebdDataSet
            // 
            this.db_aadccb_cinebdDataSet.DataSetName = "db_aadccb_cinebdDataSet";
            this.db_aadccb_cinebdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // peliculaBindingSource1
            // 
            this.peliculaBindingSource1.DataMember = "Pelicula";
            this.peliculaBindingSource1.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // peliculaTableAdapter1
            // 
            this.peliculaTableAdapter1.ClearBeforeFill = true;
            // 
            // sALABindingSource1
            // 
            this.sALABindingSource1.DataMember = "SALA";
            this.sALABindingSource1.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // sALATableAdapter1
            // 
            this.sALATableAdapter1.ClearBeforeFill = true;
            // 
            // DesactivarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 286);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DesactivarSesion";
            this.Text = "DesactivarSesion";
            this.Load += new System.EventHandler(this.DesactivarSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peliculaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALABindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CINEBD2DataSet cINEBD2DataSet;
        private System.Windows.Forms.BindingSource peliculaBindingSource;
        private CINEBD2DataSetTableAdapters.PeliculaTableAdapter peliculaTableAdapter;
        private System.Windows.Forms.BindingSource sALABindingSource;
        private CINEBD2DataSetTableAdapters.SALATableAdapter sALATableAdapter;
        private db_aadccb_cinebdDataSet db_aadccb_cinebdDataSet;
        private System.Windows.Forms.BindingSource peliculaBindingSource1;
        private db_aadccb_cinebdDataSetTableAdapters.PeliculaTableAdapter peliculaTableAdapter1;
        private System.Windows.Forms.BindingSource sALABindingSource1;
        private db_aadccb_cinebdDataSetTableAdapters.SALATableAdapter sALATableAdapter1;
    }
}