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
        public DataTable Leer_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand();
                    da.SelectCommand.CommandText = nombreSP;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    Abrir_517OF("MiConexion");
                    da.SelectCommand.Connection = _conex_517OF;

                    if (paramsArray != null)
                        da.SelectCommand.Parameters.AddRange(paramsArray);

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en Leer_517OF ({nombreSP}): {ex.Message}");
                LogArchivo_517OF.RegistrarError_517OF("Leer_517OF", $"{nombreSP}: {ex.Message}");
            }
            finally
            {
                Cerrar_517OF();
            }

            return dt;
        }

        public int Escribir_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            int fa = -1;

            try
            {
                Abrir_517OF("MiConexion");

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = nombreSP;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _conex_517OF;

                    if (paramsArray != null)
                        cmd.Parameters.AddRange(paramsArray);

                    fa = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                fa = -1;
                System.Diagnostics.Debug.WriteLine($"Error en Escribir_517OF ({nombreSP}): {ex.Message}");
                LogArchivo_517OF.RegistrarError_517OF("Escribir_517OF", $"{nombreSP}: {ex.Message}");
            }
            finally
            {
                Cerrar_517OF();
            }

            return fa;
        }

        public int EscribirMaster_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            int fa = -1;

            try
            {
                Abrir_517OF("MiConexionMaster");

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = nombreSP;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _conex_517OF;

                    if (paramsArray != null)
                        cmd.Parameters.AddRange(paramsArray);

                    fa = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                fa = -1;
                System.Diagnostics.Debug.WriteLine($"Error en EscribirMaster_517OF ({nombreSP}): {ex.Message}");
                LogArchivo_517OF.RegistrarError_517OF("EscribirMaster_517OF", $"{nombreSP}: {ex.Message}");
            }
            finally
            {
                Cerrar_517OF();
            }

            return fa;
        }

        public int LeerEscalar_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            int valorEscalar = 0;

            try
            {
                Abrir_517OF("MiConexion");

                using (SqlCommand cmd = new SqlCommand(nombreSP, _conex_517OF))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (paramsArray != null)
                        cmd.Parameters.AddRange(paramsArray);

                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                        valorEscalar = Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                valorEscalar = 0;
                System.Diagnostics.Debug.WriteLine($"Error en LeerEscalar_517OF ({nombreSP}): {ex.Message}");
                LogArchivo_517OF.RegistrarError_517OF("LeerEscalar_517OF", $"{nombreSP}: {ex.Message}");
            }
            finally
            {
                Cerrar_517OF();
            }

            return valorEscalar;
        }

        public int Ejecutar_517OF(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            int fa = -1;

            try
            {
                Abrir_517OF("MiConexion");

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = nombreSP;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = _conex_517OF;

                    if (paramsArray != null)
                        cmd.Parameters.AddRange(paramsArray);

                    _tx_517OF = _conex_517OF!.BeginTransaction();
                    cmd.Transaction = _tx_517OF;

                    try
                    {
                        fa = cmd.ExecuteNonQuery();
                        _tx_517OF!.Commit();
                    }
                    catch (Exception exInterna)
                    {
                        fa = -1;
                        _tx_517OF!.Rollback();
                        System.Diagnostics.Debug.WriteLine($"Error en Ejecutar_517OF ({nombreSP}) durante la transacción: {exInterna.Message}");
                        LogArchivo_517OF.RegistrarError_517OF("Ejecutar_517OF", $"{nombreSP} (durante transacción): {exInterna.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                fa = -1;
                System.Diagnostics.Debug.WriteLine($"Error en Ejecutar_517OF ({nombreSP}) al conectar: {ex.Message}");
                LogArchivo_517OF.RegistrarError_517OF("Ejecutar_517OF", $"{nombreSP} (al conectar): {ex.Message}");
            }
            finally
            {
                Cerrar_517OF();
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
        public SqlParameter CrearParam_517OF(string nombre, int? valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor.HasValue ? valor.Value : DBNull.Value;
            p.DbType = DbType.Int32;
            return p;
        }

        public SqlParameter CrearParam_517OF(string nombre, DateTime? valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor.HasValue ? valor.Value : DBNull.Value;
            p.DbType = DbType.DateTime2;
            return p;
        }
        #endregion

    }
}
