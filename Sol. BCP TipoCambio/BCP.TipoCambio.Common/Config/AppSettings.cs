using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.TipoCambio.Common.Config
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
