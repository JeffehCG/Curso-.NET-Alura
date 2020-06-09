using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<Promocao> Promocoes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        // Endereço não precisa ser colocado aqui, pois esta presente na classe Cliente (E sera mapeado por ela)
        // Como não precisaremos tratar o Enderece em um contexto individual, não precisara ser definido no DbContext
        //public DbSet<Endereco> Enderecos { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conexão banco
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Criação chave primaria composta (Tabela de muitos para muitos)
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(p => new { p.PromocaoId, p.ProdutoId });

            // Criando chave primaria de endereço a apartir da chave primaria de cliente (Relacionamento de 1 para 1)
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }
    }
}