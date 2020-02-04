using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    // Antes de qualquer ActionResult ser executada, sera feita a validação de login (AutorizacaoFilterAttribute) "Classe criada em Filtros/AutorizacaoFilterAttribute"
    // Caso nem todas Actions precisem de autenticação, atribuir a annotation abaixo apenas para as desejadas 
    // Caso todas controlles necessitem dessa autenticação, criar a classe FilterConfig() em App_Start, lá seram definidos todos filtros globais
    [AutorizacaoFilterAttribute]
    public class ProdutoController : Controller
    {
        // Definindo url customizada navegação
        // Para que essa URL personalizada seja definida, é preciso adiconar routes.MapMvcAttributeRoutes(); no arquivo, App_Start/RouteConfig.cs
        [Route("produtos", Name ="ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();

            //ViewBag.Produtos = produtos;
            //return View();

            // Ou

            return View(produtos);
        }

        // Anotação para fazer a validação do AntiForgeryToken() gerado pelo formulario
        // Caso não seja valido recusa a requisição
        [ValidateAntiForgeryToken]
        public ActionResult Form()
        {
            // Listando categorias para o dropdown do formulario
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();
            return View();
        }

        //public ActionResult Adiciona(string nome, float preco, string descricao, int quantidade, int categoriaId)
        //{
        //    Produto produto = new Produto()
        //    {
        //        Nome = nome,
        //        Preco = preco,
        //        Descricao = descricao,
        //        Quantidade = quantidade,
        //        CategoriaId = categoriaId
        //    };

        //    ProdutosDAO dao = new ProdutosDAO();
        //    dao.Adiciona(produto);
        //    return View();
        //}

        //Ou


        // Esse metodo só ira receber requisições do tipo POST
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            // Validação personalizada
            // Produtos da categoria 1 devem valer mais de 100 reias
            if (produto.CategoriaId.Equals(1) && produto.Preco < 100)
            {
                // Adicionando novo erro
                ModelState.AddModelError("produto.Invalido", "Informatica com preço abaixo de 100 reais!");
            }
            // ModelState.IsValid - verifica se o modelo obedece as regras de validação
            // Nesse caso, as regras de validação contidas na classe Produto
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);

                // Redirecionando para o metodo Index, Controller Produto
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                // Caso de erro de validação retornar formulario com dados digitados
                ViewBag.Produto = produto;
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                return View("Form");
            }
        }

        // Descrição produto
        // Definindo url com atributo
        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int Id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(Id);
            ViewBag.Produto = produto;
            return View();
        }

        // Utilizando requisições AJAX(Assincronas) para recarregar apenas uma parte da paginas
        public ActionResult DecrementaQuantidade(int Id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(Id);
            produto.Quantidade--;
            dao.Atualiza(produto);

            // Enviando o produto atualizado para View(Para o metodo javascript atualizar())
            return Json(produto);
        }
    }
}