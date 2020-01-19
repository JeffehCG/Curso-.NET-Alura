using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    // Com partial você consegue dividir sua classe em varios arquivos
    partial class Program
    {
        static void Main(string[] args)
        {
            LendoArquivoPorByte();
            LendoArquivoPorLinha();
            CriandoArquivoPorByte();
            CriandoArquivoPorLinha();
            AuxiliaresDaClasseFile();
            UsandoStreamEntrada();
            EscritaBinaria();
            LeituraBinaria();
            UsandoFlush();

            Console.ReadLine();
        }
    }
}
