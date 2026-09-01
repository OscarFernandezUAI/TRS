using System.ComponentModel;

namespace GUI.ControlesComunes
{
    public class CajaDecimalValidable : CajaTextoValidable
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? Valor
        {
            get => decimal.TryParse(Text, out decimal v) ? v : null;
            set => Text = value?.ToString("0.00") ?? string.Empty;
        }

        public override bool Validar()
        {
            return base.Validar() && decimal.TryParse(Text, out decimal valor) && valor >= 0;
        }
    }
}