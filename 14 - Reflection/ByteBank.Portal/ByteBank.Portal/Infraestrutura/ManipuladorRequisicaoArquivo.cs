using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ManipuladorRequisicaoArquivo
    {
        public void Manipular(HttpListenerResponse resposta, string path)
        {
            #region Pegando arquivo de resposta
            // Para que o arquivo seja pego, o mesmo (style.css) deve estar como Embedded Resource em Build Action nas propriedades
            var assembly = Assembly.GetExecutingAssembly();
            var nomeResource = Utilidades.ConverterPathParaNomeAssembly(path);
            // Acessando arquivo pelo assembly
            var resourceStream = assembly.GetManifestResourceStream(nomeResource);
            #endregion

            #region Retornando arquivo de resposta
            // Se o arquivo não foi encontrado, retornar 404
            if (resourceStream == null)
            {
                resposta.StatusCode = 404;
                resposta.OutputStream.Close();
            }
            else
            {
                using (resourceStream)
                {
                    // Salvando arquivos em um Array de bytes (byteResource)
                    var byteResource = new byte[resourceStream.Length];
                    resourceStream.Read(byteResource, 0, (int)resourceStream.Length);

                    // Definindo o tipo da resposta (css, html ou js)
                    resposta.ContentType = Utilidades.ObterTipoDeConteudo(path);
                    // Definindo o status da requisição
                    resposta.StatusCode = 200;
                    // Tamanho da resposta
                    resposta.ContentLength64 = resourceStream.Length;

                    // Retornando resposta (Array de bytes, indice inicio da leitura, e indice final da leitura)
                    resposta.OutputStream.Write(byteResource, 0, byteResource.Length);

                    // Fechando requisição
                    resposta.OutputStream.Close();
                }
            }
            #endregion
        }
    }
}
