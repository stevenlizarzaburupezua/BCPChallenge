using System.Threading.Tasks;
using BCP.TipoCambio.Application.Interface;
using BCP.Domain.Seedwork;
using System.Collections.Generic;
using BCP.TipoCambio.DTO.TipoCambio.Request;
using BCP.TipoCambio.DTO.TipoCambio.Response;
using BCP.TipoCambio.Domain.Entities;
using System.Linq;
using BCP.TipoCambio.Domain.Interface.Repository;
using BCP.TipoCambio.Domain.VO;
using BCP.TipoCambio.Translator;

namespace BCP.TipoCambio.Application.Implementation
{
    public class TipoCambioService : ITipoCambioService
    {
        private readonly ITipoCambioRepository _tipoCambioRepository;

        public TipoCambioService(ITipoCambioRepository tipoCambioRepository)
        {
            _tipoCambioRepository = tipoCambioRepository;
        }

        public async Task<IList<ConsultaTipoCambioDTO>> GetMonedasAsync()
        {
            return await _tipoCambioRepository.ConsultaMonedasAsync<ConsultaTipoCambioDTO>();
        }

        public async Task<ConsultaTipoCambioDTO> GetTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino)
        {
            return (await _tipoCambioRepository.ConsultaTipoCambioAsync(monto, monedaOrigen, monedaDestino)).Map<ConsultaTipoCambio, ConsultaTipoCambioDTO>();
        }

    }
}
