using BCP.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCP.TipoCambio.Domain.Entities
{
    public class Persona : Entity
    {
        [Key]
        public int ID  { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string APELLIDO_COMPLETO { get; set; }
        public string GENERO { get; set; }
        public string DOCUMENTO_IDENTIDAD { get; set; }
    }
}
