using System.Windows.Forms;

namespace GUI.ControlesComunes
{
    public class CajaTextoValidable_517OF : TextBox
    {
        public virtual bool Validar_517OF()
        {
            return !string.IsNullOrWhiteSpace(Text);
        }
    }
}
