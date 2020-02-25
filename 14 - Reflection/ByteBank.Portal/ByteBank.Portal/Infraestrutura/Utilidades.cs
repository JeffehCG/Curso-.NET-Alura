using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public static class Utilidades
    {
        // Metodo verificando retorno de arquivo statico, ou uso controller
        public static bool VerificarChamadaDeArquivo(string path)
        {
            // Caso exista alguma entrada vazia remova , Exemplo - /Assets//css/styles.css (Duas barras seguidas)
            var partesPath = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var ultimaParte = partesPath.Last();

            return ultimaParte.Contains('.');
        }

        // Retornando caminho do arquivo pelo Assembly
        public static string ConverterPathParaNomeAssembly(string path)
        {
            // Exemplo path - /Assets/css/styles.css

            var prefixoAssembly = "ByteBank.Portal";
            var pathComPontos = path.Replace('/', '.');

            var nomeCompleto = $"{prefixoAssembly}{pathComPontos}";

            return nomeCompleto;
        }

        // Retornando tipo do arquivo
        public static string ObterTipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
            {
                return "text/css; charset=utf-8";
            }

            if (path.EndsWith(".js"))
            {
                return "application/js; charset=utf-8";
            }

            if (path.EndsWith(".html"))
            {
                return "text/html; charset=utf-8";
            }

            throw new NotImplementedException("Tipo de arquivo não previsto");
        }
    }
}
