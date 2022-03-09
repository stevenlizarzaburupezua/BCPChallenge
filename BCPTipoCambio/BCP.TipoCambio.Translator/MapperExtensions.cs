using BCP.TipoCambio.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using BCP.TipoCambio.Domain.VO;
using BCP.TipoCambio.DTO.TipoCambio.Response;
using BCP.TipoCambio.DTO.TipoCambio.Request;

namespace BCP.TipoCambio.Translator
{
    public static class MapperExtensions
    {
        private static readonly IMapper _mapper = Register();

        #region MapperExtensions
        public static T Map<T>(this object instance) => _mapper.Map<T>(instance);

        public static List<T2> Map<T1, T2>(this IEnumerable<T1> lista) => lista.Select(f => f.Map<T2>()).ToList();

        public static T2 Map<T1, T2>(this object instance) => instance.Map<T2>();

        #endregion

        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {

                #region TIPOCAMBIO ENT => DTO

                cfg.CreateMap<ConsultaTipoCambio, ConsultaTipoCambioDTO>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

                cfg.CreateMap<Moneda, ConsultaMonedaDTO>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

                cfg.CreateMap<ValidarIngresoApp, IngresoWebDTO>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

                #endregion

                #region TIPOCAMBIO DTO => ENT

                cfg.CreateMap<FiltroRegistrarClienteRequest, RegistrarCliente>().AfterMap((dto, vo) =>
                {
                    vo.PrimerNombre = dto.PrimerNombre;
                    vo.SegundoNombre = dto.SegundoNombre;
                    vo.PrimerApellido = dto.PrimerApellido;
                    vo.SegundoApellido = dto.SegundoApellido;
                    vo.Genero = dto.Genero;
                    vo.DocumentoIdentidad = dto.DocumentoIdentidad;
                });

                cfg.CreateMap<FiltroValidarIngresoWebRequest, ValidarIngresoApp>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

                #endregion

                #region TIPOCAMBIO DTO => DTO



                #endregion

            });
            config.CompileMappings();
            return config.CreateMapper();
        }
    }
}
