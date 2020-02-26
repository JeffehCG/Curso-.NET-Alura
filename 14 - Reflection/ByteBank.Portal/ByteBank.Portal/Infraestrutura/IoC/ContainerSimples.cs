using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.IoC
{
    public class ContainerSimples : IContainer
    {
        private readonly Dictionary<Type, Type> _mapaDeTipos = new Dictionary<Type, Type>();

        // Registrar(typeof(ICambioService), typeof(CambioTesteService))
        public void Registrar(Type tipoOrigem, Type tipoDestino)
        {
            if (_mapaDeTipos.ContainsKey(tipoOrigem))
            {
                throw new InvalidOperationException("Tipo já mapeado!");
            }

            VerificarHierarquiaOuLancarExcecao(tipoOrigem, tipoDestino);

            _mapaDeTipos.Add(tipoOrigem, tipoDestino);
        }

        // Nessa sobrecarga não é preciso utilizar o metodo VerificarHierarquiaOuLancarExcecao()
        // Pois com o (where TDestino : TOrigem) o proprio compilador idenfica a Hierarquia
        public void Registrar<TOrigem, TDestino>() where TDestino : TOrigem
        {
            if (_mapaDeTipos.ContainsKey(typeof(TOrigem)))
            {
                throw new InvalidOperationException("Tipo já mapeado!");
            }

            _mapaDeTipos.Add(typeof(TOrigem), typeof(TDestino));
        }

        private void VerificarHierarquiaOuLancarExcecao(Type tipoOrigem, Type tipoDestino)
        {
            // Verificando se o tipoDestino herda ou implementa o tipoOrigem

            if (tipoOrigem.IsInterface)
            {
                var tipoDestinoImplementaInterface = 
                    tipoDestino.GetInterfaces().Any(tipoInterface => tipoInterface == tipoOrigem);

                if (!tipoDestinoImplementaInterface)
                {
                    throw new InvalidOperationException("O tipo destino não implementa a interface");
                }
            }
            else
            {
                // Verificando se o tipo origem é filho do tipo destino
                var tipoDestinoHerdaTipoOrigem = tipoDestino.IsSubclassOf(tipoOrigem);

                if (!tipoDestinoHerdaTipoOrigem)
                {
                    throw new InvalidOperationException("O tipo destino não herda o tipo de origem");
                }
            }
        }

        // Recuperar(typeof(ICambioService)) - deve retornar uma instancia do tipo CambioTesteService
        public object Recuperar(Type tipoOrigem) // Metodo recurcivo
        {
            var tipoOrigemFoiMapeado = _mapaDeTipos.ContainsKey(tipoOrigem);

            if (tipoOrigemFoiMapeado)
            {
                var tipoDestino = _mapaDeTipos[tipoOrigem];
                return Recuperar(tipoDestino);
            }

            // Pegando todos Contrutores do tipo
            var construtores = tipoOrigem.GetConstructors();
            var construtorSemParametros = 
                construtores.FirstOrDefault(construtor => construtor.GetParameters().Any() == false);

            if(construtorSemParametros != null)
            {
                // Executando um construtor que não contem parametros
                var instanciaDestino = construtorSemParametros.Invoke(new object[0]);
                return instanciaDestino;
            }
            else
            {
                // Pegando parametros do constructor
                var construtor = construtores[0];
                var parametrosDoConstrutor = construtor.GetParameters();
                var valoresDeParametros = new object[parametrosDoConstrutor.Count()];

                for ( int i = 0; i < parametrosDoConstrutor.Count(); i++)
                {
                    var parametro = parametrosDoConstrutor[i];
                    var tipoParametro = parametro.ParameterType;

                    // Pegando os valores dos parametros (Instancias de objetos)
                    valoresDeParametros[i] = Recuperar(tipoParametro);
                }

                // Executando constructor com os parametros
                var instanciaDestino = construtor.Invoke(valoresDeParametros);
                return instanciaDestino;
            }

        }
    }
}
