using ByteBank.Modelos.Sistemas;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Terceiros
{
    class ParceiroComercial : IAutenticavel
    {
        private AutenticavelHelper _autenticavelHelper = new AutenticavelHelper();
        public string Senha { get; set; }

        public ParceiroComercial(string senha)
        {
            Senha = senha;
        }

        public bool Autenticar(string senha)
        {
            return _autenticavelHelper.CompararSenhas(Senha, senha);
        }
    }
}
