using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.WebAPI.Api.Models.Paginacao
{
    public class Paginacao
    {
        public int Tamanho { get; set; } = 5;
        public int Pagina { get; set; } = 1;
    }
}
