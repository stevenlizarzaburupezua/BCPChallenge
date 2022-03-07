using BCP.Domain.Seedwork;
using BCP.Repository.Seedwork;
using BCP.TipoCambio.Domain.Entities;
using BCP.TipoCambio.Domain.Interface.Repository;
using BCP.TipoCambio.Domain.VO;
using BCP.TipoCambio.Repository.Context;
using BCP.TipoCambio.Repository.Repositories.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BCP.TipoCambio.Repository.Repositories
{
    public class TipoCambioRepository : BaseRepository, ITipoCambioRepository
    {
        private readonly IStoreProcedureManager _storeProcedureManager;
        private BcpContext _context;

        public TipoCambioRepository(BcpContext dbContext,
                               IStoreProcedureManager storeProcedureManager) : base(dbContext)
        {
            _storeProcedureManager = storeProcedureManager;
            _context = dbContext;
        }

        #region UnitOfWork - Entity framework

        public async Task<ConsultaTipoCambio> ConsultaTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino)
        {
            var infoMonedaOrigen = await ConsultaMonedaAsync(monedaOrigen);

            var infoMonedaDestino = await ConsultaMonedaAsync(monedaDestino);

            return await (from a in _context.TIPOCAMBIO
                          where a.ID_MONEDA_ORIGEN == monedaOrigen && a.ID_MONEDA_DESTINO == monedaDestino
                          select new ConsultaTipoCambio
                          {
                              Monto = monto,
                              MontoTipoCambio = a.IMP_VENTA,
                              MonedaOrigen = infoMonedaOrigen.TXT_SIMBOLO,
                              MonedaDestino = infoMonedaDestino.TXT_SIMBOLO,
                              TipoCambio = (monto * a.IMP_VENTA),
                          }).FirstOrDefaultAsync();
        }

        public async Task<Moneda> ConsultaMonedaAsync(int codMoneda)
        {
            return await base.All<Moneda>().FirstOrDefaultAsync(f => f.ID == codMoneda);
        }

        #endregion

        #region ADO.NET

        public async Task<IList<T>> ConsultaMonedasAsync<T>() where T : RawDTO
        {
            return await _storeProcedureManager.ExecAsync<T>(Procedimiento.TipoEncuesta.SPGETMONEDAS, null);
        }

        #endregion

    }
}
