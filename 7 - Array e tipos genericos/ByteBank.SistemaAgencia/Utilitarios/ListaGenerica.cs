using _01__ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Utilitarios
{
    // Classe generica : É preciso passar um tipo na instanciação do mesmo
    // Onde no objeto instanciado sera tratada pelo tipo ou classe em questão definida
    public class ListaGenerica<T>
    {
        private T[] _itens;
        private int _proximaPosicao;

        public ListaGenerica( int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        // params recebe varios parametros do tipo referente e transforma em um array
        public void AdicionarVarios(params T[] items)
        {
            foreach(T item in items)
            {
                Adicionar(item);
            }
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            Console.WriteLine("Aumentando capacidade da lista");

            T[] novoArray = new T[tamanhoNecessario * 2];

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }

        public void Remover(T itemRemover)
        {
            int indiceRemocao = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(itemRemover))
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
        }

        public void ListarItens()
        {
            for(int i = 0 ; i < _proximaPosicao; i++)
            {
                Console.WriteLine(_itens[i]);
            }
        }

        public T GetItemIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        // Indexador, para chamar o objeto instanciando com um indice, como se fosse um array
        public T this[int indice]
        {
            get
            {
                return GetItemIndice(indice);
            }
        }

        // Indexador com params, para retornar um array de items pelos indices
        public T[] this[params int[] indice]
        {
            get
            {
                T[] items = new T[indice.Length];

                for (int i = 0; i < indice.Length; i++)
                {
                    items[i] = GetItemIndice(indice[i]);
                }

                return items;
            }
        }
    }
}
