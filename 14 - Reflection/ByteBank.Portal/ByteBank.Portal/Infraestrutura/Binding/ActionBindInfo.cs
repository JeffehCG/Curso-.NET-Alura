using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBindInfo
    {
        public MethodInfo MethodInfo { get; private set; }
        public IReadOnlyCollection<ArgumentoNomeValor> TuplasArgumentosNomeValor { get; private set; }

        public ActionBindInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> tuplasArgumentosNomeValor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));

            if(tuplasArgumentosNomeValor == null)
            {
                throw new ArgumentNullException(nameof(tuplasArgumentosNomeValor));
            }
            TuplasArgumentosNomeValor = new ReadOnlyCollection<ArgumentoNomeValor>(tuplasArgumentosNomeValor.ToList());
        }

        // Metodo para executar o metodo
        public object Invoke(object controller)
        {
            var possuiParametros = TuplasArgumentosNomeValor.Count > 0;

            if (!possuiParametros)
            {
                // Executando metodo (Passando qual é a controller que contem o mesmo, e os parametros a serem enviados para o metodo)
                return MethodInfo.Invoke(controller, new object[0]);
            }
            else
            {
                // Ordenando os parametros de acordo com o metodo
                var parametrosMethodInfo = MethodInfo.GetParameters();
                var parametrosInvoke = new object[TuplasArgumentosNomeValor.Count];
                for(int i = 0; i <TuplasArgumentosNomeValor.Count; i++)
                {
                    var parametro = parametrosMethodInfo[i];
                    var parametroNome = parametro.Name;

                    // Single, retorna atributo respectivo, se existir apenas um do mesmo
                    var argumento = TuplasArgumentosNomeValor.Single(tupla => tupla.Nome == parametroNome);

                    // Convertendo parametro, para o tipo que o metodo espera
                    parametrosInvoke[i] = Convert.ChangeType(argumento.Valor, parametro.ParameterType);
                }

                // Executando metodo
                return MethodInfo.Invoke(controller, parametrosInvoke);
            }
        }
    }
}
