using System;
using System.Collections.Generic;

namespace Sampe
{
    public partial class FormularioOrdemServico
    {
        public string IdOrdemServico { get; set; }
        public string TipoManutencao { get; set; }
        public string HoraInico { get; set; }
        public string Dt { get; set; }
        public sbyte? Intervalo { get; set; }
        public string IntervaloInicio { get; set; }
        public string IntervaloFim { get; set; }
        public string Maquina { get; set; }
        public string HoraFinal { get; set; }
        public string IdExecutante { get; set; }
        public string IdSupervisor { get; set; }
        public string ObsIntervalo { get; set; }
    }
}
