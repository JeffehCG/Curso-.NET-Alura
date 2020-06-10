using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Anotações de configuração do Entity comentadas, pois a configuração foi movida para o metodo OnModelCreating na classe de Context
namespace Alura.Filmes.App.Negocio
{
    //[Table("actor")] // Anotação do Entity (Define que a classe 'Ator' mapeaia a tabela 'actor' do banco)
    public class Ator
    {
        //[Column("actor_id")] // Anotação do Entity (Define que a propriedade Id mapeia a colluna 'actor_id' do banco)
        public int Id { get; set; }

        //[Required]
        //[Column("first_name", TypeName = "varchar(45)")] // Definindo tipo da tabela
        public string PrimeiroNome { get; set; }

        //[Required]
        //[Column("last_name", TypeName = "varchar(45)")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}) {PrimeiroNome} {UltimoNome}";
        }
    }
}
