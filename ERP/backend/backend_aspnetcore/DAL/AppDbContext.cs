using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<ContasAPagar> ContasAPagar { get; set; }
        public DbSet<ContasAReceber> ContasAReceber { get; set; }
        public DbSet<DepartamentoProduto> DepartamentoProduto { get; set; }
        public DbSet<FixaKardex> FixaKardex { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<GrupoProduto> GrupoProduto { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<ItemContasAPagar> ItemContasAPagar { get; set; }
        public DbSet<ItemContasAReceber> ItemContasAReceber { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<SubGrupoProduto> SubGrupoProduto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=../DAL/db/app.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Adicionar dados iniciais (seeds) para Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    NomeUsuario = "admin",
                    Senha = "123456",
                    Ativo = true
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Vendedor",
                    NomeUsuario = "vendedor",
                    Senha = "123456",
                    Ativo = true
                }
            );

            // Adicionar dados iniciais (seeds) para GrupoUsuario
            modelBuilder.Entity<GrupoUsuario>().HasData(
                new GrupoUsuario { Id = 1, Descricao = "Administrador" },
                new GrupoUsuario { Id = 2, Descricao = "Operador de caixa" },
                new GrupoUsuario { Id = 3, Descricao = "Estoquista" }
            );

            // Adicionar dados iniciais (seeds) para CategoriaProduto
            modelBuilder.Entity<CategoriaProduto>().HasData(
                new CategoriaProduto { Id = 1, Descricao = "Novo" },
                new CategoriaProduto { Id = 2, Descricao = "Usado" }
                );
        }
    }
}