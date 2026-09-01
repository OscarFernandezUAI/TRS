using System.Data;
using BE;
using DAL_SERVICIOS;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class MapperUsuario
    {
        public Usuario? ObtenerPorNombreUsuario(Usuario usuarioBusqueda)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[]
            {
        acceso.crearparam("@NombreUsuario", usuarioBusqueda.NombreUsuario)
            };

            DataTable dt = acceso.Leer("sp_Usuario_ObtenerPorNombreUsuario", parametros);

            if (dt.Rows.Count == 0)
                return null;

            DataRow fila = dt.Rows[0];

            return new Usuario
            {
                Id = (int)fila["IdUsuario"],
                NombreUsuario = fila["NombreUsuario"].ToString() ?? string.Empty,
                ClaveHash = fila["Clave"].ToString() ?? string.Empty,
                Activo = (bool)fila["Activo"]
            };
        }
    }
}
