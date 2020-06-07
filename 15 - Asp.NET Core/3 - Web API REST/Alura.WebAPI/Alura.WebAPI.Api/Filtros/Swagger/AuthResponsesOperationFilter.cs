using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Filtros.Swagger
{
    // Classe para implementar Descritivo descritivo em todas actions do swagger, Globalmente
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Responses.Add(
            "401",
            new Response { Description = "Unauthorized" });
        }
    }
}
