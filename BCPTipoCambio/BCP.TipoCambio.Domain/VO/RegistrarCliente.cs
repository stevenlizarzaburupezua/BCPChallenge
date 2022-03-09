using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.TipoCambio.Domain.VO
{
    public class RegistrarCliente
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string DocumentoIdentidad { get; set; }
    }
}
