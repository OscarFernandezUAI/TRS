using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_517OF.ControlesComunes
{
    public class BotonTraducible_517OF : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ClaveTraduccion_517OF { get; set; } = string.Empty;
    }
}