using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder
                .ToTable("actor"); // Define que a classe 'Ator' mapeaia a tabela 'actor' do banco

            builder
                .Property(a => a.Id)
                .HasColumnName("actor_id"); // Define que a propriedade Id mapeia a colluna 'actor_id' do banco

            builder
                .Property(a => a.PrimeiroNome)
                .HasColumnType("varchar(45)")
                .HasColumnName("first_name")
                .IsRequired();

            builder
                .Property(a => a.UltimoNome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            // Shadow Property - Propriedade que consta no banco, porem não é necessario ter na classe Ator
            builder
                .Property<DateTime>("last_update") 
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()") // Definindo valor padrão para Shadow Property (Inserção e Alteração)
                .IsRequired();

            // Criando Indice no banco de dados
            builder
                .HasIndex(a => a.UltimoNome) // Por padrão o entity define o nome do indice como (IXNomeTabelaNomeColuna)
                .HasName("idx_actor_last_name"); // Caso deseje definir um nome personalisado

            // Criando chave alternativa unica (Impedindo que tenha atores com nomes + sobrenomes duplicados)
            builder
                .HasAlternateKey(a => new { a.PrimeiroNome, a.UltimoNome });
        }
    }
}
