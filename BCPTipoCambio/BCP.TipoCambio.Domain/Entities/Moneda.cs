using BCP.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCP.TipoCambio.Domain.Entities
{
    public class Moneda : Entity
    {
        [Key]
        public int ID { get; set; }
        public string COD_MONEDA { get; set; }
        public string TXT_SIMBOLO { get; set; }
    }
}
