using BE;


namespace SEGURIDAD
{
    public sealed class Sesion
    {
        private static Sesion? _instancia;
        private static readonly object _lock = new object();

        public Usuario? UsuarioActual { get; private set; }
        public bool HaySesionActiva => UsuarioActual != null;

        private Sesion() { }

        public static Sesion Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new Sesion();
                    return _instancia!;
                }
            }
        }

        public void IniciarSesion(Usuario usuario) => UsuarioActual = usuario;

        public void CerrarSesion() => UsuarioActual = null;
    }
}