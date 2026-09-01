using BE_517OF;
using DAL_517OF;

namespace BLL_517OF
{
    public class UsuarioBLL_517OF
    {
        public Usuario_517OF? ValidarUsuario_517OF(string nombreUsuario, string claveIngresada)
        {
            var dal = new MapperUsuario_517OF();

            var usuarioBusqueda = new Usuario_517OF { NombreUsuario_517OF = nombreUsuario };
            Usuario_517OF? usuario = dal.ObtenerPorNombreUsuario_517OF(usuarioBusqueda);

            if (usuario == null || !usuario.Activo_517OF)
                return null;

            if (usuario.ClaveHash_517OF != claveIngresada)
                return null;

            return usuario;
        }
    }
}