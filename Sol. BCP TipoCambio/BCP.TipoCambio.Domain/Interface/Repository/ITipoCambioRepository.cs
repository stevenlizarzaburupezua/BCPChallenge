
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Domain.Seedwork;
using BCP.TipoCambio.Domain.VO;

namespace BCP.TipoCambio.Domain.Interface.Repository
{
    public interface ITipoCambioRepository
    {
        Task<IList<T>> ConsultaMonedasAsync<T>() where T : RawDTO;

        Task<ConsultaTipoCambio> ConsultaTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino);
    }
}
