using System.Windows.Forms;

namespace GUI_517OF.ControlesComunes
{
    public class CajaTextoValidable_517OF : TextBox
    {
        public virtual bool Validar_517OF()
        {
            return !string.IsNullOrWhiteSpace(Text);
        }
    }
}
