using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.ControlesComunes
{
    // Label estándar, sin lógica de traducción todavía.
    // La propiedad ClaveTraduccion_517OF queda preparada para cuando se
    // implemente T05 (GestorIdioma + patrón Observer).
    public class LabelTraducible_517OF : Label
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ClaveTraduccion_517OF { get; set; } = string.Empty;
    }
}