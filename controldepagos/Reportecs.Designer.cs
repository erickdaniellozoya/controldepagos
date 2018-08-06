namespace controldepagos
{
    partial class Reportecs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportecs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbxEscolaridad = new System.Windows.Forms.ComboBox();
            this.cbxGrado = new System.Windows.Forms.ComboBox();
            this.cbxGrupo = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.Vencidos = new System.Windows.Forms.LinkLabel();
            this.lPendiente = new System.Windows.Forms.LinkLabel();
            this.cbmes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtadeudo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpagado = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.cbxEscolaridad);
            this.panel1.Controls.Add(this.cbxGrado);
            this.panel1.Controls.Add(this.cbxGrupo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 100);
            this.panel1.TabIndex = 241;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(357, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 225;
            this.label4.Text = "Estado de cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 227;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(120, 60);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(263, 20);
            this.txtBuscar.TabIndex = 226;
            this.txtBuscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbxEscolaridad
            // 
            this.cbxEscolaridad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxEscolaridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxEscolaridad.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEscolaridad.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbxEscolaridad.FormattingEnabled = true;
            this.cbxEscolaridad.Items.AddRange(new object[] {
            "Kinder",
            "Primaria",
            "Secundaria"});
            this.cbxEscolaridad.Location = new System.Drawing.Point(424, 60);
            this.cbxEscolaridad.Name = "cbxEscolaridad";
            this.cbxEscolaridad.Size = new System.Drawing.Size(143, 25);
            this.cbxEscolaridad.TabIndex = 231;
            this.cbxEscolaridad.Text = "Escolaridad";
            this.cbxEscolaridad.SelectedIndexChanged += new System.EventHandler(this.cbxEscolaridad_SelectedIndexChanged);
            // 
            // cbxGrado
            // 
            this.cbxGrado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxGrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxGrado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGrado.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbxGrado.FormattingEnabled = true;
            this.cbxGrado.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cbxGrado.Location = new System.Drawing.Point(703, 60);
            this.cbxGrado.Name = "cbxGrado";
            this.cbxGrado.Size = new System.Drawing.Size(67, 25);
            this.cbxGrado.TabIndex = 232;
            this.cbxGrado.Text = "Grupo";
            // 
            // cbxGrupo
            // 
            this.cbxGrupo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxGrupo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGrupo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbxGrupo.FormattingEnabled = true;
            this.cbxGrupo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbxGrupo.Location = new System.Drawing.Point(604, 60);
            this.cbxGrupo.Name = "cbxGrupo";
            this.cbxGrupo.Size = new System.Drawing.Size(70, 25);
            this.cbxGrupo.TabIndex = 233;
            this.cbxGrupo.Text = "Grado";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(737, 442);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 30);
            this.button11.TabIndex = 240;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button6.Location = new System.Drawing.Point(27, 19);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(52, 48);
            this.button6.TabIndex = 236;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(27, 181);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(813, 189);
            this.tabla.TabIndex = 235;
            // 
            // Vencidos
            // 
            this.Vencidos.ActiveLinkColor = System.Drawing.Color.Black;
            this.Vencidos.AutoSize = true;
            this.Vencidos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vencidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Vencidos.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Vencidos.Location = new System.Drawing.Point(546, 135);
            this.Vencidos.Name = "Vencidos";
            this.Vencidos.Size = new System.Drawing.Size(96, 23);
            this.Vencidos.TabIndex = 242;
            this.Vencidos.TabStop = true;
            this.Vencidos.Text = "Vencidos";
            // 
            // lPendiente
            // 
            this.lPendiente.ActiveLinkColor = System.Drawing.Color.Black;
            this.lPendiente.AutoSize = true;
            this.lPendiente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPendiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lPendiente.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lPendiente.Location = new System.Drawing.Point(659, 135);
            this.lPendiente.Name = "lPendiente";
            this.lPendiente.Size = new System.Drawing.Size(111, 23);
            this.lPendiente.TabIndex = 243;
            this.lPendiente.TabStop = true;
            this.lPendiente.Text = "Pendientes";
            // 
            // cbmes
            // 
            this.cbmes.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbmes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbmes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbmes.FormattingEnabled = true;
            this.cbmes.Items.AddRange(new object[] {
            "Enero ",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbmes.Location = new System.Drawing.Point(362, 135);
            this.cbmes.Name = "cbmes";
            this.cbmes.Size = new System.Drawing.Size(143, 25);
            this.cbmes.TabIndex = 234;
            this.cbmes.Text = "Seleccione mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(163, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 235;
            this.label2.Text = "Total de adeudo:";
            // 
            // txtadeudo
            // 
            this.txtadeudo.Location = new System.Drawing.Point(354, 400);
            this.txtadeudo.Name = "txtadeudo";
            this.txtadeudo.Size = new System.Drawing.Size(146, 20);
            this.txtadeudo.TabIndex = 234;
            this.txtadeudo.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(506, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 245;
            this.label3.Text = "Total pagado:";
            // 
            // txtpagado
            // 
            this.txtpagado.Location = new System.Drawing.Point(666, 400);
            this.txtpagado.Name = "txtpagado";
            this.txtpagado.Size = new System.Drawing.Size(146, 20);
            this.txtpagado.TabIndex = 244;
            this.txtpagado.Text = "0";
            // 
            // Reportecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 484);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpagado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtadeudo);
            this.Controls.Add(this.cbmes);
            this.Controls.Add(this.lPendiente);
            this.Controls.Add(this.Vencidos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Reportecs";
            this.Text = "Reporte";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbxEscolaridad;
        private System.Windows.Forms.ComboBox cbxGrado;
        private System.Windows.Forms.ComboBox cbxGrupo;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.LinkLabel Vencidos;
        private System.Windows.Forms.LinkLabel lPendiente;
        private System.Windows.Forms.ComboBox cbmes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtadeudo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpagado;
    }
}