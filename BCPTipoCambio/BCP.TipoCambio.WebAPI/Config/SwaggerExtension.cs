using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BCP.TipoCambio.WebAPI.Config
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    // Filter out 3rd party controllers
                    var assemblyName = ((ControllerActionDescriptor)apiDesc.ActionDescriptor).ControllerTypeInfo.Assembly.GetName().Name;
                    var currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                    return currentAssemblyName == assemblyName;
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API TIPO CAMBIO", Version = "v1", Description = "APIS utilizados en el sistema de Tipo Cambio - BCP   " });
                c.IncludeXmlComments(Path.Combine(@"Infrastructure\Swagger\XML", $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"));
                c.IncludeXmlComments(Path.Combine(@"Infrastructure\Swagger\XML", "TipoCambio.DTO.XML"));
                c.EnableAnnotations();
            });

            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint("v1/swagger.json", "Tipo Cambio v1");
            });

            return app;
        }
    }
}
