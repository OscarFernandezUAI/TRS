using System.ComponentModel;

namespace GUI.ControlesComunes
{
    public class CajaNumericaValidable : CajaTextoValidable
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? Valor
        {
            get => int.TryParse(Text, out int v) ? v : null;
            set => Text = value?.ToString() ?? string.Empty;
        }

        public override bool Validar()
        {
            return base.Validar() && int.TryParse(Text, out int valor) && valor >= 0;
        }
    }
}