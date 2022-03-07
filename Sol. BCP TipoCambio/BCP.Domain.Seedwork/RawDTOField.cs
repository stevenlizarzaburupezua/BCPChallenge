using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.Domain.Seedwork
{
    public class RawDTOField
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public RawDTOField(string Name, object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

    }
}
