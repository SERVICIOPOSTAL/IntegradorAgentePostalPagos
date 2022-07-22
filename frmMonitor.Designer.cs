namespace spe.gob.ec
{
    partial class frmMonitor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtFrecuenciaEjecucion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.lstEventos = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEjecutar.Location = new System.Drawing.Point(841, 24);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 13;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // txtFrecuenciaEjecucion
            // 
            this.txtFrecuenciaEjecucion.Location = new System.Drawing.Point(420, 27);
            this.txtFrecuenciaEjecucion.Name = "txtFrecuenciaEjecucion";
            this.txtFrecuenciaEjecucion.ReadOnly = true;
            this.txtFrecuenciaEjecucion.Size = new System.Drawing.Size(125, 20);
            this.txtFrecuenciaEjecucion.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Frecuencia de Ejecución:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ruta Aplicación:";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(8, 27);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.ReadOnly = true;
            this.txtRutaArchivo.Size = new System.Drawing.Size(406, 20);
            this.txtRutaArchivo.TabIndex = 9;
            // 
            // lstEventos
            // 
            this.lstEventos.FormattingEnabled = true;
            this.lstEventos.Location = new System.Drawing.Point(8, 54);
            this.lstEventos.Name = "lstEventos";
            this.lstEventos.ScrollAlwaysVisible = true;
            this.lstEventos.Size = new System.Drawing.Size(940, 238);
            this.lstEventos.TabIndex = 8;
            this.lstEventos.SelectedIndexChanged += new System.EventHandler(this.lstEventos_SelectedIndexChanged);
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 299);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtFrecuenciaEjecucion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.lstEventos);
            this.MaximizeBox = false;
            this.Name = "frmMonitor";
            this.Text = "Monitor : Integración";
            this.Load += new System.EventHandler(this.frmMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtFrecuenciaEjecucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.ListBox lstEventos;
        private System.Windows.Forms.Timer timer1;
    }
}

