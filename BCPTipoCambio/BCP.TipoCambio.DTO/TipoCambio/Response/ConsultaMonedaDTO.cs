using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BCP.Domain.Seedwork;

namespace BCP.TipoCambio.DTO.TipoCambio.Response
{
    public class ConsultaMonedaDTO : RawDTO
    {
        [Display(Order = 0)]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Display(Order = 1)]
        [JsonProperty("codMoneda")]
        public string CodMoneda { get; set; }
        [Display(Order = 2)]
        [JsonProperty("txtSimbolo")]
        public string TxtSimbolo { get; set; }
    }
}
