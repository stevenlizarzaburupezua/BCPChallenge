
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Domain.Seedwork;
using BCP.TipoCambio.Domain.Entities;
using BCP.TipoCambio.Domain.VO;

namespace BCP.TipoCambio.Domain.Interface.Repository
{
    public interface ITipoCambioRepository
    {
        Task<IList<T>> ConsultaMonedasAsync<T>() where T : RawDTO;
        Task<TipooCambio> ConsultaTipoCambioAsync( int monedaOrigen, int monedaDestino);
        Task<Moneda> ConsultaMonedaAsync(int codMoneda);
        Task RegistrarClienteAsync(RegistrarCliente filtro);
        Task<IList<T>> ValidarDatosIngresoWebAsync<T>(ValidarIngresoApp filtro) where T : RawDTO;
    }
}
