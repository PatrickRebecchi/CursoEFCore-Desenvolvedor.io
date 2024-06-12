using Microsoft.EntityFrameworkCore;
using CursoEFCore.Domain;
using CursoEFCore.Data.Configurations;
using static System.Net.Mime.MediaTypeNames;
using System;


namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        //DbSet é uma coleção de entidades que podem ser consultadas no banco de dados
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PTIL2UL\\DBPATRICK;Initial Catalog=CursoEFCore;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

        }
    }
}