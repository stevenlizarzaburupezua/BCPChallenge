using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCP.TipoCambio.DTO.TipoCambio.Request;
using BCP.TipoCambio.DTO.TipoCambio.Response;
using BCP.TipoCambio.DTO.Global;

namespace BCP.TipoCambio.Application.Interface
{
    public interface ITipoCambioService
    {
        Task<IList<ConsultaTipoCambioDTO>> GetMonedasAsync();
        Task<ConsultaTipoCambioDTO> GetTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino);
    }
}
