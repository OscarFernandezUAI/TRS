using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BE_517OF;
using BLL_517OF;

namespace GUI_517OF
{
    public partial class FormLogin_517OF : Form
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public Usuario_517OF? UsuarioLogueado { get; private set; }

        public FormLogin_517OF()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int valorActivar = 1;
            DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref valorActivar, sizeof(int));
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            if (!txtUsuario.Validar_517OF() || !txtContrasena.Validar_517OF())
            {
                lblError.Text = "Completá usuario y contraseña.";
                lblError.Visible = true;
                return;
            }

            var bll = new UsuarioBLL_517OF();
            var usuario = bll.ValidarUsuario_517OF(txtUsuario.Text.Trim(), txtContrasena.Text);

            if (usuario == null)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
                return;
            }

            UsuarioLogueado = usuario;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}