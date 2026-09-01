using BE;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        public Usuario? ValidarUsuario(string nombreUsuario, string claveIngresada)
        {
            var dal = new MapperUsuario();

            var usuarioBusqueda = new Usuario { NombreUsuario = nombreUsuario };
            Usuario? usuario = dal.ObtenerPorNombreUsuario(usuarioBusqueda);

            if (usuario == null || !usuario.Activo)
                return null;

            if (usuario.ClaveHash != claveIngresada)
                return null;

            return usuario;
        }
    }
}