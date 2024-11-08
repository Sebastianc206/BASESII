namespace CINEBD
{
    partial class Form2
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
            this.listadoTransaccionesConAsientosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.db_aadccb_cinebdDataSet = new CINEBD.db_aadccb_cinebdDataSet();
            this.listadoTransaccionesConAsientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listadoTransaccionesConAsientosTableAdapter = new CINEBD.db_aadccb_cinebdDataSetTableAdapters.ListadoTransaccionesConAsientosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesConAsientosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesConAsientosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1645, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // listadoTransaccionesConAsientosBindingSource1
            // 
            this.listadoTransaccionesConAsientosBindingSource1.DataMember = "ListadoTransaccionesConAsientos";
            this.listadoTransaccionesConAsientosBindingSource1.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // db_aadccb_cinebdDataSet
            // 
            this.db_aadccb_cinebdDataSet.DataSetName = "db_aadccb_cinebdDataSet";
            this.db_aadccb_cinebdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listadoTransaccionesConAsientosBindingSource
            // 
            this.listadoTransaccionesConAsientosBindingSource.DataMember = "ListadoTransaccionesConAsientos";
            this.listadoTransaccionesConAsientosBindingSource.DataSource = this.db_aadccb_cinebdDataSet;
            // 
            // listadoTransaccionesConAsientosTableAdapter
            // 
            this.listadoTransaccionesConAsientosTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1645, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesConAsientosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_aadccb_cinebdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesConAsientosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource listadoTransaccionesConAsientosBindingSource;
        private db_aadccb_cinebdDataSet db_aadccb_cinebdDataSet;
        private System.Windows.Forms.BindingSource listadoTransaccionesConAsientosBindingSource1;
        private db_aadccb_cinebdDataSetTableAdapters.ListadoTransaccionesConAsientosTableAdapter listadoTransaccionesConAsientosTableAdapter;
    }
}