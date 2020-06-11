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
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder
                .ToTable("film");

            builder
                .Property(a => a.Id)
                .HasColumnName("film_id");

            builder
                .Property(a => a.Titulo)
                .HasColumnType("varchar(255)")
                .HasColumnName("title")
                .IsRequired();

            builder
                .Property(a => a.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(a => a.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(a => a.Duracao)
                .HasColumnName("length");

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            // Relacionamento (Duas propriedade com chave estranheira para mesma tabela) (Filme tem dois idiomas)
            builder
                .Property<byte>("language_id");

            builder
                .Property<byte?>("original_language_id"); // Repare que o tipo byte esta com '?' , isso define que não é um valor obrigatorio (permite null)

            builder
                .HasOne(f => f.IdiomaFalado)
                .WithMany(i => i.FilmesFalados)
                .HasForeignKey("language_id");

            builder
                .HasOne(f => f.IdiomaOriginal)
                .WithMany(i => i.FilmesOriginais)
                .HasForeignKey("original_language_id");
        }
    }
}
