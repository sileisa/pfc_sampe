using System;
using System.Collections.Generic;

namespace Sampe
{
    public partial class Usuario
    {
        public string IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public int IdCargo { get; set; }
        public int IdHierarquia { get; set; }
    }
}
