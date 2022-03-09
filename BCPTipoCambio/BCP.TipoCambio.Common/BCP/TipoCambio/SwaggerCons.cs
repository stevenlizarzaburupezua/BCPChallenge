using System;
using System.Collections.Generic;
using System.Text;

namespace BCP.TipoCambio.Common.BCP.TipoCambio
{
    public class SwaggerCons
    {
        public const int OK = 200;
        public const int INTERNAL_SERVER_ERROR = 500;
        public const int UNAUTHORIZED = 401;

        public struct Tag
        {
            public const string TipoCambio_Descripcion = "API que devuelve y procesa datos relacionados al tipo de cambio";
            public const string Seguridad_Descripcion = "API que valida los datos del usuario y devuelve un Token";
        }

        public struct ResponseMessages_500
        {
            public const string defaultMessage_500 = "Error interno en el servidor";
        }

        public struct ResponseMessages_401
        {
            public const string defaultMessage_401 = "Carece de credenciales válidas de autenticación para el recurso solicitado";
        }


        public struct ResponseMessages_200
        {
            public const string getMonedasAsync = "Monedas";
            public const string getTipoCambioAsync = "Tipo Cambio";
            public const string postCliente = "Cliente Registrado";
            public const string postValidarIngresoWeb = "Datos Del Cliente Cliente";
        }

        public struct Path
        {
            public const string getMonedasAsync = "monedasAsync";
            public const string getTipoCambioAsync = "tipoCambioAsync";
            public const string postClienteAsync = "registrarClienteAsync";
            public const string postValidarIngresoWebAsync = "validarIngresoWebAsync";
        }

        public struct Summary
        {
            public const string getMonedasAsync = "Servicio que obtiene la información de las monedas";
            public const string getTipoCambioAsync = "Servicio que obtiene el cambio de un monto";
            public const string postClienteAsync = "Servicio que Registra un nuevo Cliente";
            public const string postValidarIngresoWebAsync = "Servicio que valida el login del cliente";
        }

        public struct OperationId
        {
            public const string getMonedasAsync = "GetMonedasAsync";
            public const string getTipoCambioAsync = "GetTipoCambioAsync";
            public const string postClienteAsync = "PostClienteAsync";
            public const string postValidarIngresoWebAsync = "PostValidarIngresoAsync";
        }


    }
}
