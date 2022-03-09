using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BCP.Domain.Seedwork;

namespace BCP.TipoCambio.DTO.TipoCambio.Response
{
    public class IngresoWebDTO  : RawDTO    
    {
        [Display(Order = 0)]
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [Display(Order = 1)]
        [JsonProperty("idIngreso")]
        public string IdIngreso { get; set; }
        [Display(Order = 2)]
        [JsonProperty("primerNombre")]
        public string PrimerNombre { get; set; }
        [Display(Order = 3)]
        [JsonProperty("primerApellido")]
        public string PrimerApellido { get; set; }
        public byte[] Foto { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
