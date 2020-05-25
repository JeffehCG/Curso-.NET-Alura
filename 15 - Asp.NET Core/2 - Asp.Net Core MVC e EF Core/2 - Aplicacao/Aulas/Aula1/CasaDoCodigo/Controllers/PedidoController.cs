using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using CasaDoCodigo.Models.Interface.Services;
using CasaDoCodigo.Models.Response;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        #region Acessando configurações de appsettings.json em uma controller

        private IConfiguration _configuration;

        public void ExemploAcessoConfiguracao()
        {
            // Configuração usando a string de chave
            ViewData["SecurityLanguage"] = _configuration["Security:Language"];

            // Configuração usando método GetSection

            ViewData["SecuritySuperUserLogin"] =
            _configuration.GetSection("Security").GetSection("SuperUser").GetSection("Login");

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserEmail"] =
                _configuration.GetSection("Security")["SuperUser:Email"];

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserShowEmail"] =
                _configuration.GetSection("Security")["SuperUser:ShowEmail"];

        }

        #endregion

        private readonly IPedidoDb _pedidoDb;

        public PedidoController(IConfiguration configuration, IPedidoDb pedidoDb)
        {
            _pedidoDb = pedidoDb;
        }

        public IActionResult Carrossel()
        {
            return View(_pedidoDb.ListarProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            var pedido = _pedidoDb.AdicionarItemPedido(codigo);

            CarrinhoViewModel carrinho = new CarrinhoViewModel(pedido.Itens);

            return View(carrinho);
        }

        public IActionResult Cadastro()
        {
            var pedido = _pedidoDb.GetDadosPedido();

            if(pedido == null)
                return RedirectToAction("Carrossel");

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                var pedido = _pedidoDb.AtualizarCadastro(cadastro);
                return View(pedido);
            }

            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            var response = _pedidoDb.AtualizarQuantidadeItemPedido(itemPedido);
            return response;    
        }
    }
}
