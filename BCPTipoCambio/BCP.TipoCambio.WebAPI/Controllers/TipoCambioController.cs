using System;
using System.Threading.Tasks;
using BCP.TipoCambio.Application.Interface;
using BCP.TipoCambio.DTO.TipoCambio.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using BCP.TipoCambio.Common.BCP.TipoCambio;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BCP.TipoCambio.WebAPI.Controllers
{
    [SwaggerTag(SwaggerCons.Tag.TipoCambio_Descripcion)]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes  = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TipoCambioController : Controller
    {
        private readonly ITipoCambioService _tipoCambioService;
        public TipoCambioController(ITipoCambioService tipoCambioService)
        {
            _tipoCambioService = tipoCambioService;
        }

        [SwaggerOperation(
        Summary = SwaggerCons.Summary.getMonedasAsync,
        OperationId = SwaggerCons.OperationId.getMonedasAsync)]
        [SwaggerResponse(SwaggerCons.OK, SwaggerCons.ResponseMessages_200.getMonedasAsync)]
        [SwaggerResponse(SwaggerCons.INTERNAL_SERVER_ERROR, SwaggerCons.ResponseMessages_500.defaultMessage_500)]
        [SwaggerResponse(SwaggerCons.UNAUTHORIZED, SwaggerCons.ResponseMessages_401.defaultMessage_401)]
        [HttpGet(SwaggerCons.Path.getMonedasAsync)]
        public async Task<IActionResult> GetMonedasAsync()
        {
            return Ok(await _tipoCambioService.GetMonedasAsync());
        }

        [SwaggerOperation(
        Summary = SwaggerCons.Summary.getTipoCambioAsync,
        OperationId = SwaggerCons.OperationId.getTipoCambioAsync)]
        [SwaggerResponse(SwaggerCons.OK, SwaggerCons.ResponseMessages_200.getTipoCambioAsync)]
        [SwaggerResponse(SwaggerCons.INTERNAL_SERVER_ERROR, SwaggerCons.ResponseMessages_500.defaultMessage_500)]
        [SwaggerResponse(SwaggerCons.UNAUTHORIZED, SwaggerCons.ResponseMessages_401.defaultMessage_401)]
        [HttpGet(SwaggerCons.Path.getTipoCambioAsync)]
        public async Task<IActionResult> GetCalculoTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino)
        {
            return Ok(await _tipoCambioService.GetCalculoTipoCambioAsync(monto,monedaOrigen,monedaDestino));
        }

        [SwaggerOperation(
        Summary = SwaggerCons.Summary.postClienteAsync,
        OperationId = SwaggerCons.OperationId.postClienteAsync)]
        [SwaggerResponse(SwaggerCons.OK, SwaggerCons.ResponseMessages_200.postCliente)]
        [SwaggerResponse(SwaggerCons.INTERNAL_SERVER_ERROR, SwaggerCons.ResponseMessages_500.defaultMessage_500)]
        [SwaggerResponse(SwaggerCons.UNAUTHORIZED, SwaggerCons.ResponseMessages_401.defaultMessage_401)]
        [HttpPost(SwaggerCons.Path.postClienteAsync)]
        public async Task<IActionResult> PostClienteAsync([Refit.Body] FiltroRegistrarClienteRequest request)
        {
            return Ok(await _tipoCambioService.PostClienteAsync(request));
        }

    }
}
