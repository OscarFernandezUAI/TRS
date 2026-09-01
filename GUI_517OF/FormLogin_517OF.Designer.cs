namespace GUI_517OF
{
    partial class FormLogin_517OF
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
            lblUsuario = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            LblLogo = new Label();
            lblSubtitulo = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            txtUsuario = new GUI_517OF.ControlesComunes.CajaTextoValidable_517OF();
            lblContrasena = new GUI_517OF.ControlesComunes.LabelTraducible_517OF();
            txtContrasena = new GUI_517OF.ControlesComunes.CajaTextoValidable_517OF();
            lblError = new Label();
            btnIngresar = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            btnCancelar = new GUI_517OF.ControlesComunes.BotonTraducible_517OF();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ClaveTraduccion_517OF = "LblUsuario";
            lblUsuario.Font = new Font("Segoe UI", 8F);
            lblUsuario.ForeColor = Color.FromArgb(154, 157, 163);
            lblUsuario.Location = new Point(372, 148);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 19);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // LblLogo
            // 
            LblLogo.BackColor = Color.FromArgb(58, 47, 30);
            LblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LblLogo.ForeColor = Color.FromArgb(232, 173, 79);
            LblLogo.Location = new Point(368, 25);
            LblLogo.Name = "LblLogo";
            LblLogo.Size = new Size(64, 56);
            LblLogo.TabIndex = 1;
            LblLogo.Text = "TRS";
            LblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ClaveTraduccion_517OF = "LblLogin";
            lblSubtitulo.Font = new Font("Segoe UI", 8F);
            lblSubtitulo.ForeColor = Color.FromArgb(107, 109, 115);
            lblSubtitulo.Location = new Point(313, 105);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(175, 19);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Iniciá sesión para continuar";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(37, 40, 46);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.ForeColor = Color.FromArgb(232, 232, 232);
            txtUsuario.Location = new Point(338, 191);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(125, 27);
            txtUsuario.TabIndex = 3;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.ClaveTraduccion_517OF = "LblPassword";
            lblContrasena.Font = new Font("Segoe UI", 8F);
            lblContrasena.ForeColor = Color.FromArgb(154, 157, 163);
            lblContrasena.Location = new Point(361, 242);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(79, 19);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.BackColor = Color.FromArgb(37, 40, 46);
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.ForeColor = Color.FromArgb(232, 232, 232);
            txtContrasena.Location = new Point(338, 285);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(125, 27);
            txtContrasena.TabIndex = 5;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 8F);
            lblError.ForeColor = Color.FromArgb(224, 96, 90);
            lblError.Location = new Point(378, 336);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 19);
            lblError.TabIndex = 6;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(232, 173, 79);
            btnIngresar.ClaveTraduccion_517OF = "BtnIngresar";
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.FromArgb(28, 30, 34);
            btnIngresar.Location = new Point(290, 381);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 29);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.ClaveTraduccion_517OF = "BtnCancelar";
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 8.5F);
            btnCancelar.ForeColor = Color.FromArgb(107, 109, 115);
            btnCancelar.Location = new Point(420, 381);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormLogin_517OF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(lblError);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblSubtitulo);
            Controls.Add(LblLogo);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ControlesComunes.LabelTraducible_517OF lblUsuario;
        private Label LblLogo;
        private ControlesComunes.LabelTraducible_517OF lblSubtitulo;
        private ControlesComunes.CajaTextoValidable_517OF txtUsuario;
        private ControlesComunes.LabelTraducible_517OF lblContrasena;
        private ControlesComunes.CajaTextoValidable_517OF txtContrasena;
        private Label lblError;
        private ControlesComunes.BotonTraducible_517OF btnIngresar;
        private ControlesComunes.BotonTraducible_517OF btnCancelar;
    }
}