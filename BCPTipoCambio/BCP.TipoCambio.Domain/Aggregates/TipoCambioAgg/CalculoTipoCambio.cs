using BCP.TipoCambio.Domain.Entities;
using BCP.TipoCambio.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCP.TipoCambio.Domain.Aggregates.TipoCambioAgg
{
    public static class CalculoTipoCambio
    {
        public static ConsultaTipoCambio CalcularTipoCambio(TipooCambio tipoCambio, string txtSimbolomonedaOrigen, string txtSimbolomonedaDestino, decimal monto)
        {
            return new ConsultaTipoCambio()
            {
                Monto = monto,
                MontoTipoCambio = tipoCambio.IMP_VENTA,
                MonedaOrigen = txtSimbolomonedaOrigen,
                MonedaDestino = txtSimbolomonedaDestino,
                TipoCambio = (monto * tipoCambio.IMP_VENTA)
            };
        }
    }
}

