using System.ComponentModel;

namespace GUI_517OF.ControlesComunes
{
    public class CajaDecimalValidable_517OF : CajaTextoValidable_517OF
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? Valor_517OF
        {
            get => decimal.TryParse(Text, out decimal v) ? v : null;
            set => Text = value?.ToString("0.00") ?? string.Empty;
        }

        public override bool Validar_517OF()
        {
            return base.Validar_517OF() && decimal.TryParse(Text, out decimal valor) && valor >= 0;
        }
    }
}