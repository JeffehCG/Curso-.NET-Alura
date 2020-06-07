using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Modelos.Filtros;
using Alura.ListaLeitura.Modelos.Paginacao;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Model.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.Api.Controllers.v2
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")] // Definindo versão
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
        public IActionResult Listar(
            [FromQuery] LivroFiltro filtro,  // ex: livros?titulo=Teste&lista=lendo
            [FromQuery] LivroOrdem ordem,    // ex: livros?ordenarpor=titulo
            [FromQuery] Paginacao paginacao) // ex: livros?pagina=3&tamanho=5
        {
            var livroPaginado = _repo.All
                .AplicaOrdem(ordem)
                .AplicaFiltro(filtro)
                .Select(l => l.ToApi())
                .ToLivrosPaginado(paginacao);

            return Ok(livroPaginado);
        }

        //http://localhost:64466/Livros/1
        [HttpGet("{id}")] // Definindo que a rota get recebera um id
        public IActionResult Recuperar(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToApi());
        }

        [HttpGet("{id}/capa")]
        public IActionResult ImagemCapa(int id)
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
        public IActionResult Incluir([FromForm]LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                _repo.Incluir(livro);
                var uri = Url.Action("Recuperar", new { id = livro.Id });
                return Created(uri, livro); // 201
            }

            return BadRequest(); // 400
        }

        [HttpPut]
        public IActionResult Alterar([FromForm]LivroUpload model)
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
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
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