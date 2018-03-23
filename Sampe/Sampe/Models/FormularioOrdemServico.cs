using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampe
{
    public class FormularioOrdemServico
    {
        public int FormularioOrdemServicoId { get; set; }
        public string TipoManutencao { get; set; }

        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public String Dt { get; set; }

        public Boolean Intervalo { get; set; }
        public string IntervaloInicio { get; set; }
        public string IntervaloFim { get; set; }
        public string ObsIntervalo { get; set; }
        
        public String Executante { get; set; }

        [ForeignKey("Maquina")]
        public int MaquinaId { get; set; }
        public Maquina Maquina { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
