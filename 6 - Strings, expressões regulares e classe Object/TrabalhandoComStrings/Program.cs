using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrabalhandoComStrings.Class;

namespace TrabalhandoComStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilizandoSubstring();
            UtilizandoIndexOf();
            RecuperandoParametrosUrl();
            GetNumeroTelefoneString();
            ComparandoObjetos();

            Console.ReadLine();
        }

        static void UtilizandoSubstring()
        {
            string url = "pagina?argumentos";

            Console.WriteLine(url);
            string urlQuebrada = url.Substring(7 , 5);
            Console.WriteLine(urlQuebrada);
        }

        static void UtilizandoIndexOf()
        {
            string url = "pagina?argumentos";

            int indiceInterrogacao = url.IndexOf("?");

            string urlQuebrada = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine(urlQuebrada);
        }

        static void RecuperandoParametrosUrl()
        {
            try
            {
                ExtratorValorDeArgumentosURL caminho = new ExtratorValorDeArgumentosURL("https://www.alura.com.br?moedaOrigem=real&moedaDestino=dolar&valorOrigem=49.99");
                Console.WriteLine(caminho.GetValorParametro("moedaOrigem"));
                Console.WriteLine(caminho.GetValorFormatado());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void GetNumeroTelefoneString()
        {
            // [] = Intervalo de caracteres 
            // {} = Quantificador (Quantas vezes esse intervalo ira se repetir)

            // A seguir segue uma evolução da Regex

            // - string padraoNumeroTelefone = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
 
            // - string padraoNumeroTelefone = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";

            // - string padraoNumeroTelefone = "[0-9]{4}[-][0-9]{4}";
  
            // A expressão regular abaixo pega o numero se tiver o - ou não, e tambem pega o numero com a primeira cadeira de caracteres 5 ou 4 (Ou seja, pega o 9 do começo do numero)
            // - string padraoNumeroTelefone = "[0-9]{4,5}[-]{0,1}[0-9]{4}";

            // Quando o intervalo contem apenas 1 caracteres, as () não são obrigatorias 
            // -string padraoNumeroTelefone = "[0-9]{4,5}-{0,1}[0-9]{4}";

            // O operador ? define que o caracter '-' pode existir ou não
            string padraoNumeroTelefone = "[0-9]{4,5}-?[0-9]{4}";

            string textoComNumero = "Meu nome é Jefferson, me ligue em 93568-4235";

            //Verificando sé contem algum numero de telefone na string
            if(Regex.IsMatch(textoComNumero, padraoNumeroTelefone))
            {
                Match telefone = Regex.Match(textoComNumero, padraoNumeroTelefone);
                Console.WriteLine(telefone.Value);
            }
        }

        static void ComparandoObjetos()
        {
            ExtratorValorDeArgumentosURL caminho1 = new ExtratorValorDeArgumentosURL("https://www.alura.com.br?moedaOrigem=real&moedaDestino=dolar&valorOrigem=49.99");
            ExtratorValorDeArgumentosURL caminho2 = new ExtratorValorDeArgumentosURL("https://www.alura.com.br?moedaOrigem=real&moedaDestino=dolar&valorOrigem=49.99");

            // Metodo Equals sobrescrito na classe
            if (caminho1.Equals(caminho2))
            {
                Console.WriteLine("Objetos Iguais");
            }
            else
            {
                Console.WriteLine("Objetos não são Iguais");
            }

            // Quando um objeto é passado como parametro para o Console.WriteLine() é utilizado o metodo ToString()
            // O metodo ToString() da classe foi sobreescrito (Assim tendo um retorno personalizado no Console.WriteLine)
            Console.WriteLine(caminho1);
        }
    }
}
