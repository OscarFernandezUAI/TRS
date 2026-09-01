using System.Data;
using BE_517OF;
using DAL_SERVICIOS_517OF;
using Microsoft.Data.SqlClient;

namespace DAL_517OF
{
    public class MapperUsuario_517OF
    {
        public Usuario_517OF? ObtenerPorNombreUsuario_517OF(Usuario_517OF usuarioBusqueda)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[]
            {
        acceso.crearparam("@NombreUsuario_517OF", usuarioBusqueda.NombreUsuario_517OF)
            };

            DataTable dt = acceso.Leer("sp_Usuario_ObtenerPorNombreUsuario_517OF", parametros);

            if (dt.Rows.Count == 0)
                return null;

            DataRow fila = dt.Rows[0];

            return new Usuario_517OF
            {
                Id_517OF = (int)fila["IdUsuario_517OF"],
                NombreUsuario_517OF = fila["NombreUsuario_517OF"].ToString() ?? string.Empty,
                ClaveHash_517OF = fila["Clave_517OF"].ToString() ?? string.Empty,
                Activo_517OF = (bool)fila["Activo_517OF"]
            };
        }
    }
}
