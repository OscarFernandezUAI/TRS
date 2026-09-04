using System.Data;
using BE_517OF;
using DAL_SERVICIOS_517OF;
using Microsoft.Data.SqlClient;

namespace DAL_517OF
{
    public class MapperUsuario_517OF : IAbmcDal_517OF<Usuario_517OF>
    {
        public Usuario_517OF? ObtenerPorNombreUsuario_517OF(Usuario_517OF usuarioBusqueda)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
                acceso.CrearParam_517OF("@NombreUsuario_517OF", usuarioBusqueda.NombreUsuario_517OF)
            };

            DataTable dt = acceso.Leer_517OF("sp_Usuario_ObtenerPorNombreUsuario_517OF", parametros);

            if (dt.Rows.Count == 0)
                return null;

            return MapearUsuario_517OF(dt.Rows[0]);
        }

        public int Alta_517OF(Usuario_517OF entidad)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
                acceso.CrearParam_517OF("@NombreUsuario_517OF", entidad.NombreUsuario_517OF),
                acceso.CrearParam_517OF("@Clave_517OF", entidad.ClaveHash_517OF)
            };

            return acceso.Escribir_517OF("sp_Usuario_Alta_517OF", parametros);
        }

        public int Baja_517OF(Usuario_517OF entidad)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
                acceso.CrearParam_517OF("@IdUsuario_517OF", entidad.Id_517OF)
            };

            return acceso.Escribir_517OF("sp_Usuario_Baja_517OF", parametros);
        }

        public int Modificar_517OF(Usuario_517OF entidad)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
                acceso.CrearParam_517OF("@IdUsuario_517OF", entidad.Id_517OF),
                acceso.CrearParam_517OF("@NombreUsuario_517OF", entidad.NombreUsuario_517OF)
            };

            return acceso.Escribir_517OF("sp_Usuario_Modificar_517OF", parametros);
        }

        public List<Usuario_517OF> Consultar_517OF()
        {
            var acceso = new Acceso_517OF();

            DataTable dt = acceso.Leer_517OF("sp_Usuario_Consultar_517OF");

            var lista = new List<Usuario_517OF>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(MapearUsuario_517OF(fila));
            }

            return lista;
        }

        // Centralizo la traducción de una fila del DataTable a un objeto del tipo Usuario_517OF.        
        private Usuario_517OF MapearUsuario_517OF(DataRow fila)
        {
            return new Usuario_517OF
            {
                Id_517OF = (int)fila["IdUsuario_517OF"],
                NombreUsuario_517OF = fila["NombreUsuario_517OF"].ToString() ?? string.Empty,
                ClaveHash_517OF = fila["Clave_517OF"].ToString() ?? string.Empty,
                Activo_517OF = (bool)fila["Activo_517OF"],
                Bloqueado_517OF = (bool)fila["Bloqueado_517OF"],
                DebeCambiarClave_517OF = (bool)fila["DebeCambiarClave_517OF"],
                FechaCreacion_517OF = (DateTime)fila["FechaCreacion_517OF"],
                FechaEliminacion_517OF = fila["FechaEliminacion_517OF"] == DBNull.Value ? null : (DateTime?)fila["FechaEliminacion_517OF"],
                DVH_517OF = fila["DVH_517OF"] == DBNull.Value ? string.Empty : fila["DVH_517OF"].ToString() ?? string.Empty
            };
        }
    }
}