using System.ComponentModel;

namespace GUI_517OF.ControlesComunes
{
    public class CajaNumericaValidable_517OF : CajaTextoValidable_517OF
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? Valor_517OF
        {
            get => int.TryParse(Text, out int v) ? v : null;
            set => Text = value?.ToString() ?? string.Empty;
        }

        public override bool Validar_517OF()
        {
            return base.Validar_517OF() && int.TryParse(Text, out int valor) && valor >= 0;
        }
    }
}