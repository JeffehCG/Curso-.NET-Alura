using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models.Filtros;
using Alura.WebAPI.Api.Models.Paginacao;
using Alura.WebAPI.Api.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alura.ListaLeitura.Api.Controllers.v2
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")] // Definindo versão
    [ApiExplorerSettings(GroupName = "v2")] //Verção Documentação
    [Route("api/v{version:apiVersion}/[controller]")] // Definindo estrutura de rota ({version:apiVersion} tratando versão)
    public class LivrosController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public LivrosController(IRepository<Livro> repo)
        {
            _repo = repo;
        }

        //http://localhost:64466/Livros
        [HttpGet]
        // Anotações para o Swagger
        [SwaggerOperation(
            Summary = "Lista todos livros da base com paginação." ,
            Tags = new[] { "Livros" }, // Tag de agrupamentos das actions
            Produces = new[] { "application/json", "application/xml" })] // Tipos de retorno
        [ProducesResponseType(statusCode: 200, Type = typeof(LivrosPaginado))] // Tipo retorno caso sucesso (Definido para o swagger)
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))] // Tipo retorno caso Erro (Definido para o swagger)
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Listar(
            [FromQuery] [SwaggerParameter("Filtro de pesquisa para livros.")] LivroFiltro filtro,  // ex: livros?titulo=Teste&lista=lendo
            [FromQuery] [SwaggerParameter("Ordenação por parametro definido.")] LivroOrdem ordem,  // ex: livros?ordenarpor=titulo
            [FromQuery] [SwaggerParameter("Dados da paginação.")] Paginacao paginacao)             // ex: livros?pagina=3&tamanho=5
        {
            var livroPaginado = _repo.All
                .AplicaOrdem(ordem)
                .AplicaFiltro(filtro)
                .Select(l => l.ToApi())
                .ToLivrosPaginado(paginacao);

            if (livroPaginado == null)
            {
                return NotFound();
            }

            return Ok(livroPaginado);
        }

        //http://localhost:64466/Livros/1
        [HttpGet("{id}")] // Definindo que a rota get recebera um id
        [SwaggerOperation(Summary = "Lista um livro pelo id.", Tags = new[] { "Livros" }, Produces = new[] { "application/json", "application/xml" })]
        [ProducesResponseType(statusCode: 200, Type = typeof(LivroApi))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Recuperar([SwaggerParameter("Id do livro a ser obtido.")] int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToApi());
        }

        [HttpGet("{id}/capa")]
        [SwaggerOperation(Summary = "Lista a capa de um livro pelo id.", Tags = new[] { "Livros" }, Produces = new[] { "application/json", "application/xml" })]
        [ProducesResponseType(statusCode: 200, Type = typeof(byte[]))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        public IActionResult ImagemCapa([SwaggerParameter("Id do livro a ser recuperado a capa.")] int id)
        {
            byte[] img = _repo.All
                .Where(l => l.Id == id)
                .Select(l => l.ImagemCapa)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Inclui um novo livro na base.", Tags = new[] { "Livros" }, Produces = new[] { "application/json", "application/xml" })]
        [ProducesResponseType(statusCode: 201, Type = typeof(LivroApi))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 400, Type = typeof(ErrorResponse))]
        public IActionResult Incluir([FromForm] [SwaggerParameter("Livro a ser incluido.")] LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();

                _repo.Incluir(livro);
         
                var uri = Url.Action("Recuperar", new { id = livro.Id });
                return Created(uri, livro.ToApi()); // 201
            }

            return BadRequest(ErrorResponse.FromModelState(ModelState)); // 400
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Altera um livro da base.", Tags = new[] { "Livros" })]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 400, Type = typeof(ErrorResponse))]
        public IActionResult Alterar([FromForm] [SwaggerParameter("Livro a ser alterado.")] LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                if (model.Capa == null)
                {
                    livro.ImagemCapa = _repo.All
                        .Where(l => l.Id == livro.Id)
                        .Select(l => l.ImagemCapa)
                        .FirstOrDefault();
                }
                _repo.Alterar(livro);
                return Ok(); // 200
            }
            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um livro da base." , Tags = new[] { "Livros" })]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Remover([SwaggerParameter("Id do livro a ser removido.")] int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return NoContent(); // 204
        }
    }
}