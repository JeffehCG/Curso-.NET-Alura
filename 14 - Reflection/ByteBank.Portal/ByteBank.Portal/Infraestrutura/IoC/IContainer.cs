using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IoC - Inversão de Controle
namespace ByteBank.Portal.Infraestrutura.IoC
{
    public interface IContainer
    {
        // Metodo para registrar um tipo (relacionando o tipoDestino com o tipoOrigem)
        void Registrar(Type tipoOrigem, Type tipoDestino);

        // Sobrecarga do meto Registra, para o proprio compilador verificar o erro de injeção de dependencia de classes que não implementão a interface
        void Registrar<TOrigem, TDestino>() where TDestino : TOrigem;

        // Recuperar o tipo destino de acordo com o origem
        object Recuperar(Type tipoOrigem);
    }
}
