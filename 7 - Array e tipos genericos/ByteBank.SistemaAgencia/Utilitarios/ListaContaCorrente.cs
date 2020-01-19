using _01__ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Utilitarios
{
    public class ListaContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public ListaContaCorrente( int capacidadeInicial = 5, ContaCorrente contaInicial = null)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;

            if(contaInicial != null)
            {
                Adicionar(contaInicial);
            }
        }

        public void Adicionar(ContaCorrente conta)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = conta;
            _proximaPosicao++;
        }

        // params recebe varios parametros do tipo referente e transforma em um array
        public void AdicionarVarios(params ContaCorrente[] contas)
        {
            foreach(ContaCorrente conta in contas)
            {
                Adicionar(conta);
            }
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            Console.WriteLine("Aumentando capacidade da lista");

            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario * 2];

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }

        public void Remover(ContaCorrente contaRemover)
        {
            int indiceRemocao = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(contaRemover))
                {
                    indiceRemocao = i;
                    break;
                }
            }

            for(int i = indiceRemocao; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ListarItens()
        {
            foreach (ContaCorrente conta in _itens)
            {
                if(conta != null)
                {
                    conta.ExibirDados();
                }
                else
                {
                    break;
                }
            }
        }

        public ContaCorrente GetItemIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        // Indexador, para chamar o objeto instanciando com um indice, como se fosse um array
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemIndice(indice);
            }
        }

        // Indexador com params, para retornar um array de contas pelos indices
        public ContaCorrente[] this[params int[] indice]
        {
            get
            {
                ContaCorrente[] contas = new ContaCorrente[indice.Length];

                for (int i = 0; i < indice.Length; i++)
                {
                    contas[i] = GetItemIndice(indice[i]);
                }

                return contas;
            }
        }
    }
}
