using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LendoArquivoPorByte()
        {
            // https://raw.githubusercontent.com/alura-cursos/csharppt9/master/contas.txt
            // Endereço do arquivo e modo abertura 
            var enderecoArquivo = "contas.txt";

            // Classe FileStream tem implementado a interface IDisposable (Para poder usar o using)
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                // Foi criado esse buffer de 1KB para armazenar os dados do arquivo no mesmo (O Read retorna de 1024 em 1024 kb);
                var buffer = new byte[1024];

                // O metodo Read sempre retorna a quantidade de bytes lidos do arquivo, com no maximo 1024 bytes, quando o arquivo chega ao final retorna 0
                var numeroDeBytesLidos = -1;
                while (numeroDeBytesLidos != 0)
                {
                    // Lendo arquivo e passando para o buffer (Do parametro 0 ao ultimo do buffer)
                    numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
                    ConvertendoCadeiaBytesEmString(buffer, numeroDeBytesLidos);

                    // O buffer sempre esta sendo sobreescrevido pela nova cadeia de bytes

                }

                // Com using, no final da execução do bloco é executado : fluxoArquivo.Close();
            }
        }

        static void ConvertendoCadeiaBytesEmString(byte[] buffer, int bytesLidos)
        {
            // Unicode Transformation Format 
            // Usando formato UTF8 (Converter bytes em string)
            var utf8 = new UTF8Encoding();

            // O metodo GetString() pode receber apenas o buffer contendo a cadeia de bytes a ser convertido
            // Ou tambem dois indices rebrecentando o intervalo que sera convertido, caso não seja preciso converter o buffer inteiro
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}
