using BE_517OF;
using DAL_SERVICIOS_517OF;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace SEGURIDAD_517OF
{
    public class BitacoraEventoSEG_517OF
    {
        public void RegistrarEnBitacora_517OF(BitacoraEvento_517OF entidad)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
        acceso.CrearParam_517OF("@IdUsuario_517OF", entidad.Usuario_517OF.Id_517OF),
        acceso.CrearParam_517OF("@IdTipoEvento_517OF", entidad.TipoEvento_517OF.Id_517OF)
            };

            int resultado = acceso.Escribir_517OF("sp_BitacoraEvento_Alta_517OF", parametros);

            if (resultado != 1)
            {
                LogArchivo_517OF.RegistrarError_517OF(
                    "BitacoraEventoSEG_517OF.RegistrarEnBitacora_517OF",
                    $"No se pudo registrar el evento {entidad.TipoEvento_517OF.Id_517OF} del usuario {entidad.Usuario_517OF.Id_517OF}.");
            }
        }
        public List<Modulo_517OF> ConsultarModulos_517OF()
        {
            var acceso = new Acceso_517OF();
            DataTable dt = acceso.Leer_517OF("sp_Modulo_Consultar_517OF");

            var lista = new List<Modulo_517OF>();

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Modulo_517OF
                {
                    Id_517OF = (int)fila["IdModulo_517OF"],
                    Nombre_517OF = fila["Nombre_517OF"].ToString() ?? string.Empty,
                    ClaveTraduccion_517OF = fila["ClaveTraduccion_517OF"] == DBNull.Value ? null : fila["ClaveTraduccion_517OF"].ToString()
                });
            }

            return lista;
        }

        public List<TipoEvento_517OF> ConsultarTiposEvento_517OF()
        {
            var acceso = new Acceso_517OF();
            DataTable dt = acceso.Leer_517OF("sp_TipoEvento_Consultar_517OF");

            var lista = new List<TipoEvento_517OF>();

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new TipoEvento_517OF
                {
                    Id_517OF = (int)fila["IdTipoEvento_517OF"],
                    Nombre_517OF = fila["Nombre_517OF"].ToString() ?? string.Empty,
                    Criticidad_517OF = (int)fila["Criticidad_517OF"],
                    ClaveTraduccion_517OF = fila["ClaveTraduccion_517OF"] == DBNull.Value ? null : fila["ClaveTraduccion_517OF"].ToString(),
                    Modulo_517OF = new Modulo_517OF
                    {
                        Id_517OF = (int)fila["IdModulo_517OF"],
                        Nombre_517OF = fila["NombreModulo_517OF"].ToString() ?? string.Empty
                    }
                });
            }

            return lista;
        }
        public List<BitacoraEvento_517OF> ConsultarBitacora_517OF(FiltroBitacoraEvento_517OF filtro)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
        acceso.CrearParam_517OF("@IdUsuario_517OF", filtro.IdUsuario_517OF),
        acceso.CrearParam_517OF("@FechaIni_517OF", filtro.FechaIni_517OF),
        acceso.CrearParam_517OF("@FechaFin_517OF", filtro.FechaFin_517OF),
        acceso.CrearParam_517OF("@IdModulo_517OF", filtro.IdModulo_517OF),
        acceso.CrearParam_517OF("@IdTipoEvento_517OF", filtro.IdTipoEvento_517OF),
        acceso.CrearParam_517OF("@Criticidad_517OF", filtro.Criticidad_517OF)
            };

            DataTable dt = acceso.Leer_517OF("sp_BitacoraEvento_Consultar_517OF", parametros);

            var lista = new List<BitacoraEvento_517OF>();

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new BitacoraEvento_517OF
                {
                    Id_517OF = (int)fila["IdBitacoraEvento_517OF"],
                    FechaHora_517OF = (DateTime)fila["FechaHora_517OF"],
                    Usuario_517OF = new Usuario_517OF
                    {
                        Id_517OF = (int)fila["IdUsuario_517OF"],
                        NombreUsuario_517OF = fila["NombreUsuario_517OF"].ToString() ?? string.Empty,
                        Nombre_517OF = fila["Nombre_517OF"].ToString() ?? string.Empty,
                        Apellido_517OF = fila["Apellido_517OF"].ToString() ?? string.Empty
                    },
                    TipoEvento_517OF = new TipoEvento_517OF
                    {
                        Id_517OF = (int)fila["IdTipoEvento_517OF"],
                        Nombre_517OF = fila["NombreTipoEvento_517OF"].ToString() ?? string.Empty,
                        Criticidad_517OF = (int)fila["Criticidad_517OF"],
                        ClaveTraduccion_517OF = fila["ClaveTraduccionEvento_517OF"] == DBNull.Value ? null : fila["ClaveTraduccionEvento_517OF"].ToString(),
                        Modulo_517OF = new Modulo_517OF
                        {
                            Id_517OF = (int)fila["IdModulo_517OF"],
                            Nombre_517OF = fila["NombreModulo_517OF"].ToString() ?? string.Empty,
                            ClaveTraduccion_517OF = fila["ClaveTraduccionModulo_517OF"] == DBNull.Value ? null : fila["ClaveTraduccionModulo_517OF"].ToString()
                        }
                    }
                });
            }

            return lista;
        }
    }
}