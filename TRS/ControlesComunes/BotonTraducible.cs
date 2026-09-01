using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.ControlesComunes
{
    public class BotonTraducible : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ClaveTraduccion { get; set; } = string.Empty;
    }
}