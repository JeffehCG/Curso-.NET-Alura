using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Sistemas
{
    // Quando a classe é definida como internal, é possivel acessala apenas dentro da biblioteca de classe
    // Ou seja, outros projetos que referenciam essa biblioteca não teram acesso as classas com internal
    internal class AutenticavelHelper
    {
        public bool CompararSenhas(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}
