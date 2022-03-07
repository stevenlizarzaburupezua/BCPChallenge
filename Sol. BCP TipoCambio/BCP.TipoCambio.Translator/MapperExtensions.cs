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

                #region ENCUESTA ENT => DTO

                cfg.CreateMap<ConsultaTipoCambio, ConsultaTipoCambioDTO>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

                #endregion

                #region ENCUESTA DTO => ENT



                #endregion

                #region ENCUESTA DTO => DTO



                #endregion

            });
            config.CompileMappings();
            return config.CreateMapper();
        }
    }
}
