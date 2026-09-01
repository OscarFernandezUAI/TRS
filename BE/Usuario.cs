using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string ClaveHash { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
