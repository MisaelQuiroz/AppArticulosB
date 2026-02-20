namespace CatalogoDeProductos
{
    partial class PantallaCatalogo
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
            this.dgvPantallaCatalogo = new System.Windows.Forms.DataGridView();
            this.pbx1Contenedor = new System.Windows.Forms.PictureBox();
            this.btnVerdetalle = new System.Windows.Forms.Button();
            this.txbFiltroCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantallaCatalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1Contenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPantallaCatalogo
            // 
            this.dgvPantallaCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPantallaCatalogo.Location = new System.Drawing.Point(12, 83);
            this.dgvPantallaCatalogo.Name = "dgvPantallaCatalogo";
            this.dgvPantallaCatalogo.Size = new System.Drawing.Size(377, 144);
            this.dgvPantallaCatalogo.TabIndex = 3;
            this.dgvPantallaCatalogo.SelectionChanged += new System.EventHandler(this.dgvPantallaCatalogo_SelectionChanged);
            this.dgvPantallaCatalogo.DoubleClick += new System.EventHandler(this.dgvPantallaCatalogo_DoubleClick);
            // 
            // pbx1Contenedor
            // 
            this.pbx1Contenedor.Location = new System.Drawing.Point(415, 83);
            this.pbx1Contenedor.Name = "pbx1Contenedor";
            this.pbx1Contenedor.Size = new System.Drawing.Size(180, 234);
            this.pbx1Contenedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx1Contenedor.TabIndex = 4;
            this.pbx1Contenedor.TabStop = false;
            // 
            // btnVerdetalle
            // 
            this.btnVerdetalle.Location = new System.Drawing.Point(13, 267);
            this.btnVerdetalle.Name = "btnVerdetalle";
            this.btnVerdetalle.Size = new System.Drawing.Size(75, 23);
            this.btnVerdetalle.TabIndex = 5;
            this.btnVerdetalle.Text = "Ver detalle";
            this.btnVerdetalle.UseVisualStyleBackColor = true;
            this.btnVerdetalle.Click += new System.EventHandler(this.btnVerdetalle_Click);
            // 
            // txbFiltroCliente
            // 
            this.txbFiltroCliente.Location = new System.Drawing.Point(13, 32);
            this.txbFiltroCliente.Name = "txbFiltroCliente";
            this.txbFiltroCliente.Size = new System.Drawing.Size(100, 20);
            this.txbFiltroCliente.TabIndex = 6;
            this.txbFiltroCliente.TextChanged += new System.EventHandler(this.txbFiltroCliente_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar ";
            // 
            // PantallaCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbFiltroCliente);
            this.Controls.Add(this.btnVerdetalle);
            this.Controls.Add(this.pbx1Contenedor);
            this.Controls.Add(this.dgvPantallaCatalogo);
            this.Name = "PantallaCatalogo";
            this.Text = "PantallaCatalogo";
            this.Load += new System.EventHandler(this.PantallaCatalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantallaCatalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1Contenedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPantallaCatalogo;
        private System.Windows.Forms.PictureBox pbx1Contenedor;
        private System.Windows.Forms.Button btnVerdetalle;
        private System.Windows.Forms.TextBox txbFiltroCliente;
        private System.Windows.Forms.Label label1;
    }
}