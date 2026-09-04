using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DAL_SERVICIOS_517OF
{
    public class Acceso_517OF
    {
        private SqlConnection? _conex_517OF;
        private SqlTransaction? _tx_517OF;

        // En App.config tengo definidas las conexiones a las dos DBs (TRSDiploma y master)
        private static string ObtenerCadena_517OF(string qconexion)
        {
            var connStringObject = ConfigurationManager.ConnectionStrings[qconexion];
            if (connStringObject != null)
            {
                return connStringObject.ConnectionString;
            }
            else
            {
                throw new ArgumentNullException(nameof(qconexion), $"No se encontró la cadena con nombre: {qconexion}");
            }
        }

        private void Abrir_517OF(string qbase)
        {
            _conex_517OF = new SqlConnection(ObtenerCadena_517OF(qbase));
            _conex_517OF.Open();
        }

        private void Cerrar_517OF()
        {
            if (_conex_517OF != null)
            {
                _conex_517OF.Close();
                _conex_517OF.Dispose();
                _conex_517OF = null;
            }
        }

        public int Ejecutar_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            Abrir_517OF("MiConexion");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nombreSP;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex_517OF;

                if (paramsArray != null)
                {
                    cmd.Parameters.AddRange(paramsArray);
                }

                if (_conex_517OF != null)
                {
                    _tx_517OF = _conex_517OF.BeginTransaction();
                    cmd.Transaction = _tx_517OF;
                }

                try
                {
                    fa = cmd.ExecuteNonQuery();
                    if (_tx_517OF != null) _tx_517OF.Commit();
                }
                catch (Exception)
                {
                    fa = -1;
                    if (_tx_517OF != null) _tx_517OF.Rollback();
                }
                finally
                {
                    Cerrar_517OF();
                }
            }

            return fa;
        }

        public DataTable Leer_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = nombreSP;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                Abrir_517OF("MiConexion");
                da.SelectCommand.Connection = _conex_517OF;

                if (paramsArray != null)
                {
                    da.SelectCommand.Parameters.AddRange(paramsArray);
                }

                da.Fill(dt);
                Cerrar_517OF();
            }

            return dt;
        }

        public int LeerEscalar_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            Abrir_517OF("MiConexion");
            int valorEscalar = 0;

            using (SqlCommand cmd = new SqlCommand(nombreSP, _conex_517OF))
            {
                if (paramsArray != null)
                {
                    cmd.Parameters.AddRange(paramsArray);
                }
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        valorEscalar = Convert.ToInt32(resultado);
                    }
                }
                catch (Exception)
                {
                    valorEscalar = 0;
                }
                finally
                {
                    Cerrar_517OF();
                }
            }

            return valorEscalar;
        }

        public int Escribir_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            Abrir_517OF("MiConexion");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nombreSP;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex_517OF;

                if (paramsArray != null)
                {
                    cmd.Parameters.AddRange(paramsArray);
                }

                try
                {
                    fa = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    fa = -1;
                }
                finally
                {
                    Cerrar_517OF();
                }
            }

            return fa;
        }

        public int EscribirMaster_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            Abrir_517OF("MiConexionMaster");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nombreSP;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex_517OF;

                if (paramsArray != null)
                {
                    cmd.Parameters.AddRange(paramsArray);
                }

                try
                {
                    fa = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    fa = -1;
                }
                finally
                {
                    Cerrar_517OF();
                }
            }

            return fa;
        }

        #region CrearParámetros

        public SqlParameter CrearParam_517OF(string nombre, string? valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = (object?)valor ?? DBNull.Value;
            p.DbType = DbType.String;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, int valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Int32;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, DateTime valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.DateTime2;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, bool valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Boolean;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, double valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Double;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, decimal valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Decimal;
            return p;
        }

        #endregion

    }
}
