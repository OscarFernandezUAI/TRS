using System;
using System.Collections.Generic;
using System.Text;

namespace BE_517OF
{
    public class BitacoraEvento_517OF : EntidadBase_517OF
    {
        public Usuario_517OF Usuario_517OF { get; set; } = null!;
        public TipoEvento_517OF TipoEvento_517OF { get; set; } = null!;
        public DateTime FechaHora_517OF { get; set; }
    }
}
