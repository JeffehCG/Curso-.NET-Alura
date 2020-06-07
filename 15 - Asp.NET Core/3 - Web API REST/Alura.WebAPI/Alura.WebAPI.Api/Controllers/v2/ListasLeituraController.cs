using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.Api.Controllers.v2
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2")] //Verção Documentação
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ListasLeituraController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLeituraController(IRepository<Livro> repo)
        {
            _repo = repo;
        }

        private Lista CriaLista(TipoListaLeitura tipo)
        {
            return new Lista
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All
                .Where(l => l.Lista == tipo)
                .Select(l => l.ToApi())
                .ToList()
            };
        }

        [HttpGet]
        // Anotações para o swagger
        [SwaggerOperation(
            Summary = "Retorna todas as listas e seus repectivos livros.", 
            Tags = new[] { "ListasLeitura" }, // Tag de agrupamentos das actions
            Produces = new[] { "application/json", "application/xml" })] // Tipos de retorno
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Lista>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        public IActionResult Listar()
        {
            Lista paraLer = CriaLista(TipoListaLeitura.ParaLer);
            Lista lendo = CriaLista(TipoListaLeitura.Lendo);
            Lista lidos = CriaLista(TipoListaLeitura.Lidos);

            var colecao = new List<Lista> { paraLer, lendo, lidos };
            return Ok(colecao);
        }

        [HttpGet("{tipo}")]
        [SwaggerOperation(Summary = "Retorna uma lista e seus respectivos livros", Tags = new[] { "ListasLeitura" }, Produces = new[] { "application/json", "application/xml" })]
        [ProducesResponseType(statusCode: 200, Type = typeof(Lista))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Recupera([SwaggerParameter("Tipo da lista a ser obtida.")] TipoListaLeitura tipo)
        {
            var lista = CriaLista(tipo);

            if(lista == null)
            {
                return NotFound();
            }

            return Ok(lista);
        }
    }
}