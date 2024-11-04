namespace CINEBD.View
{
    partial class AnularTransaccion
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fKTransacciIDTr5535A963BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transaccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cINEBD2DataSet = new CINEBD.CINEBD2DataSet();
            this.transaccionTableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.TransaccionTableAdapter();
            this.transaccion_AsientoTableAdapter = new CINEBD.CINEBD2DataSetTableAdapters.Transaccion_AsientoTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.fKTransacciIDTr5535A963BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "INSERTE EN NUMERO\r\nDE TRANSACCION\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "VERIFICAR TRANSACCION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "ANULAR TRANSACCION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fKTransacciIDTr5535A963BindingSource
            // 
            this.fKTransacciIDTr5535A963BindingSource.DataMember = "FK__Transacci__ID_Tr__5535A963";
            this.fKTransacciIDTr5535A963BindingSource.DataSource = this.transaccionBindingSource;
            // 
            // transaccionBindingSource
            // 
            this.transaccionBindingSource.DataMember = "Transaccion";
            this.transaccionBindingSource.DataSource = this.cINEBD2DataSet;
            // 
            // cINEBD2DataSet
            // 
            this.cINEBD2DataSet.DataSetName = "CINEBD2DataSet";
            this.cINEBD2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transaccionTableAdapter
            // 
            this.transaccionTableAdapter.ClearBeforeFill = true;
            // 
            // transaccion_AsientoTableAdapter
            // 
            this.transaccion_AsientoTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(341, 175);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // AnularTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 345);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "AnularTransaccion";
            this.Text = "AnularTransaccion";
            this.Load += new System.EventHandler(this.AnularTransaccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fKTransacciIDTr5535A963BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cINEBD2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CINEBD2DataSet cINEBD2DataSet;
        private System.Windows.Forms.BindingSource transaccionBindingSource;
        private CINEBD2DataSetTableAdapters.TransaccionTableAdapter transaccionTableAdapter;
        private System.Windows.Forms.BindingSource fKTransacciIDTr5535A963BindingSource;
        private CINEBD2DataSetTableAdapters.Transaccion_AsientoTableAdapter transaccion_AsientoTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}