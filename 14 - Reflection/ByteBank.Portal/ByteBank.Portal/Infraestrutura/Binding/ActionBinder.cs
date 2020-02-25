using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    // Fazer ligação entre a Url e o methodInfo
    class ActionBinder
    {
        public ActionBindInfo ObterActionBindInfo(object controller, string path)
        {
            // Exemplos de possivei urls recebidas
            // /Cambio/Calculo?moedaOrigem=BRL&moedaDestino=USD&valor=10
            // /Cambio/Calculo?moedaDestino=USD&valor=10
            // /Cambio/USD

            var partes = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var controllerNome = partes[0];
            var actionName = partes[1].Split('?')[0];

            var indiceInterrogacao = path.IndexOf("?");
            var existeQueryString = indiceInterrogacao >= 0;

            if (!existeQueryString)
            {
                var methodInfo = controller.GetType().GetMethod(actionName);
                return new ActionBindInfo(methodInfo, Enumerable.Empty<ArgumentoNomeValor>());
            }
            else
            {
                // Pegando QueriesStrings
                var queryString = path.Substring(indiceInterrogacao + 1);
                var tuplasNomeValor = ObterParametrosQueryString(queryString);
                var nomeArgumentos = tuplasNomeValor.Select(tupla => tupla.Nome).ToArray();

                // Pegando o methodInfo de acordo com os parametros
                var methodInfo = ObterMethodInfoApartirdeNomeEArgumentos(actionName, nomeArgumentos , controller);

                // Retornando metodo e parametros
                return new ActionBindInfo(methodInfo, tuplasNomeValor);
            }
        }

        private IEnumerable<ArgumentoNomeValor> ObterParametrosQueryString(string queryString)
        {
            //moedaOrigem=BRL&moedaDestino=USD&valor=10
            var tuplasNomeValor = queryString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var tupla in tuplasNomeValor)
            {
                //moedaOrigem=BRL
                var partesTupla = tupla.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                yield return new ArgumentoNomeValor(partesTupla[0], partesTupla[1]);
            }
        }

        private MethodInfo ObterMethodInfoApartirdeNomeEArgumentos(string actionName, string[] argumentos, object controller)
        {
            // Pegando metodos do controller (Com filtro)
            var bindingFlags =
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.DeclaredOnly;
            var metodos = controller.GetType().GetMethods(bindingFlags);
            // Pegando apenas as sobrecargas de metodos respectivo da actionName
            var sobrecargas = metodos.Where(metodo => metodo.Name == actionName);

            foreach (var sobrecarga in sobrecargas)
            {
                // Pegando todos parametros do metodo
                var parametros = sobrecarga.GetParameters();
                // Verificando se tem a mesma quantidade de parametros da tuplasNomeValor
                if (parametros.Length != argumentos.Length)
                {
                    continue;
                }

                // Verificando se todos parametros contidos no metodo, contem no argumentos
                var match = parametros.All(parametro => argumentos.Contains(parametro.Name));

                if (match)
                {
                    return sobrecarga;
                }
            }
            throw new ArgumentException($"A sobrecarga do metodo {actionName} não foi encontrada");
        }
    }
}
