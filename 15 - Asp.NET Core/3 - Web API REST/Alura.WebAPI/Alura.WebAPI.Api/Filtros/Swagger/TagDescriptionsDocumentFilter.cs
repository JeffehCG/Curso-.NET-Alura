using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Filtros.Swagger
{
    // Adicionando descrição das Tags
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[] {
            new Tag { Name = "Livros", Description = "Consulta e mantém os livros." },
            new Tag { Name = "ListasLeitura", Description = "Consulta as listas de leitura." }
            };
        }
    }
}
