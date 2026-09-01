using GUI;
using SEGURIDAD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace TRS
{
    public partial class FormPrincipal : Form
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

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private TreeNode? _nodoHover;
        private const int TVM_SETEXTENDEDSTYLE = 0x112C; // Mensaje nativo para configurar estilos extendidos del TreeView
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;   // Estilo extendido: doble buffer real del control nativo

        
        private Panel _pnlFooterSinSesion = null!;
        private Panel _pnlFooterConSesion = null!;
        private Label _lblSinSesionArbol = null!;
        public FormPrincipal()
        {
            InitializeComponent();
            BackColor = Estilos.FondoApp;
            ConfigurarSidebar();
            CargarNodosFijos();

            ConfigurarFooter();
            ActualizarEstadoSidebar();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AplicarModoOscuroBarraTitulo();
            AplicarColorAreaMdi();
        }

        private void AplicarModoOscuroBarraTitulo()
        {
            int valorActivar = 1;
            DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref valorActivar, sizeof(int));
        }
        private void AplicarColorAreaMdi()
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Estilos.FondoApp;
                    QuitarBordeMdi(mdiClient);
                    break;
                }
            }
        }

        // El MdiClient trae por defecto un borde 3D hundido (estilo extendido
        // WS_EX_CLIENTEDGE), heredado del control nativo de Windows. No hay
        // una propiedad expuesta para sacarlo; hay que quitarle el estilo
        // extendido directamente y pedirle a Windows que redibuje el marco.
        private void QuitarBordeMdi(Control mdiClient)
        {
            int estiloActual = GetWindowLong(mdiClient.Handle, GWL_EXSTYLE);
            SetWindowLong(mdiClient.Handle, GWL_EXSTYLE, estiloActual & ~WS_EX_CLIENTEDGE);

            SetWindowPos(mdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
        }

        // Deja el TreeView listo para que nosotros dibujemos cada nodo a mano
        // (owner-draw), en vez de usar el estilo clásico de Windows.
        private void ConfigurarSidebar()
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

        // Carga fija en español, solo para validar el look. Más adelante
        // esto se reemplaza por la carga dinámica según el mapa de navegación.
        private void CargarNodosFijos()
        {
            var nodoProductos = new TreeNode("Productos");

            var nodoGestionCompras = new TreeNode("Gestión de compras");
            nodoGestionCompras.Nodes.Add(new TreeNode("Orden de compra"));
            nodoGestionCompras.Nodes.Add(new TreeNode("Recepción de mercadería"));

            var nodoCompras = new TreeNode("Compras");
            nodoCompras.Nodes.Add(nodoGestionCompras);
            nodoCompras.Nodes.Add(new TreeNode("Proveedores"));

            var nodoVentas = new TreeNode("Ventas");
            var nodoReposicion = new TreeNode("Reposición");
            var nodoAdministracion = new TreeNode("Administración");

            treeMenu.Nodes.AddRange(new[]
            {
             nodoProductos, nodoCompras,
             nodoVentas, nodoReposicion, nodoAdministracion
    });
                       
            nodoCompras.Expand();
            nodoGestionCompras.Expand();
        }

        // Se ejecuta una vez por cada nodo visible, cada vez que hay que redibujar.
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
                DibujarChevron(g, chevronX, chevronY, e.Node.IsExpanded);
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

        // Triangulito: apunta a la derecha si está colapsado, hacia abajo si está expandido.
        private void DibujarChevron(Graphics g, int x, int y, bool expandido)
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
        // A diferencia de otros controles, TreeView es un wrapper sobre un control
        // nativo de Windows (SysTreeView32). El DoubleBuffered por reflection no
        // alcanza a resolver el parpadeo acá; hay que activar el doble buffer nativo
        // mandándole directamente el mensaje TVM_SETEXTENDEDSTYLE al control.
        private void ActivarDobleBufferNativo(TreeView tree)
        {
            SendMessage(tree.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
        }

        // Arma los dos estados posibles del footer (sin sesión / con sesión) y el
        // mensaje que reemplaza al árbol cuando todavía no hay usuario logueado.
        private void ConfigurarFooter()
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
            var btnIniciarSesion = CrearBotonFooter("Iniciar sesión");
            btnIniciarSesion.Dock = DockStyle.Top;
            btnIniciarSesion.Click += (s, e) => AbrirLogin();
            _pnlFooterSinSesion.Controls.Add(btnIniciarSesion);

            var btnSalirSinSesion = CrearBotonFooter("Salir");
            btnSalirSinSesion.Dock = DockStyle.Bottom;
            btnSalirSinSesion.Click += (s, e) => Close();
            _pnlFooterSinSesion.Controls.Add(btnSalirSinSesion);

            _pnlFooterConSesion = new Panel { Dock = DockStyle.Fill, BackColor = Estilos.FondoApp, Visible = false };
            var btnCerrarSesion = CrearBotonFooter("Cerrar sesión");
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.Click += (s, e) =>
            {
                Sesion.Instancia.CerrarSesion();
                ActualizarEstadoSidebar();
            };
            _pnlFooterConSesion.Controls.Add(btnCerrarSesion);

            pnlFooter.Controls.Add(_pnlFooterConSesion);
            pnlFooter.Controls.Add(_pnlFooterSinSesion);
        }

        // Botón simple, mismo estilo visual que el resto del sidebar.
        private Label CrearBotonFooter(string texto)
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

        // Decide qué mostrar en el sidebar según haya sesión activa o no.
        private void ActualizarEstadoSidebar()
        {
            bool haySesion = Sesion.Instancia.HaySesionActiva;

            treeMenu.Visible = haySesion;
            _lblSinSesionArbol.Visible = !haySesion;

            _pnlFooterConSesion.Visible = haySesion;
            _pnlFooterSinSesion.Visible = !haySesion;
        }

        private void AbrirLogin()
        {
            using (var login = new FormLogin())
            {
                if (login.ShowDialog(this) == DialogResult.OK && login.UsuarioLogueado != null)
                {
                    Sesion.Instancia.IniciarSesion(login.UsuarioLogueado);
                    ActualizarEstadoSidebar();
                }
            }
        }
    }
}
