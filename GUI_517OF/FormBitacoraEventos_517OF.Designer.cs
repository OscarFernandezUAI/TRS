namespace GUI_517OF
{
    partial class FormBitacoraEventos_517OF
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvBitacora = new DataGridView();
            lblUsuario = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblFechaIni = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblFechaFin = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblModulo = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblEvento = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblCriticidad = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            cbUsuario = new ComboBox();
            cbModulo = new ComboBox();
            dtpFechaIni = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            cbEvento = new ComboBox();
            cbCriticidad = new ComboBox();
            btnLimpiar = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            btnAplicar = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            btnImprimir = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            btnSalir = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            lblNombre = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblValorNombre = new Label();
            lblApellido = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            lblValorApellido = new Label();
            pnlTitulo = new Panel();
            lblTituloBitacora = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            pnlTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBitacora.BackgroundColor = Color.FromArgb(28, 30, 34);
            dgvBitacora.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(37, 40, 46);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(232, 232, 232);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(28, 30, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(199, 201, 205);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(58, 47, 30);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(232, 173, 79);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBitacora.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBitacora.GridColor = Color.FromArgb(44, 47, 54);
            dgvBitacora.Location = new Point(144, 59);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.RowHeadersWidth = 51;
            dgvBitacora.Size = new Size(796, 358);
            dgvBitacora.TabIndex = 0;
            dgvBitacora.SelectionChanged += dgvBitacora_SelectionChanged;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ClaveTraduccion_517OF = "LblUsuario";
            lblUsuario.Font = new Font("Segoe UI", 8F);
            lblUsuario.ForeColor = Color.FromArgb(154, 157, 163);
            lblUsuario.Location = new Point(182, 542);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblFechaIni
            // 
            lblFechaIni.AutoSize = true;
            lblFechaIni.ClaveTraduccion_517OF = "LblFechaIni";
            lblFechaIni.Font = new Font("Segoe UI", 8F);
            lblFechaIni.ForeColor = Color.FromArgb(154, 157, 163);
            lblFechaIni.Location = new Point(456, 539);
            lblFechaIni.Name = "lblFechaIni";
            lblFechaIni.Size = new Size(80, 19);
            lblFechaIni.TabIndex = 2;
            lblFechaIni.Text = "Fecha Inicio";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.ClaveTraduccion_517OF = "LblFechaFin";
            lblFechaFin.Font = new Font("Segoe UI", 8F);
            lblFechaFin.ForeColor = Color.FromArgb(154, 157, 163);
            lblFechaFin.Location = new Point(747, 535);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(66, 19);
            lblFechaFin.TabIndex = 3;
            lblFechaFin.Text = "Fecha Fin";
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.ClaveTraduccion_517OF = "LblModulo";
            lblModulo.Font = new Font("Segoe UI", 8F);
            lblModulo.ForeColor = Color.FromArgb(154, 157, 163);
            lblModulo.Location = new Point(181, 601);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(57, 19);
            lblModulo.TabIndex = 4;
            lblModulo.Text = "Módulo";
            // 
            // lblEvento
            // 
            lblEvento.AutoSize = true;
            lblEvento.ClaveTraduccion_517OF = "LblEvento";
            lblEvento.Font = new Font("Segoe UI", 8F);
            lblEvento.ForeColor = Color.FromArgb(154, 157, 163);
            lblEvento.Location = new Point(455, 601);
            lblEvento.Name = "lblEvento";
            lblEvento.Size = new Size(51, 19);
            lblEvento.TabIndex = 5;
            lblEvento.Text = "Evento";
            // 
            // lblCriticidad
            // 
            lblCriticidad.AutoSize = true;
            lblCriticidad.ClaveTraduccion_517OF = "LblCriticidad";
            lblCriticidad.Font = new Font("Segoe UI", 8F);
            lblCriticidad.ForeColor = Color.FromArgb(154, 157, 163);
            lblCriticidad.Location = new Point(717, 601);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(66, 19);
            lblCriticidad.TabIndex = 6;
            lblCriticidad.Text = "Criticidad";
            // 
            // cbUsuario
            // 
            cbUsuario.FormattingEnabled = true;
            cbUsuario.Location = new Point(244, 537);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(151, 28);
            cbUsuario.TabIndex = 7;
            // 
            // cbModulo
            // 
            cbModulo.FormattingEnabled = true;
            cbModulo.Location = new Point(244, 596);
            cbModulo.Name = "cbModulo";
            cbModulo.Size = new Size(151, 28);
            cbModulo.TabIndex = 8;
            // 
            // dtpFechaIni
            // 
            dtpFechaIni.Format = DateTimePickerFormat.Short;
            dtpFechaIni.Location = new Point(542, 535);
            dtpFechaIni.Name = "dtpFechaIni";
            dtpFechaIni.Size = new Size(121, 27);
            dtpFechaIni.TabIndex = 9;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(819, 531);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(121, 27);
            dtpFechaFin.TabIndex = 10;
            // 
            // cbEvento
            // 
            cbEvento.FormattingEnabled = true;
            cbEvento.Location = new Point(512, 596);
            cbEvento.Name = "cbEvento";
            cbEvento.Size = new Size(151, 28);
            cbEvento.TabIndex = 11;
            // 
            // cbCriticidad
            // 
            cbCriticidad.FormattingEnabled = true;
            cbCriticidad.Location = new Point(789, 596);
            cbCriticidad.Name = "cbCriticidad";
            cbCriticidad.Size = new Size(151, 28);
            cbCriticidad.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.BackColor = Color.FromArgb(232, 173, 79);
            btnLimpiar.ClaveTraduccion_517OF = "BtnLimpiar";
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(28, 30, 34);
            btnLimpiar.Location = new Point(144, 688);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAplicar.BackColor = Color.FromArgb(232, 173, 79);
            btnAplicar.ClaveTraduccion_517OF = "BtnAplicar";
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.FromArgb(28, 30, 34);
            btnAplicar.Location = new Point(358, 688);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(94, 29);
            btnAplicar.TabIndex = 14;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimir.BackColor = Color.FromArgb(232, 173, 79);
            btnImprimir.ClaveTraduccion_517OF = "BtnImprimir";
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.FromArgb(28, 30, 34);
            btnImprimir.Location = new Point(639, 688);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(94, 29);
            btnImprimir.TabIndex = 15;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(232, 173, 79);
            btnSalir.ClaveTraduccion_517OF = "BtnSalir";
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(28, 30, 34);
            btnSalir.Location = new Point(858, 688);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ClaveTraduccion_517OF = "LblNombre";
            lblNombre.ForeColor = Color.FromArgb(154, 157, 163);
            lblNombre.Location = new Point(376, 469);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 17;
            lblNombre.Text = "Nombre";
            // 
            // lblValorNombre
            // 
            lblValorNombre.AutoSize = true;
            lblValorNombre.ForeColor = Color.FromArgb(154, 157, 163);
            lblValorNombre.Location = new Point(446, 469);
            lblValorNombre.Name = "lblValorNombre";
            lblValorNombre.Size = new Size(50, 20);
            lblValorNombre.TabIndex = 18;
            lblValorNombre.Text = "label1";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.ClaveTraduccion_517OF = "LblApellido";
            lblApellido.ForeColor = Color.FromArgb(154, 157, 163);
            lblApellido.Location = new Point(560, 469);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 19;
            lblApellido.Text = "Apellido";
            // 
            // lblValorApellido
            // 
            lblValorApellido.AutoSize = true;
            lblValorApellido.ForeColor = Color.FromArgb(154, 157, 163);
            lblValorApellido.Location = new Point(632, 469);
            lblValorApellido.Name = "lblValorApellido";
            lblValorApellido.Size = new Size(50, 20);
            lblValorApellido.TabIndex = 20;
            lblValorApellido.Text = "label2";
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTituloBitacora);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1100, 36);
            pnlTitulo.TabIndex = 21;
            // 
            // lblTituloBitacora
            // 
            lblTituloBitacora.AutoSize = true;
            lblTituloBitacora.ClaveTraduccion_517OF = "FormBitacoraEventos_Titulo";
            lblTituloBitacora.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTituloBitacora.Location = new Point(12, 9);
            lblTituloBitacora.Name = "lblTituloBitacora";
            lblTituloBitacora.Size = new Size(160, 21);
            lblTituloBitacora.TabIndex = 0;
            lblTituloBitacora.Text = "Bitácora de Eventos";
            // 
            // FormBitacoraEventos_517OF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 750);
            Controls.Add(pnlTitulo);
            Controls.Add(lblValorApellido);
            Controls.Add(lblApellido);
            Controls.Add(lblValorNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimir);
            Controls.Add(btnAplicar);
            Controls.Add(btnLimpiar);
            Controls.Add(cbCriticidad);
            Controls.Add(cbEvento);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaIni);
            Controls.Add(cbModulo);
            Controls.Add(cbUsuario);
            Controls.Add(lblCriticidad);
            Controls.Add(lblEvento);
            Controls.Add(lblModulo);
            Controls.Add(lblFechaFin);
            Controls.Add(lblFechaIni);
            Controls.Add(lblUsuario);
            Controls.Add(dgvBitacora);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBitacoraEventos_517OF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitácora de Eventos";
            Load += FormBitacoraEventos_517OF_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBitacora;
        private ControlesComunes.LabelTraducible_517OF lblUsuario;
        private ControlesComunes.LabelTraducible_517OF lblFechaIni;
        private ControlesComunes.LabelTraducible_517OF lblFechaFin;
        private ControlesComunes.LabelTraducible_517OF lblModulo;
        private ControlesComunes.LabelTraducible_517OF lblEvento;
        private ControlesComunes.LabelTraducible_517OF lblCriticidad;
        private ComboBox cbUsuario;
        private ComboBox cbModulo;
        private DateTimePicker dtpFechaIni;
        private DateTimePicker dtpFechaFin;
        private ComboBox cbEvento;
        private ComboBox cbCriticidad;
        private ControlesComunes.BotonTraducible_517OF btnLimpiar;
        private ControlesComunes.BotonTraducible_517OF btnAplicar;
        private ControlesComunes.BotonTraducible_517OF btnImprimir;
        private ControlesComunes.BotonTraducible_517OF btnSalir;
        private ControlesComunes.LabelTraducible_517OF lblNombre;
        private Label lblValorNombre;
        private ControlesComunes.LabelTraducible_517OF lblApellido;
        private Label lblValorApellido;
        private Panel pnlTitulo;
        private ControlesComunes.LabelTraducible_517OF lblTituloBitacora;
    }
}