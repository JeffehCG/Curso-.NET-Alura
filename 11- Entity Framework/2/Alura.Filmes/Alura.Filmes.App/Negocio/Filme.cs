using Alura.Filmes.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public short Duracao { get; set; }
        public string TextoClassificacao { get; private set; }
        //[NotMapped] 
        public EnumClassificacaoIndicativa Classificacao // Propriedade que esta sendo ignorada no mapeamento para o banco
        { 
            get { return TextoClassificacao.ParaValor(); } 
            set { TextoClassificacao = value.ParaString(); } 
        }
        public IList<FilmeAtor> Atores { get; set; }
        public IList<FilmeCategoria> Categorias { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }


        public Filme()
        {
            this.Atores = new List<FilmeAtor>();
            this.Categorias = new List<FilmeCategoria>();
        }

        public override string ToString()
        {
            return $"Filme ({Id}) {Titulo} {AnoLancamento}";
        }
    }
}
