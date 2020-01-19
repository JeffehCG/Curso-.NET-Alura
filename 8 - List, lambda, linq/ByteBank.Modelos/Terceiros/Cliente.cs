using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    public class Cliente
    {
        public string nome;
        public string cpf;
        public string profissao;

        public Cliente(string nome, string cpf, string profissao)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.profissao = profissao;
        }
    }
}
