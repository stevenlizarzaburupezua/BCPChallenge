using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BCP.Domain.Seedwork;

namespace BCP.TipoCambio.DTO.TipoCambio.Response
{
    public class CambioMontoDTO
    {
        [JsonProperty("monto")]
        public decimal Monto { get; set; }
        [JsonProperty("montoTipoCambio")]
        public decimal MontoTipoCambio { get; set; }
        [JsonProperty("monedaOrigen")]
        public int MonedaOrigen { get; set; }
        [JsonProperty("monedaDestino")]
        public int MonedaDestino { get; set; }
        [JsonProperty("tipoCambio")]
        public decimal TipoCambio { get; set; }
    }
}
