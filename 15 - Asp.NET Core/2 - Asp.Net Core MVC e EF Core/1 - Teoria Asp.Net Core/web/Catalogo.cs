﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivors()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Quem mexeu na minha query?", 12.99m));
            livros.Add(new Livro("002", "Fique rico com C#", 30.99m));
            livros.Add(new Livro("003", "Java para baixinhos?", 25.99m));

            return livros;
        }
    }
}
