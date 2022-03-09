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

        public async Task<TipooCambio> ConsultaTipoCambioAsync(int monedaOrigen, int monedaDestino)
        {
            return await base.All<TipooCambio>()
                .AsNoTracking()
                .Where(a => a.ID_MONEDA_ORIGEN == monedaOrigen && a.ID_MONEDA_DESTINO == monedaDestino)
                .FirstOrDefaultAsync() ?? new TipooCambio();
        }

        public async Task<Moneda> ConsultaMonedaAsync(int codMoneda)
        {
            return await base.All<Moneda>().FirstOrDefaultAsync(f => f.ID == codMoneda) ?? new Moneda();
        }

        #endregion

        #region ADO.NET

        public async Task<IList<T>> ConsultaMonedasAsync<T>() where T : RawDTO
        {
            return await _storeProcedureManager.ExecAsync<T>(Procedimiento.TipoEncuesta.USP_GETMONEDAS, null);
        }

        public async Task RegistrarClienteAsync(RegistrarCliente filtro)
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_PRIMER_NOMBRE", filtro.PrimerNombre },
                { "P_SEGUNDO_NOMBRE", filtro.SegundoNombre },
                { "P_PRIMER_APELLIDO", filtro.PrimerApellido },
                { "P_SEGUNDO_APELLIDO", filtro.SegundoApellido },
                { "P_GENERO", filtro.Genero },
                { "P_DOCUMENTO_IDENTIDAD ", filtro.DocumentoIdentidad },
            };

            await _storeProcedureManager.ExecAsync(Procedimiento.TipoEncuesta.USP_REGISTRAR_PERSONA_WEB, parameters);
        }

        public async Task<IList<T>> ValidarDatosIngresoWebAsync<T>(ValidarIngresoApp filtro) where T : RawDTO
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_IDINGRESO", filtro.IdIngreso},
                { "P_CONTRASENIA", filtro.Contrasenia},
            };

            return await _storeProcedureManager.ExecAsync<T>(Procedimiento.TipoEncuesta.USP_ACCESO_WEB, parameters);

            #endregion

        }
    }
}