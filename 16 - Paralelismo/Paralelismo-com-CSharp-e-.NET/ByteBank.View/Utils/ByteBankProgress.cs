using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByteBank.View.Utils
{
    // Implementando intergace para atualização da barra de progresso
    public class ByteBankProgress<T> : IProgress<T>
    {
        private readonly Action<T> _handler;
        private readonly TaskScheduler _contextThread;
        public ByteBankProgress(Action<T> handler)
        {
            // Pegando o contexto atual (A Thread principal)
            _contextThread = TaskScheduler.FromCurrentSynchronizationContext(); // Como no javascript : that = this; kkkk
            _handler = handler;
        }

        public void Report(T value)
        {
            // Criando task para atualizar barra de progresso
            Task.Factory.StartNew(() =>
            {
                _handler(value); // Atualizando barra de progresso
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            _contextThread); // Passando o contexto, para a barra de progresso ser atualizada a cada conta consolidada

            
        }
    }
}
