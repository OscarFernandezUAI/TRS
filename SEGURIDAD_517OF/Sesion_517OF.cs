using BE_517OF;


namespace SEGURIDAD_517OF
{
    public sealed class Sesion_517OF
    {
        private static Sesion_517OF? _instancia;
        private static readonly object _lock = new object();

        public Usuario_517OF? UsuarioActual_517OF { get; private set; }
        public bool HaySesionActiva_517OF => UsuarioActual_517OF != null;

        private Sesion_517OF() { }

        public static Sesion_517OF Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new Sesion_517OF();
                    return _instancia!;
                }
            }
        }

        public void IniciarSesion_517OF(Usuario_517OF usuario) => UsuarioActual_517OF = usuario;

        public void CerrarSesion_517OF() => UsuarioActual_517OF = null;
    }
}