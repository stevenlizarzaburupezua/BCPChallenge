using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.TipoCambio.Domain.VO
{
    public class ConsultaTipoCambio
    {
        public decimal Monto { get; set; }
        public decimal MontoTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
    }
}
