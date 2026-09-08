using System;
using System.Collections.Generic;
using System.Text;

namespace BE_517OF
{
    public class TipoEvento_517OF : EntidadBase_517OF
    {
        public string Nombre_517OF { get; set; } = string.Empty;
        public Modulo_517OF Modulo_517OF { get; set; } = null!;
        public int Criticidad_517OF { get; set; }
        public string? ClaveTraduccion_517OF { get; set; }
        public override string ToString() => Nombre_517OF;
    }
}
