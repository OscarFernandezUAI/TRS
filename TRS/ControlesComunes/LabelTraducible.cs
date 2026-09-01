using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.ControlesComunes
{
    // Label estándar, sin lógica de traducción todavía.
    // La propiedad ClaveTraduccion queda preparada para cuando se
    // implemente T05 (GestorIdioma + patrón Observer).
    public class LabelTraducible : Label
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ClaveTraduccion { get; set; } = string.Empty;
    }
}