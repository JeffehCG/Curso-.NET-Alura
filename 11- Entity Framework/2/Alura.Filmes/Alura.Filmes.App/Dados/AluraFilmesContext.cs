using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContext : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Categoria> Categorias {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AluraFilmes;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Exemplo Configuração (Movida para classe AtorConfiguration)

            //modelBuilder.Entity<Ator>()
            //    .ToTable("actor"); // Define que a classe 'Ator' mapeaia a tabela 'actor' do banco

            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.Id)
            //    .HasColumnName("actor_id"); // Define que a propriedade Id mapeia a colluna 'actor_id' do banco

            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.PrimeiroNome)
            //    .HasColumnType("varchar(45)")
            //    .HasColumnName("first_name")
            //    .IsRequired();

            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.UltimoNome)
            //    .HasColumnName("last_name")
            //    .HasColumnType("varchar(45)")
            //    .IsRequired();

            //modelBuilder.Entity<Ator>()
            //    .Property<DateTime>("last_update") // Shadow Property - Propriedade que consta no banco, porem não é necessario ter na classe Ator
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getdate()") // Definindo valor padrão para Shadow Property (Inserção e Alteração)
            //    .IsRequired();

            #endregion

            // Configuração Ator
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            // Configuração Filme
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());

            // Configuração Tabela Relacional Filme/Ator
            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());

            // Configuração Categoria
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());

            // Configuração Tabela Relacional Filme/Categoria
            modelBuilder.ApplyConfiguration(new FilmeCategoriaConfiguration());

            // Configuração Idiomas
            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());
        }
    }
}
