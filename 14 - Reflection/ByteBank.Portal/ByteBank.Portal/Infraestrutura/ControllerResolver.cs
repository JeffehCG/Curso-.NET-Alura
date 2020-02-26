using ByteBank.Portal.Infraestrutura.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ControllerResolver
    {
        private readonly IContainer _container;

        public ControllerResolver(IContainer container)
        {
            _container = container;
        }

        // nomeController = ByteBank.Portal.Controller.CambioController (Exemplo esperado)
        public object ObterController(string nomeController)
        {
            var tipoController = Type.GetType(nomeController);
            // O metodo recuperar retorna uma instancia da controller (Preenchendo os parametros do constructor com a injeção de dependencia)
            var instanciaController = _container.Recuperar(tipoController);
            return instanciaController;

            // Criando uma instancia do Controller recebido na requisição (Nesse caso sem a injeção de dependencias)
            // Activator.CreateInstance - recebe (Nome do Assembly, no caso do projeto, nome completo do controller, e os parametros passados para o controller, nesse caso vazio)
            //var controllerWrapper = Activator.CreateInstance("ByteBank.Portal", nomeController, new object[0]);
            //return instanciaController = controllerWrapper.Unwrap();
        }
    }
}
