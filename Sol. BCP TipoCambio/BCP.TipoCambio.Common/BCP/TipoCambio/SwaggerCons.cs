using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.TipoCambio.Common.BCP.TipoCambio
{
    public class SwaggerCons
    {
        public const int OK = 200;
        public const int INTERNAL_SERVER_ERROR = 500;

        public struct Tag
        {
            public const string TipoCambio_Descripcion = "API que devuelve y procesa datos relacionados al tipo de cambio";
        }

        public struct ResponseMessages_500
        {
            public const string defaultMessage_500 = "Error interno en el servidor";
        }


        public struct ResponseMessages_200
        {
            public const string getMonedasAsync = "Monedas";
            public const string getTipoCambioAsync = "Tipo Cambio";
        }

        public struct Path
        {
            public const string getMonedasAsync = "monedasAsync";
            public const string getTipoCambioAsync = "tipoCambioAsync";
        }

        public struct Summary
        {
            public const string getMonedasAsync = "Servicio que obtiene la información de las monedas";
            public const string getTipoCambioAsync = "Servicio que obtiene el cambio de un monto";
        }

        public struct OperationId
        {
            public const string getMonedasAsync = "GetMonedasAsync";
            public const string getTipoCambioAsync = "GetTipoCambioAsync";
        }


    }
}
