using System;
using System.IO;

namespace DAL_SERVICIOS_517OF
{
    public static class LogArchivo_517OF
    {
        private const string CarpetaLogs_517OF = "Logs";
        private const string NombreArchivo_517OF = "ErroresConexion_517OF.txt";

        public static void RegistrarError_517OF(string origen, string mensaje)
        {
            try
            {
                string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CarpetaLogs_517OF);

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string rutaArchivo = Path.Combine(carpeta, NombreArchivo_517OF);
                string linea = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {origen} | {mensaje}{Environment.NewLine}";

                File.AppendAllText(rutaArchivo, linea);
            }
            catch
            {
                // Dejo el catch vacío porque si no puede escribir el archivo de log,
                // no se debería interrumpir ni romper la app.
            }
        }
    }
}