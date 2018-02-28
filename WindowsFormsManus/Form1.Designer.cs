namespace WindowsFormsManus
{
    partial class Form1
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
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.btnConvertirImagen = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(12, 515);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(113, 28);
            this.btnCargarImagen.TabIndex = 1;
            this.btnCargarImagen.Text = "Cargar imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // picImagen
            // 
            this.picImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImagen.BackColor = System.Drawing.Color.White;
            this.picImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picImagen.Location = new System.Drawing.Point(12, 12);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(532, 497);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagen.TabIndex = 0;
            this.picImagen.TabStop = false;
            // 
            // btnConvertirImagen
            // 
            this.btnConvertirImagen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConvertirImagen.Location = new System.Drawing.Point(992, 517);
            this.btnConvertirImagen.Name = "btnConvertirImagen";
            this.btnConvertirImagen.Size = new System.Drawing.Size(113, 27);
            this.btnConvertirImagen.TabIndex = 3;
            this.btnConvertirImagen.Text = "Convertir imagen";
            this.btnConvertirImagen.UseVisualStyleBackColor = true;
            this.btnConvertirImagen.Click += new System.EventHandler(this.btnConvertirImagen_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultado.Location = new System.Drawing.Point(550, 12);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(555, 497);
            this.txtResultado.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblInfo.Location = new System.Drawing.Point(131, 523);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(10, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 566);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnConvertirImagen);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.picImagen);
            this.Name = "Form1";
            this.Text = "Manus";
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.Button btnConvertirImagen;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblInfo;
    }
}

