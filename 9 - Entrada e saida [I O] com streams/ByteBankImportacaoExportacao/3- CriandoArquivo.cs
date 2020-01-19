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
        static void CriandoArquivoPorByte()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            // Diferente do Create, o CreateNew só cria o arquivo se o mesmo não existir
            using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaString = "456;78945;4785.50;Gustavo Santos";

                //Convertendo string em cadeia de bytes
                var encoding = Encoding.UTF8;
                var cadeiaBytes = encoding.GetBytes(contaString);

                fluxoArquivo.Write(cadeiaBytes, 0, cadeiaBytes.Length);
            }
        }

        static void CriandoArquivoPorLinha()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";
            using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                // Definido UTF8 como padrão para criar o arquivo
                using (var escritor = new StreamWriter(fluxoArquivo, Encoding.UTF8))
                {
                    var contaString = "456;24568;762.0;Pedro Augusto";
                    escritor.Write(contaString);
                }
            }
        }

        static void UsandoFlush()
        {
            // Por padrão, O metodo Write e WriteLine armazena os dados em memoria, e depois da execução do bloco inteiro salva os dados no arquivo
            // Para que os dados sejam armazenados no mesmo momento da chamada do metodo é utilizado o metodo flush
            // No exemplo abaixo, cada enter ira salvar no mesmo momento uma linha no arquivo testeFlush.csv
            var caminhoNovoArquivo = "testeFlush.csv";
            using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo, Encoding.UTF8))
            {
                for (int i = 0; i < 4; i++)
                {
                    var contaString = $"Linha {i}";
                    escritor.WriteLine(contaString);
                    escritor.Flush();

                    Console.ReadLine();
                }
            }
        }

        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaBinaria.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456);
                escritor.Write(25478);
                escritor.Write(4000.50);
                escritor.Write("Gustavo Henrique");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaBinaria.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numero = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"Titular: {titular}; Conta: {agencia}-{numero}; Saldo: {saldo}");
            }
        }
    }
}
