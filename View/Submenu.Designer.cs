namespace CINEBD.View
{
    partial class Submenu
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
            this.btn_compra = new System.Windows.Forms.Button();
            this.btn_anulacion = new System.Windows.Forms.Button();
            this.btn_cambio = new System.Windows.Forms.Button();
            this.btn_pelicula = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_compra
            // 
            this.btn_compra.Location = new System.Drawing.Point(23, 12);
            this.btn_compra.Name = "btn_compra";
            this.btn_compra.Size = new System.Drawing.Size(177, 24);
            this.btn_compra.TabIndex = 0;
            this.btn_compra.Text = "REALIZAR COMPRA";
            this.btn_compra.UseVisualStyleBackColor = true;
            this.btn_compra.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_anulacion
            // 
            this.btn_anulacion.Location = new System.Drawing.Point(23, 71);
            this.btn_anulacion.Name = "btn_anulacion";
            this.btn_anulacion.Size = new System.Drawing.Size(177, 23);
            this.btn_anulacion.TabIndex = 1;
            this.btn_anulacion.Text = "REALIZAR ANULACION";
            this.btn_anulacion.UseVisualStyleBackColor = true;
            this.btn_anulacion.Click += new System.EventHandler(this.btn_anulacion_Click);
            // 
            // btn_cambio
            // 
            this.btn_cambio.Location = new System.Drawing.Point(23, 42);
            this.btn_cambio.Name = "btn_cambio";
            this.btn_cambio.Size = new System.Drawing.Size(177, 23);
            this.btn_cambio.TabIndex = 2;
            this.btn_cambio.Text = "REALIZAR CAMBIO";
            this.btn_cambio.UseVisualStyleBackColor = true;
            this.btn_cambio.Click += new System.EventHandler(this.btn_cambio_Click);
            // 
            // btn_pelicula
            // 
            this.btn_pelicula.Location = new System.Drawing.Point(23, 100);
            this.btn_pelicula.Name = "btn_pelicula";
            this.btn_pelicula.Size = new System.Drawing.Size(177, 23);
            this.btn_pelicula.TabIndex = 3;
            this.btn_pelicula.Text = "CREAR PELICULA";
            this.btn_pelicula.UseVisualStyleBackColor = true;
            this.btn_pelicula.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(23, 246);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "SALIR DEL PROGRAMA";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "ASIGNAR SESION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "DESACTIVACION DE SESIONES";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "INGRESAR CSV";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "GENERAR REPORTE";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Submenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 274);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_pelicula);
            this.Controls.Add(this.btn_cambio);
            this.Controls.Add(this.btn_anulacion);
            this.Controls.Add(this.btn_compra);
            this.Name = "Submenu";
            this.Text = "Operador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_compra;
        private System.Windows.Forms.Button btn_anulacion;
        private System.Windows.Forms.Button btn_cambio;
        private System.Windows.Forms.Button btn_pelicula;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}