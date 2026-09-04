using System;
using BE_517OF;
using DAL_517OF;

namespace BLL_517OF
{
    public class UsuarioBLL_517OF : IAbmcBll_517OF<Usuario_517OF>
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

        public int Alta_517OF(Usuario_517OF entidad)
        {
            // TODO T04: generar la contraseña automática (Nombre+DNI, a definir),
            // marcar DebeCambiarClave_517OF = true, y recién ahí delegar al DAL.
            throw new NotImplementedException();
        }

        public int Baja_517OF(Usuario_517OF entidad)
        {
            // TODO: implementar delegación real al DAL cuando exista una pantalla que lo use.
            throw new NotImplementedException();
        }

        public int Modificar_517OF(Usuario_517OF entidad)
        {
            // TODO: implementar delegación real al DAL cuando exista una pantalla que lo use.
            throw new NotImplementedException();
        }

        public List<Usuario_517OF> Consultar_517OF()
        {
            // TODO: implementar delegación real al DAL cuando exista una pantalla que lo use.
            throw new NotImplementedException();
        }
        public Usuario_517OF? ObtenerPorNombreUsuario_517OF(string nombreUsuario)
        {
            var dal = new MapperUsuario_517OF();
            var usuarioBusqueda = new Usuario_517OF { NombreUsuario_517OF = nombreUsuario };
            return dal.ObtenerPorNombreUsuario_517OF(usuarioBusqueda);
        }
    }
}