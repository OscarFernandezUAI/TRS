using System.Windows.Forms;

namespace GUI.ControlesComunes
{
    public class CajaTextoValidable : TextBox
    {
        public virtual bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Text);
        }
    }
}
