using System.Drawing;

namespace TRS
{
    public static class Estilos
    {
        // Superficies
        public static readonly Color FondoApp = ColorTranslator.FromHtml("#1c1e22");
        public static readonly Color FondoPanel = ColorTranslator.FromHtml("#25282e");
        public static readonly Color Borde = ColorTranslator.FromHtml("#2c2f36");
        public static readonly Color HoverItem = ColorTranslator.FromHtml("#32353c");

        // Texto
        public static readonly Color TextoPrimario = ColorTranslator.FromHtml("#e8e8e8");
        public static readonly Color TextoSecundario = ColorTranslator.FromHtml("#9a9da3");
        public static readonly Color TextoDeshabilitado = ColorTranslator.FromHtml("#6b6d73");

        // Acento de marca
        public static readonly Color Acento = ColorTranslator.FromHtml("#e8ad4f");
        public static readonly Color FondoSeleccionado = ColorTranslator.FromHtml("#3a2f1e");

        // Semánticos
        public static readonly Color Exito = ColorTranslator.FromHtml("#4fae6d");
        public static readonly Color Error = ColorTranslator.FromHtml("#e0605a");
        public static readonly Color Advertencia = ColorTranslator.FromHtml("#e0904f");
        public static readonly Color Informacion = ColorTranslator.FromHtml("#4fa8c9");

        // Tipografía
        public static readonly Font FuenteBase = new Font("Segoe UI", 9.5F);
    }
}
