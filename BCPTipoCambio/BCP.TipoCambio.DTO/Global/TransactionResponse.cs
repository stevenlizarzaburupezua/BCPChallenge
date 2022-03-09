using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace BCP.TipoCambio.DTO.Global
{
    public class TransactionResponse
    {
        [SwaggerSchema("Flag que indica que la transacción es correcta.")]
        public bool Success { get; set; }

        [SwaggerSchema("Mensaje de validación o error.")]
        public string Mensaje { get; set; }
    }
}
