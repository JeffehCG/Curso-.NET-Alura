using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
            // Lembre-se - mudar Build Action do arquivo para Embedded Resource (Para que o arquivo exista no Assembly em tempo de execução) (Em propriedades)
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }

        protected string View(object modelo, [CallerMemberName]string nomeArquivo = null)
        {
            var viewBruta = View(nomeArquivo);

            var todasPropriedadesDoModelo = modelo.GetType().GetProperties();

            // Expressão regular para pegar expressões que estiverem dentro de {{}} no arquivo html
            var regex = new Regex("\\{{(.*?)\\}}");
            var viewProcessada = regex.Replace(viewBruta, (match) => 
            {
                // Pegando nome da propriedade dentro de {{}}
                var nomePropriedade = match.Groups[1].Value;
                // Pegando a propriedade referente no modelo recebido
                var propriedade = todasPropriedadesDoModelo.Single(prop => prop.Name == nomePropriedade);

                // Pegando o valor da propriedade
                var valorBruto = propriedade.GetValue(modelo);
                // Retornando o valor, para substituir o que esta dentro de {{}} pelo valor respectivo
                return valorBruto?.ToString();
            });

            return viewProcessada;
        }
    }
}
