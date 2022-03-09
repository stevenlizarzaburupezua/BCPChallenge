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
    [SwaggerTag(SwaggerCons.Tag.Seguridad_Descripcion)]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : Controller
    {
        private readonly ITipoCambioService _tipoCambioService;
        public SeguridadController(ITipoCambioService tipoCambioService)
        {
            _tipoCambioService = tipoCambioService;
        }

        [SwaggerOperation(
        Summary = SwaggerCons.Summary.postValidarIngresoWebAsync,
        OperationId = SwaggerCons.OperationId.postValidarIngresoWebAsync)]
        [SwaggerResponse(SwaggerCons.OK, SwaggerCons.ResponseMessages_200.postValidarIngresoWeb)]
        [SwaggerResponse(SwaggerCons.INTERNAL_SERVER_ERROR, SwaggerCons.ResponseMessages_500.defaultMessage_500)]
        [HttpPost(SwaggerCons.Path.postValidarIngresoWebAsync)]
        public async Task<IActionResult> PostValidarIngresoWebAsync([Body] FiltroValidarIngresoWebRequest request)
        {
            return Ok(await _tipoCambioService.PostValidarIngresoWebAsync(request));
        }
    }
}
