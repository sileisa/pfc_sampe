using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sampe.Models
{
    public class AtividadeFormularioTM
    {
        public int AtividadeFormularioTMId { get; set; }
        public int AtividadeTMId { get; set; }
        public Boolean StatusAtividadeTM { get; set; }

        [ForeignKey("FormularioTrocaMolde")]
        public int FormularioTrocaMoldeId { get; set; }
        public FormularioTrocaMolde FormularioTrocaMolde { get; set; }
    }
}