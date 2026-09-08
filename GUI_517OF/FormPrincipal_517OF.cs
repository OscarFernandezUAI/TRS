using BE_517OF;
using SEGURIDAD_517OF;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_517OF
{
    public partial class FormPrincipal_517OF : Form
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        private MdiClient? _mdiClient_517OF;
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private TreeNode? _nodoHover;
        private const int TVM_SETEXTENDEDSTYLE = 0x112C;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;

        private Panel _pnlFooterSinSesion = null!;
        private Panel _pnlFooterConSesion = null!;
        private Label _lblSinSesionArbol = null!;

        public FormPrincipal_517OF()
        {
            InitializeComponent();
            BackColor = Estilos.FondoApp;
            ConfigurarSidebar_517OF();
            CargarNodosFijos_517OF();

            ConfigurarFooter_517OF();
            ActualizarEstadoSidebar_517OF();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AplicarModoOscuroBarraTitulo_517OF();
            AplicarColorAreaMdi_517OF();
        }

        private void AplicarModoOscuroBarraTitulo_517OF()
        {
            int valorActivar = 1;
            DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref valorActivar, sizeof(int));
        }

        private void AplicarColorAreaMdi_517OF()
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    _mdiClient_517OF = mdiClient;
                    mdiClient.BackColor = Estilos.FondoApp;
                    QuitarBordeMdi_517OF(mdiClient);
                    mdiClient.Dock = DockStyle.None;
                    AjustarAreaMdi_517OF();
                    break;
                }
            }

            pnlSidebar.BringToFront();
        }

        private void QuitarBordeMdi_517OF(Control mdiClient)
        {
            int estiloActual = GetWindowLong(mdiClient.Handle, GWL_EXSTYLE);
            SetWindowLong(mdiClient.Handle, GWL_EXSTYLE, estiloActual & ~WS_EX_CLIENTEDGE);

            SetWindowPos(mdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
        }

        private void ConfigurarSidebar_517OF()
        {
            ActivarDobleBufferNativo(treeMenu);
            pnlSidebar.BackColor = Estilos.FondoApp;

            treeMenu.BorderStyle = BorderStyle.None;
            treeMenu.BackColor = Estilos.FondoApp;
            treeMenu.Font = Estilos.FuenteBase;
            treeMenu.ItemHeight = 30;
            treeMenu.Indent = 16;
            treeMenu.ShowLines = false;
            treeMenu.ShowPlusMinus = false;
            treeMenu.ShowRootLines = false;
            treeMenu.HotTracking = false;

            treeMenu.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeMenu.DrawNode += treeMenu_DrawNode;
            treeMenu.NodeMouseClick += treeMenu_NodeMouseClick;
            treeMenu.MouseMove += treeMenu_MouseMove;
            treeMenu.MouseLeave += treeMenu_MouseLeave;

            treeMenu.AfterExpand += (s, e) => treeMenu.Invalidate();
            treeMenu.AfterCollapse += (s, e) => treeMenu.Invalidate();
        }

        // Estructura oficial del menú (según EjemploMenu.docx del profesor).
        // Todos los nodos son de mentira todavía, salvo "Bitácora Eventos",
        // que ya abre una pantalla real. Se van reemplazando a medida que
        // construimos cada módulo.
        private void CargarNodosFijos_517OF()
        {
            var nodoAdmin = new TreeNode("Admin");
            nodoAdmin.Nodes.Add(new TreeNode("Usuarios"));
            nodoAdmin.Nodes.Add(new TreeNode("Perfiles"));
            nodoAdmin.Nodes.Add(new TreeNode("Backup"));
            nodoAdmin.Nodes.Add(new TreeNode("Restore"));
            nodoAdmin.Nodes.Add(new TreeNode("Bitácora Eventos"));
            nodoAdmin.Nodes.Add(new TreeNode("Dígito Verificador"));

            var nodoMaestros = new TreeNode("Maestros");
            nodoMaestros.Nodes.Add(new TreeNode("Productos"));
            nodoMaestros.Nodes.Add(new TreeNode("Clientes"));
            nodoMaestros.Nodes.Add(new TreeNode("Proveedores"));
            nodoMaestros.Nodes.Add(new TreeNode("Bitácora de Cambios"));

            // Login/Logout ya están resueltos en el footer (Iniciar/Cerrar
            // sesión) — quedan acá como referencia fiel al mockup del
            // profesor, a decidir si los sacamos para no duplicar.
            var nodoUsuario = new TreeNode("Usuario");
            nodoUsuario.Nodes.Add(new TreeNode("Login"));
            nodoUsuario.Nodes.Add(new TreeNode("Cambiar Clave"));
            nodoUsuario.Nodes.Add(new TreeNode("Logout"));
            nodoUsuario.Nodes.Add(new TreeNode("Cambiar Idioma"));

            var nodoVentas = new TreeNode("Ventas");
            nodoVentas.Nodes.Add(new TreeNode("Carrito"));
            nodoVentas.Nodes.Add(new TreeNode("Facturar"));
            nodoVentas.Nodes.Add(new TreeNode("Despachar"));

            var nodoCompras = new TreeNode("Compras");
            nodoCompras.Nodes.Add(new TreeNode("Cotizaciones"));
            nodoCompras.Nodes.Add(new TreeNode("Orden de Compra"));
            nodoCompras.Nodes.Add(new TreeNode("Recepción"));

            var nodoReportes = new TreeNode("Reportes");
            nodoReportes.Nodes.Add(new TreeNode("Reporte de Ventas"));
            nodoReportes.Nodes.Add(new TreeNode("Reporte de Compras"));
            nodoReportes.Nodes.Add(new TreeNode("Reporte Inteligente"));

            var nodoAyuda = new TreeNode("Ayuda");
            nodoAyuda.Nodes.Add(new TreeNode("Maestros"));
            nodoAyuda.Nodes.Add(new TreeNode("Ventas"));
            nodoAyuda.Nodes.Add(new TreeNode("Compras"));

            treeMenu.Nodes.AddRange(new[]
            {
                nodoAdmin, nodoMaestros, nodoUsuario,
                nodoVentas, nodoCompras, nodoReportes, nodoAyuda
            });

            nodoAdmin.Expand();
        }

        private void treeMenu_DrawNode(object? sender, DrawTreeNodeEventArgs e)
        {
            var g = e.Graphics;
            bool seleccionado = e.Node == treeMenu.SelectedNode;
            bool esHover = e.Node == _nodoHover;
            bool tieneHijos = e.Node!.Nodes.Count > 0;

            Color colorFondo = seleccionado
                ? Estilos.FondoSeleccionado
                : esHover
                    ? Estilos.HoverItem
                    : Estilos.FondoApp;

            using (var brush = new SolidBrush(colorFondo))
                g.FillRectangle(brush, 0, e.Bounds.Top, treeMenu.Width, e.Bounds.Height);

            if (tieneHijos)
            {
                int chevronX = e.Bounds.Left + 8;
                int chevronY = e.Bounds.Top + e.Bounds.Height / 2;
                DibujarChevron_517OF(g, chevronX, chevronY, e.Node.IsExpanded);
            }

            Color colorTexto = seleccionado
                ? Estilos.Acento
                : e.Node.Level == 0
                    ? Estilos.TextoPrimario
                    : Estilos.TextoSecundario;

            int textoX = e.Bounds.Left + 22;
            var rectoTexto = new Rectangle(textoX, e.Bounds.Top, e.Bounds.Width - 22, e.Bounds.Height);

            TextRenderer.DrawText(g, e.Node.Text, treeMenu.Font, rectoTexto, colorTexto,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void DibujarChevron_517OF(Graphics g, int x, int y, bool expandido)
        {
            using (var brush = new SolidBrush(Estilos.TextoSecundario))
            {
                Point[] puntos = expandido
                    ? new[] { new Point(x - 4, y - 2), new Point(x + 4, y - 2), new Point(x, y + 3) }
                    : new[] { new Point(x - 2, y - 4), new Point(x - 2, y + 4), new Point(x + 3, y) };

                g.FillPolygon(brush, puntos);
            }
        }

        private void treeMenu_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            treeMenu.SelectedNode = e.Node;

            if (e.Node!.Nodes.Count > 0)
                e.Node.Toggle();
            else if (e.Node.Text == "Bitácora Eventos")
                AbrirPantalla_517OF(new FormBitacoraEventos_517OF());
        }

        private void treeMenu_MouseMove(object? sender, MouseEventArgs e)
        {
            var nodo = treeMenu.GetNodeAt(e.Location);
            if (nodo != _nodoHover)
            {
                _nodoHover = nodo;
                treeMenu.Invalidate();
            }
        }

        private void treeMenu_MouseLeave(object? sender, EventArgs e)
        {
            _nodoHover = null;
            treeMenu.Invalidate();
        }

        private void ActivarDobleBufferNativo(TreeView tree)
        {
            SendMessage(tree.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
        }

        private void ConfigurarFooter_517OF()
        {
            pnlFooter.BackColor = Estilos.FondoApp;

            _lblSinSesionArbol = new Label
            {
                Text = "Iniciá sesión para ver el menú",
                ForeColor = Estilos.TextoDeshabilitado,
                Font = Estilos.FuenteBase,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            pnlSidebar.Controls.Add(_lblSinSesionArbol);
            _lblSinSesionArbol.BringToFront();

            _pnlFooterSinSesion = new Panel { Dock = DockStyle.Fill, BackColor = Estilos.FondoApp };
            var btnIniciarSesion = CrearBotonFooter_517OF("Iniciar sesión");
            btnIniciarSesion.Dock = DockStyle.Top;
            btnIniciarSesion.Click += (s, e) => AbrirLogin_517OF();
            _pnlFooterSinSesion.Controls.Add(btnIniciarSesion);

            var btnSalirSinSesion = CrearBotonFooter_517OF("Salir");
            btnSalirSinSesion.Dock = DockStyle.Bottom;
            btnSalirSinSesion.Click += (s, e) => Close();
            _pnlFooterSinSesion.Controls.Add(btnSalirSinSesion);

            _pnlFooterConSesion = new Panel { Dock = DockStyle.Fill, BackColor = Estilos.FondoApp, Visible = false };
            var btnCerrarSesion = CrearBotonFooter_517OF("Cerrar sesión");
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.Click += (s, e) =>
            {
                CerrarPantallasAbiertas_517OF();

                new BitacoraEventoSEG_517OF().RegistrarEnBitacora_517OF(new BitacoraEvento_517OF
                {
                    Usuario_517OF = Sesion_517OF.Instancia.UsuarioActual_517OF!,
                    TipoEvento_517OF = new TipoEvento_517OF { Id_517OF = (int)EventosConocidos_517OF.Logout_517OF }
                });
                Sesion_517OF.Instancia.CerrarSesion_517OF();
                ActualizarEstadoSidebar_517OF();
            };
            _pnlFooterConSesion.Controls.Add(btnCerrarSesion);

            pnlFooter.Controls.Add(_pnlFooterConSesion);
            pnlFooter.Controls.Add(_pnlFooterSinSesion);
        }

        private Label CrearBotonFooter_517OF(string texto)
        {
            var lbl = new Label
            {
                Text = texto,
                ForeColor = Estilos.TextoSecundario,
                Font = Estilos.FuenteBase,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30,
                Cursor = Cursors.Hand
            };
            lbl.MouseEnter += (s, e) => lbl.BackColor = Estilos.HoverItem;
            lbl.MouseLeave += (s, e) => lbl.BackColor = Estilos.FondoApp;
            return lbl;
        }

        private void ActualizarEstadoSidebar_517OF()
        {
            bool haySesion = Sesion_517OF.Instancia.HaySesionActiva_517OF;

            treeMenu.Visible = haySesion;
            _lblSinSesionArbol.Visible = !haySesion;

            _pnlFooterConSesion.Visible = haySesion;
            _pnlFooterSinSesion.Visible = !haySesion;
        }

        private void AbrirLogin_517OF()
        {
            using (var login = new FormLogin_517OF())
            {
                if (login.ShowDialog(this) == DialogResult.OK && login.UsuarioLogueado != null)
                {
                    Sesion_517OF.Instancia.IniciarSesion_517OF(login.UsuarioLogueado);
                    ActualizarEstadoSidebar_517OF();
                }
            }
        }

        private void AjustarAreaMdi_517OF()
        {
            if (_mdiClient_517OF == null)
                return;

            _mdiClient_517OF.Bounds = new Rectangle(
                pnlSidebar.Width, 0,
                ClientSize.Width - pnlSidebar.Width,
                ClientSize.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AjustarAreaMdi_517OF();
        }

        // Cierra la pantalla que esté abierta (si hay alguna) antes de abrir
        // la nueva — solo se permite una pantalla de trabajo visible a la vez.
        private void AbrirPantalla_517OF(Form formulario)
        {
            CerrarPantallasAbiertas_517OF();

            formulario.MdiParent = this;
            formulario.Show();
        }
        // Cierra todas las pantallas de trabajo abiertas — se usa tanto al
        // cambiar de pantalla como al cerrar sesión, para no dejar ninguna
        // pantalla huérfana sin usuario logueado.
        private void CerrarPantallasAbiertas_517OF()
        {
            foreach (Form hijo in MdiChildren.ToArray())
                hijo.Close();
        }
    }
}