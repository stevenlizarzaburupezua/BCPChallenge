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
using BCP.TipoCambio.Domain.Aggregates.TipoCambioAgg;
using BCP.TipoCambio.DTO.Global;
using Microsoft.Extensions.Logging;
using BCPDictionary = BCP.TipoCambio.Common.DictionaryLog;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using BCP.TipoCambio.Common.Extension;
using BCP.TipoCambio.Repository.Repositories.Helper;
using Microsoft.Extensions.Configuration;

namespace BCP.TipoCambio.Application.Implementation
{
    public class TipoCambioService : ITipoCambioService
    {
        private readonly IConfiguration _configuration;
        private readonly ITipoCambioRepository _tipoCambioRepository;
        private readonly ILogger<TipoCambioService> _logger;

        public TipoCambioService(ITipoCambioRepository tipoCambioRepository,
                                 ILogger<TipoCambioService> logger,
                                 IConfiguration configuration
                                 )
        {
            _tipoCambioRepository = tipoCambioRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IList<ConsultaMonedaDTO>> GetMonedasAsync()
        {
            return await _tipoCambioRepository.ConsultaMonedasAsync<ConsultaMonedaDTO>();
        }

        public async Task<ConsultaTipoCambioDTO> GetCalculoTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino)
        {
            var infoMonedaOrigen = await _tipoCambioRepository.ConsultaMonedaAsync(monedaOrigen);

            var infoMonedaDestino = await _tipoCambioRepository.ConsultaMonedaAsync(monedaDestino);

            var tipoCambio = await _tipoCambioRepository.ConsultaTipoCambioAsync(monedaOrigen, monedaDestino);

            return CalculoTipoCambio.CalcularTipoCambio(tipoCambio, infoMonedaOrigen.TXT_SIMBOLO, infoMonedaDestino.TXT_SIMBOLO, monto).Map<ConsultaTipoCambio, ConsultaTipoCambioDTO>();
        }

        public async Task<TransactionResponse> PostClienteAsync(FiltroRegistrarClienteRequest request)
        {
            _logger.LogInformation(string.Format(BCPDictionary.RegistroNuevoCliente, request.DocumentoIdentidad));

            TransactionResponse oTransactionResponse = new TransactionResponse();

            await _tipoCambioRepository.RegistrarClienteAsync(request.Map<RegistrarCliente>());

            _logger.LogInformation(string.Format(BCPDictionary.RegistroExitoso, request.DocumentoIdentidad));

            oTransactionResponse.Success = true;
            oTransactionResponse.Mensaje = string.Format(BCPDictionary.RegistroExitoso, request.DocumentoIdentidad);

            return oTransactionResponse;
        }

        public async Task<IList<IngresoWebDTO>> PostValidarIngresoWebAsync(FiltroValidarIngresoWebRequest request)
        {
            var lstCliente = await _tipoCambioRepository.ValidarDatosIngresoWebAsync<IngresoWebDTO>(request.Map<ValidarIngresoApp>());

            if (lstCliente.HasItems())
                lstCliente[Numeracion.Cero].Token = GenerarToken(lstCliente.FirstOrDefault());

            return lstCliente;
        }

        private string GenerarToken(IngresoWebDTO datosCliente)
        {
            byte[] semillaByte = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SemillaJWT"));
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillaByte);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var clienteclaims = new[]
            {
                new Claim("id", datosCliente.IdCliente.ToString()),
                new Claim("idIngresoWeb", datosCliente.IdIngreso),
            };

            JwtSecurityToken generador = new JwtSecurityToken(

                claims: clienteclaims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials,
                issuer: "BCP.com",
                audience: "BCP.com"
                );

            return new JwtSecurityTokenHandler().WriteToken(generador);
        }


    }
}
