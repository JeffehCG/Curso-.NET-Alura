using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Compra
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return $"Compra: {this.Id}, {this.Quantidade}, {this.ProdutoId}, {this.Preco}";
        }
    }
}
