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
        [Display(Order = 1)]
        [JsonProperty("monto")]
        public decimal Monto { get; set; }
        [Display(Order = 2)]
        [JsonProperty("montoTipoCambio")]
        public decimal MontoTipoCambio { get; set; }
        [Display(Order = 3)]
        [JsonProperty("monedaOrigen")]
        public string MonedaOrigen { get; set; }
        [Display(Order = 4)]
        [JsonProperty("monedaDestino")]
        public string MonedaDestino { get; set; }
        [Display(Order = 5)]
        [JsonProperty("tipoCambio")]
        public decimal TipoCambio { get; set; }


    }
}
