using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampe
{
    public partial class AtividadeFormularioOS
    {
        public int AtividadeFormularioOSId { get; set; }
        public int AtividadeOSId { get; set; }
        public Boolean StatusAtividadeOS { get; set; }

        [ForeignKey("FormularioOrdemServico")]
        public int FormularioOrdemServicoId { get; set; }
        public FormularioOrdemServico FormularioOrdemServico { get; set; }
    }
}
