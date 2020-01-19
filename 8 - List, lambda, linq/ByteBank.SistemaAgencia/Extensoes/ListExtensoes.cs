using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe para criar metodo de extensão da classe List (Metodo que podera ser acesado apartir de um objeto List)
// Para criar um metodo extendido é preciso ser em uma classe e metodo static
namespace ByteBank.Modelos.Utilitarios
{
    public static class ListExtensoes
    {
        // É preciso definir this List<int> lista (O primeiro parametro deve ser da classe extendida em questão)
        // Metodo generico
        // Com <T> o metodo sempre trabalha com o tipo do objeto, nesse caso com int (Por que estamos utilizando uma List de int)
        public static void AdicionarVarios<T>(this List<T> lista, params T[] items)
        {
            foreach (T item in items)
            {
                lista.Add(item);
            }
        }
    }
}
