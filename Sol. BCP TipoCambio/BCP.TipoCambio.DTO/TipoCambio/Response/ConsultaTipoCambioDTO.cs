using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BCP.Domain.Seedwork;

namespace BCP.TipoCambio.DTO.TipoCambio.Response
{
    public class ConsultaTipoCambioDTO : RawDTO
    {
        [JsonProperty("monto")]
        public decimal Monto { get; set; }
        [JsonProperty("montoTipoCambio")]
        public decimal MontoTipoCambio { get; set; }
        [JsonProperty("monedaOrigen")]
        public string MonedaOrigen { get; set; }
        [JsonProperty("monedaDestino")]
        public string MonedaDestino { get; set; }
        [JsonProperty("tipoCambio")]
        public decimal TipoCambio { get; set; }


    }
}
