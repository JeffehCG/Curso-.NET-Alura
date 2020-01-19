using _01__ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrenteAgencia : IComparer<ContaCorrente>
    {
        // Metodo que define como a ordenação sera feira
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == y)
            {
                return 0;
            }
            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            // O metodo CompareTo() já é implementado em string, int etc... então para simplificar pode ser feito dessa forma
            return x.Agencia.CompareTo(y.Agencia);
        }

        // Outra maneira de ser implementada

        //public int Compare(ContaCorrente x, ContaCorrente y)
        //{
        //    if (x.Agencia == y.Agencia)
        //    {
        //        return 0;
        //    }
        //    if (x == null)
        //    {
        //        return 1;
        //    }

        //    if (y == null)
        //    {
        //        return -1;
        //    }
        //    if (x.Agencia < y.Agencia)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}
    }
}
