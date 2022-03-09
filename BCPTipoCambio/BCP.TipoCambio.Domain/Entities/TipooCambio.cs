using BCP.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCP.TipoCambio.Domain.Entities
{
    public class TipooCambio : Entity
    {
        [Key]
        public int ID { get; set; }
        public int ID_MONEDA_ORIGEN { get; set; }
        public int ID_MONEDA_DESTINO { get; set; }
        public decimal IMP_COMPRA { get; set; }
        public decimal IMP_VENTA { get; set; }
    }
}
