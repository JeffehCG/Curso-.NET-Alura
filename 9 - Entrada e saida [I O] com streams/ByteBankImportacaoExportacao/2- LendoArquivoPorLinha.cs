using ByteBankImportacaoExportacao.Modelos;
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
        static void LendoArquivoPorLinha()
        {
            Console.WriteLine("\n");
            // Endereço do arquivo e modo abertura 
            var enderecoArquivo = "contas.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                // Leitor de Stream (Sem se preocupar em conversão e tamanho de cadeia de bytes)
                using (var leitor = new StreamReader(fluxoArquivo))
                {
                    // Para ler por linha
                    // EndOfStream fica true quando leitor chega no final do arquivo
                    while (!leitor.EndOfStream)
                    {
                        var linha = leitor.ReadLine();
                        var contaCorrente = ConverterStringParaContaCorrente(linha);
                        Console.WriteLine($"Titular: {contaCorrente.Titular.Nome}; Conta : {contaCorrente.Agencia}-{contaCorrente.Numero};  Saldo: {contaCorrente.Saldo};");
                    }

                    // Para ler o arquivo inteiro
                    //var arquivoInteiro = leitor.ReadToEnd();
                    //Console.WriteLine(arquivoInteiro);
                }
            }
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(';');

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var conta = new ContaCorrente(int.Parse(agencia), int.Parse(numero));
            conta.Depositar(double.Parse(saldo));
            conta.Titular = titular;

            return conta;
        }
    }
}
