using ByteBank.Portal.Infraestrutura.Binding;
using ByteBank.Portal.Infraestrutura.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        // Propriedade utilizada para fazer a ligação entre a url e o methodInfo (pegar o metodo a ser executado de acordo com a url)
        private readonly ActionBinder _actionBinder = new ActionBinder();
        private readonly FilterResolver _filterResolver = new FilterResolver();
        public void Manipular(HttpListenerResponse resposta, string path)
        {
            // Pegando o nome da controller
            var controllerNome = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0];

            var controllerNomeCompleto = $"ByteBank.Portal.Controller.{controllerNome}Controller";

            // Criando uma instancia do Controller recebido na requisição
            // Activator.CreateInstance - recebe (Nome do Assembly, no caso do projeto, nome completo do controller, e os parametros passados para o controller, nesse caso vazio)
            var controllerWrapper = Activator.CreateInstance("ByteBank.Portal", controllerNomeCompleto, new object[0]);
            var controller = controllerWrapper.Unwrap();

            // Pegando metodo a ser executado (MethodInfo)
            var actionBindInfo = _actionBinder.ObterActionBindInfo(controller, path);

            // Verificando filtro, e identificando se o metodo podera ser executado
            var filterResult = _filterResolver.VerificarFiltros(actionBindInfo);
            if (filterResult.PodeContinuar)
            {
                // Executando metodo
                var resultadoAction = (string)actionBindInfo.Invoke(controller);

                // Retornando resultado (pagina)
                var bufferArquivo = Encoding.UTF8.GetBytes(resultadoAction);

                resposta.ContentType = "text/html; charset=utf-8";
                resposta.StatusCode = 200;
                resposta.ContentLength64 = bufferArquivo.Length;

                resposta.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);
                resposta.OutputStream.Close();
            }
            else
            {
                // Retorna codigo de erro temporario
                resposta.StatusCode = 307;
                // Redirecionado para pagina de erro
                resposta.RedirectLocation = "/Erro/Inesperado";
                resposta.OutputStream.Close();
            }

        }
    }
}
