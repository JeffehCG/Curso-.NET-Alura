using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public abstract class ControllerBase
    {
        // CallerMemberName - Pega o nome do metodo que fez a chamada desse metodo
        // Metodo que pega a View da Controller
        protected string View([CallerMemberName]string nomeArquivo = null)
        {
            // Pegando o nome da classe filha que esta herdando a ControllerBase
            var type = GetType();
            var diretorioNome = type.Name.Replace("Controller", "");

            // Pegando o arquivo html da controller
            var nomeCompletoResource = $"ByteBank.Portal.View.{diretorioNome}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);

            // Lendo arquivo
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }
    }
}
