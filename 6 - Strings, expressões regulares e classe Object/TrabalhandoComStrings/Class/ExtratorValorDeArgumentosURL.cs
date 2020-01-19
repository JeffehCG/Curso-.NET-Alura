using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhandoComStrings.Class
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly List<string> _argumentos;
        public string URL { get; private set; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            // Se URL é nulla ou vazia dispara erro
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Argumento url não pode ser nullo ou empty",nameof(url));
            }

            URL = ValidacaoDominio(url.ToLower());
            _argumentos = GetArgumentosURL();
        }

        private List<string> GetArgumentosURL()
        {
            int indiceInterrogacao = URL.IndexOf('?');
            string argumentos = URL.Substring(indiceInterrogacao + 1);
            return argumentos.Split('&').OfType<string>().ToList();
        }

        public string GetValorParametro(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToLower();
            foreach(string argumento in _argumentos)
            {
                if(argumento.IndexOf(nomeParametro + "=") != -1)
                {
                    return argumento.Substring(nomeParametro.Length).Remove(0, 1);
                }
            }

            return "";
        }

        public string GetValorFormatado()
        {
            string valor = GetValorParametro("valorOrigem");
            return $"R$: {valor.Replace(".", ",")}";
        }

        public string ValidacaoDominio(string url)
        {
            //url.StartsWith("https://www.alura.com.br");
            //url.EndsWith("https://www.alura.com.br");
            //url.Contains("https://www.alura.com.br");

            if (url.StartsWith("https://www.alura.com.br"))
            {
                return url;
            }
            else
            {
                throw new Exception("Dominio invalido!!");
            }
        }

        //Sobrescrevendo metodo ToString();
        public override string ToString()
        {
            string retornoFormatado = $"URL chamada = {URL} \n Parametros: \n";

            foreach (string i in _argumentos) {
                retornoFormatado = retornoFormatado + i + " \n";
            }

            return retornoFormatado;
        }

        //Sobrescrevendo metodo Equals()
        public override bool Equals(object obj)
        {
            ExtratorValorDeArgumentosURL outroCaminho = obj as ExtratorValorDeArgumentosURL;

            if (outroCaminho == null)
            {
                return false;
            }

            return outroCaminho.URL == URL;
        }
    }
}
