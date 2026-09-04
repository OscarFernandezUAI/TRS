using System;

namespace BE_517OF
{
    public class Usuario_517OF : EntidadAuditable_517OF
    {
        public string NombreUsuario_517OF { get; set; } = string.Empty;
        public string ClaveHash_517OF { get; set; } = string.Empty;
        public bool Activo_517OF { get; set; }
        public bool Bloqueado_517OF { get; set; }
        public bool DebeCambiarClave_517OF { get; set; }
    }
}