using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DAL_SERVICIOS_517OF
{
    public class Acceso
    {
        private SqlConnection? _conex;
        private SqlTransaction? tx;

        // En App.config tengo definidas las conexiones a las dos DBs (TRSDiploma y master)
        public static string ObtenerCadena(string qconexion)
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

        private void abrir(string qbase)
        {
            _conex = new SqlConnection(ObtenerCadena(qbase));
            _conex.Open();
        }

        private void Cerrar()
        {
            if (_conex != null)
            {
                _conex.Close();
                _conex.Dispose();
                _conex = null;
            }
        }

        public int Ejecutar(string nombreSP, SqlParameter[]? paramsArray = null)
        {
            abrir("MiConexion");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nombreSP;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex;

                if (paramsArray != null)
                {
                    cmd.Parameters.AddRange(paramsArray);
                }

                if (_conex != null)
                {
                    tx = _conex.BeginTransaction();
                    cmd.Transaction = tx;
                }

                try
                {
                    fa = cmd.ExecuteNonQuery();
                    if (tx != null) tx.Commit();
                }
                catch (Exception)
                {
                    fa = -1;
                    if (tx != null) tx.Rollback();
                }
                finally
                {
                    Cerrar();
                }
            }

            return fa;
        }

        public DataTable Leer(string nomst, SqlParameter[]? paramsArray = null)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = nomst;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                abrir("MiConexion");
                da.SelectCommand.Connection = _conex;

                if (paramsArray != null)
                {
                    da.SelectCommand.Parameters.AddRange(paramsArray);
                }

                da.Fill(dt);
                Cerrar();
            }

            return dt;
        }

        public int LeerEscalar(string nomst, SqlParameter[]? paramsArray = null)
        {
            abrir("MiConexion");
            int valorEscalar = 0;

            using (SqlCommand cmd = new SqlCommand(nomst, _conex))
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
                    Cerrar();
                }
            }

            return valorEscalar;
        }

        public int Escribir(string nomst, SqlParameter[]? paramsArray = null)
        {
            abrir("MiConexion");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nomst;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex;

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
                    Cerrar();
                }
            }

            return fa;
        }

        public int EscribirMaster(string nomst, SqlParameter[]? paramsArray = null)
        {
            abrir("MiConexionMaster");
            int fa = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = nomst;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _conex;

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
                    Cerrar();
                }
            }

            return fa;
        }

        #region CrearParámetros

        public SqlParameter crearparam(string nombre, string? valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = (object?)valor ?? DBNull.Value;
            p.DbType = DbType.String;
            return p;
        }

        public SqlParameter crearparam(string nombre, int valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Int32;
            return p;
        }

        public SqlParameter crearparam(string nombre, DateTime valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.DateTime2;
            return p;
        }

        public SqlParameter crearparam(string nombre, bool valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Boolean;
            return p;
        }

        public SqlParameter crearparam(string nombre, double valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Double;
            return p;
        }

        public SqlParameter crearparam(string nombre, decimal valor)
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
