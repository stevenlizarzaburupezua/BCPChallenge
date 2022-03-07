using System;
using System.Threading.Tasks;
using BCP.TipoCambio.Application.Interface;
using BCP.TipoCambio.DTO.TipoCambio.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Refit;
using BCP.TipoCambio.Common.BCP.TipoCambio;

namespace BCP.TipoCambio.WebAPI.Controllers
{
    [SwaggerTag(SwaggerCons.Tag.TipoCambio_Descripcion)]
    [Route("api/[controller]")]
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
        [HttpGet(SwaggerCons.Path.getTipoCambioAsync)]
        public async Task<IActionResult> GetTipoCambioAsync(decimal monto, int monedaOrigen, int monedaDestino)
        {
            return Ok(await _tipoCambioService.GetTipoCambioAsync(monto,monedaOrigen,monedaDestino));
        }

    }
}
