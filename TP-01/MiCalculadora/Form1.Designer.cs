namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnComvertirABinario = new System.Windows.Forms.Button();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.btnComvertirADecimal = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.ForeColor = System.Drawing.SystemColors.Control;
            this.lblResultado.Location = new System.Drawing.Point(71, 83);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(477, 36);
            this.lblResultado.TabIndex = 19;
            this.lblResultado.Text = "0";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnComvertirABinario
            // 
            this.btnComvertirABinario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComvertirABinario.Location = new System.Drawing.Point(79, 233);
            this.btnComvertirABinario.Name = "btnComvertirABinario";
            this.btnComvertirABinario.Size = new System.Drawing.Size(227, 23);
            this.btnComvertirABinario.TabIndex = 18;
            this.btnComvertirABinario.Text = "Comvertir a Binario";
            this.btnComvertirABinario.UseVisualStyleBackColor = true;
            this.btnComvertirABinario.Click += new System.EventHandler(this.btnComvertirABinario_Click);
            // 
            // cmbOperador
            // 
            this.cmbOperador.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Items.AddRange(new object[] {
            "+",
            "-",
            "/",
            "*"});
            this.cmbOperador.Location = new System.Drawing.Point(238, 143);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(151, 24);
            this.cmbOperador.TabIndex = 17;
            // 
            // txtNumero2
            // 
            this.txtNumero2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero2.Location = new System.Drawing.Point(397, 145);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(151, 22);
            this.txtNumero2.TabIndex = 16;
            this.txtNumero2.Text = "0";
            this.txtNumero2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnComvertirADecimal
            // 
            this.btnComvertirADecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComvertirADecimal.Location = new System.Drawing.Point(321, 233);
            this.btnComvertirADecimal.Name = "btnComvertirADecimal";
            this.btnComvertirADecimal.Size = new System.Drawing.Size(227, 23);
            this.btnComvertirADecimal.TabIndex = 15;
            this.btnComvertirADecimal.Text = "Comvertir a Decimal";
            this.btnComvertirADecimal.UseVisualStyleBackColor = true;
            this.btnComvertirADecimal.Click += new System.EventHandler(this.btnComvertirADecimal_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(397, 188);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(152, 23);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(238, 188);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(152, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpear";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNumero1
            // 
            this.txtNumero1.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumero1.Location = new System.Drawing.Point(79, 143);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(151, 22);
            this.txtNumero1.TabIndex = 12;
            this.txtNumero1.Text = "0";
            this.txtNumero1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOperar
            // 
            this.btnOperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperar.Location = new System.Drawing.Point(79, 188);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(152, 23);
            this.btnOperar.TabIndex = 11;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 339);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnComvertirABinario);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.btnComvertirADecimal);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.btnOperar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Ovelar Mariano del curso 2C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnComvertirABinario;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Button btnComvertirADecimal;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.Button btnOperar;
    }
}

