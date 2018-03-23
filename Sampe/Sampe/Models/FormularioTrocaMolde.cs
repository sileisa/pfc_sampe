using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampe
{
    public class FormularioTrocaMolde
    {
        public int FormularioTrocaMoldeId { get; set; }
        public string DtRetirada { get; set; }
        public string DtColocar { get; set; }
        public string ColocarInicio { get; set; }
        public string ColocarFim { get; set; }
        public String RetirarInicio { get; set; }
        public String RetirarFim { get; set; }
        public String Executante { get; set; }

        [ForeignKey("Molde")]
        public int MoldeId{ get; set; }
        public Molde Molde { get; set; }

        [ForeignKey("Maquina")]
        public int MaquinaId { get; set; }
        public Maquina Maquina{ get; set; }
        

        [ForeignKey("Usuario")]
        public int  UsuarioId{ get; set; }
        public Usuario Usuario { get; set; }

    }
}
