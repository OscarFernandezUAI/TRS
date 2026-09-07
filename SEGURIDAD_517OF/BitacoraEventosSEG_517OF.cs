using BE_517OF;
using DAL_SERVICIOS_517OF;
using Microsoft.Data.SqlClient;

namespace SEGURIDAD_517OF
{
    public class BitacoraEventoSEG_517OF
    {
        public int Registrar_517OF(BitacoraEvento_517OF entidad)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
                acceso.CrearParam_517OF("@IdUsuario_517OF", entidad.Usuario_517OF.Id_517OF),
                acceso.CrearParam_517OF("@IdTipoEvento_517OF", entidad.TipoEvento_517OF.Id_517OF)
            };

            return acceso.Escribir_517OF("sp_BitacoraEvento_Alta_517OF", parametros);
        }
    }
}