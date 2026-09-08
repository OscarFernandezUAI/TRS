using BE_517OF;
using BLL_517OF;
using SEGURIDAD_517OF;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_517OF
{
    public partial class FormBitacoraEventos_517OF : Form
    {
        private List<BitacoraEvento_517OF> _eventosActuales_517OF = new();

        public FormBitacoraEventos_517OF()
        {
            InitializeComponent();
            BackColor = Estilos.FondoApp;
            ConfigurarTitulo_517OF();
        }

        // Como el formulario no tiene barra nativa (FormBorderStyle = None),
        // armamos nuestro propio panel de título con el nombre de la pantalla.
        private void ConfigurarTitulo_517OF()
        {
            pnlTitulo.BackColor = Estilos.FondoPanel;
            lblTituloBitacora.ForeColor = Estilos.TextoPrimario;
        }

        private void FormBitacoraEventos_517OF_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla_517OF();
            CargarCombos_517OF();
            CargarUltimosTresDias_517OF();
        }

        private void dgvBitacora_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBitacora.CurrentRow == null || dgvBitacora.CurrentRow.Index < 0)
                return;

            int indice = dgvBitacora.CurrentRow.Index;
            if (indice >= _eventosActuales_517OF.Count)
                return;

            var evento = _eventosActuales_517OF[indice];
            lblValorNombre.Text = evento.Usuario_517OF.Nombre_517OF;
            lblValorApellido.Text = evento.Usuario_517OF.Apellido_517OF;
        }

        private void CargarCombos_517OF()
        {
            var seg = new BitacoraEventoSEG_517OF();
            var usuarioBll = new UsuarioBLL_517OF();

            cbUsuario.Items.Clear();
            cbUsuario.Items.Add("-");
            foreach (var usuario in usuarioBll.Consultar_517OF())
                cbUsuario.Items.Add(usuario);
            cbUsuario.SelectedIndex = 0;

            cbModulo.Items.Clear();
            cbModulo.Items.Add("-");
            foreach (var modulo in seg.ConsultarModulos_517OF())
                cbModulo.Items.Add(modulo);
            cbModulo.SelectedIndex = 0;

            cbEvento.Items.Clear();
            cbEvento.Items.Add("-");
            foreach (var evento in seg.ConsultarTiposEvento_517OF())
                cbEvento.Items.Add(evento);
            cbEvento.SelectedIndex = 0;

            cbCriticidad.Items.Clear();
            cbCriticidad.Items.Add("-");
            for (int i = 1; i <= 5; i++)
                cbCriticidad.Items.Add(i);
            cbCriticidad.SelectedIndex = 0;
        }

        private void CargarUltimosTresDias_517OF()
        {
            dtpFechaIni.Value = DateTime.Today.AddDays(-3);
            dtpFechaFin.Value = DateTime.Today;
            var filtro = new FiltroBitacoraEvento_517OF
            {
                FechaIni_517OF = DateTime.Today.AddDays(-3),
                FechaFin_517OF = DateTime.Today.AddDays(1).AddSeconds(-1)
            };

            EjecutarConsulta_517OF(filtro);
        }

        private void EjecutarConsulta_517OF(FiltroBitacoraEvento_517OF filtro)
        {
            var seg = new BitacoraEventoSEG_517OF();
            _eventosActuales_517OF = seg.ConsultarBitacora_517OF(filtro);

            dgvBitacora.Rows.Clear();
            foreach (var evento in _eventosActuales_517OF)
            {
                dgvBitacora.Rows.Add(
                    evento.Usuario_517OF.NombreUsuario_517OF,
                    evento.FechaHora_517OF.ToShortDateString(),
                    evento.FechaHora_517OF.ToShortTimeString(),
                    evento.TipoEvento_517OF.Modulo_517OF.Nombre_517OF,
                    evento.TipoEvento_517OF.Nombre_517OF,
                    evento.TipoEvento_517OF.Criticidad_517OF
                );
            }

            if (dgvBitacora.Rows.Count > 0)
                dgvBitacora.CurrentCell = dgvBitacora.Rows[0].Cells[0];
        }

        private void btnAplicar_Click(object? sender, EventArgs e)
        {
            var filtro = new FiltroBitacoraEvento_517OF
            {
                IdUsuario_517OF = cbUsuario.SelectedItem is Usuario_517OF usuario ? usuario.Id_517OF : null,
                FechaIni_517OF = dtpFechaIni.Value.Date,
                FechaFin_517OF = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1),
                IdModulo_517OF = cbModulo.SelectedItem is Modulo_517OF modulo ? modulo.Id_517OF : null,
                IdTipoEvento_517OF = cbEvento.SelectedItem is TipoEvento_517OF evento ? evento.Id_517OF : null,
                Criticidad_517OF = cbCriticidad.SelectedItem is int criticidad ? criticidad : null
            };

            EjecutarConsulta_517OF(filtro);
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            cbUsuario.SelectedIndex = 0;
            cbModulo.SelectedIndex = 0;
            cbEvento.SelectedIndex = 0;
            cbCriticidad.SelectedIndex = 0;

            CargarUltimosTresDias_517OF();
        }

        private void ConfigurarGrilla_517OF()
        {
            dgvBitacora.BackgroundColor = Estilos.FondoApp;
            dgvBitacora.GridColor = Estilos.Borde;
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.ReadOnly = true;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.MultiSelect = false;
            dgvBitacora.AllowUserToResizeColumns = false;
            dgvBitacora.AllowUserToResizeRows = false;

            dgvBitacora.ColumnHeadersDefaultCellStyle.BackColor = Estilos.FondoPanel;
            dgvBitacora.ColumnHeadersDefaultCellStyle.ForeColor = Estilos.TextoPrimario;
            dgvBitacora.DefaultCellStyle.BackColor = Estilos.FondoApp;
            dgvBitacora.DefaultCellStyle.ForeColor = Estilos.TextoSecundario;
            dgvBitacora.DefaultCellStyle.SelectionBackColor = Estilos.FondoSeleccionado;
            dgvBitacora.DefaultCellStyle.SelectionForeColor = Estilos.Acento;

            dgvBitacora.Columns.Add("Usuario", "Usuario");
            dgvBitacora.Columns.Add("Fecha", "Fecha");
            dgvBitacora.Columns.Add("Hora", "Hora");
            dgvBitacora.Columns.Add("Modulo", "Módulo");
            dgvBitacora.Columns.Add("Evento", "Evento");
            dgvBitacora.Columns.Add("Criticidad", "Criticidad");
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}