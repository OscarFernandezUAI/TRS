using BE_517OF;
using DAL_SERVICIOS_517OF;
using Microsoft.Data.SqlClient;

namespace SEGURIDAD_517OF
{
    public class BitacoraEventoSEG_517OF
    {
        public int Registrar_517OF(int idUsuario, int idTipoEvento)
        {
            var acceso = new Acceso_517OF();

            SqlParameter[] parametros = new SqlParameter[]
            {
        acceso.CrearParam_517OF("@IdUsuario_517OF", idUsuario),
        acceso.CrearParam_517OF("@IdTipoEvento_517OF", idTipoEvento)
            };

            return acceso.Escribir_517OF("sp_BitacoraEvento_Alta_517OF", parametros);
        }
    }
}