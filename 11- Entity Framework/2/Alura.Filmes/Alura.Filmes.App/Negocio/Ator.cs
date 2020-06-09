using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    [Table("actor")] // Anotação do Entity (Define que a classe 'Ator' mapeaia a tabela 'actor' do banco)
    public class Ator
    {
        [Column("actor_id")] // Anotação do Entity (Define que a propriedade Id mapeia a colluna 'actor_id' do banco)
        public int Id { get; set; }

        [Column("first_name")]
        public string PrimeiroNome { get; set; }

        [Column("last_name")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}) {PrimeiroNome} {UltimoNome}";
        }
    }
}
