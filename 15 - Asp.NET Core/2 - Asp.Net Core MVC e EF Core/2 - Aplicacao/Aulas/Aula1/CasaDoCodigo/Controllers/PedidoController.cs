using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using CasaDoCodigo.Models.Interface.Services;
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

        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ISessionService _sessionService;

        public PedidoController(IConfiguration configuration, ISessionService sessionService, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _configuration = configuration;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _sessionService = sessionService;
        }

        public IActionResult Carrossel()
        {
            return View(_produtoRepository.GetAll());
        }

        public IActionResult Carrinho(string codigo)
        {
            var idPedido = _sessionService.GetPedidoId();
            var pedido = _pedidoRepository.GetByParameter( p => p.Id == idPedido);

            if(pedido == null)
            {
                pedido = new Pedido();
                _pedidoRepository.Save(pedido);
                _sessionService.SetPedidoId(pedido.Id);
            }

            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo, pedido.Id);
                pedido = _pedidoRepository.GetByParameter(p => p.Id == pedido.Id);
            }

            return View(pedido.Itens);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            var idPedido = _sessionService.GetPedidoId();
            var pedido = _pedidoRepository.GetByParameter(p => p.Id == idPedido);
            return View(pedido);
        }
    }
}
