using ByteBank.Portal.Controller;
using ByteBank.Portal.Infraestrutura.IoC;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        // Portas que o HttpListener ficara escutando
        private readonly string[] _prefixos;
        // Container de injeção de dependencia
        private readonly IContainer _container = new ContainerSimples();
        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
            {
                throw new ArgumentNullException(nameof(prefixos));
            }
            _prefixos = prefixos;

            Configurar();
        }

        // Configurando a injeção de dependencias
        private void Configurar()
        {
            // Um metodo com duas sobreecargas diferentes (Para entender melhor verifique a classe ContainerSimples)

            _container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            // Meneira de Registrar mais performatica
            _container.Registrar<ICartaoService, CartaoTesteService>();
        }

        public void Iniciar()
        {
            while (true) ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            // Escutando requisições http
            var httpListener = new HttpListener();
            foreach (var prefixo in _prefixos)
            {
                // Adicionando caminhos que seram escutados
                httpListener.Prefixes.Add(prefixo);
            }
            httpListener.Start();

            // Pegando o contexto, e esperando a resposta 
            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            // Pegando a Url da requisição
            //var path = requisicao.Url.AbsolutePath;
            var path = requisicao.Url.PathAndQuery;

            #region Retornando arquivo statico
            if (Utilidades.VerificarChamadaDeArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            #endregion

            #region Trabalhando com Controllers
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }
            #endregion

            httpListener.Stop();

        }
    }
}
