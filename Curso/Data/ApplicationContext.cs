using Microsoft.EntityFrameworkCore;
using CursoEFCore.Domain;


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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CursoEFCore;Integrated Security=True");
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(p=>
            {
                p.ToTable("Clientes"); //ToTable = Nome da tabela
                p.HasKey(p => p.Id);  // HasKey = Chave primaria
                p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").
                IsRequired(); // Property = Nome da coluna, HasColumnType = tipo de dados da tabela, IsRequired = campo obrigatório
                p.Property(p => p.Telefone).HasColumnType("CHAR(11)"); 
                p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
                p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
                p.Property(p => p.Cidade).HasMaxLength(60).IsRequired(); //HasMaxLength = Tamanho máximo do campo, IsRequired = campo obrigatório

                p.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone"); //HasIndex = Cria um índice na tabela
            });

            modelBuilder.Entity<Produto>(p =>
            {
                p.ToTable("Produtos");
                p.HasKey(p => p.Id);
                p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.TipoProduto).HasConversion<string>();//HasConversion = Converte o tipo de dado

            });


            modelBuilder.Entity<Pedido>(p =>
            {
                p.ToTable("Pedidos");
                p.HasKey(p => p.Id);
                p.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                //HasDefaultValueSql = Valor padrão, ValueGeneratedOnAdd = Valor gerado ao adicionar
                p.Property(p => p.Status).HasConversion<string>();
                p.Property(p => p.TipoFrete).HasConversion<int>(); //
                p.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                p.HasMany(p => p.Itens) //HasMany = Relacionamento de 1 para muitos
                    .WithOne(p => p.Pedido) //WithOne = Relacionamento de 1 para 1
                    .OnDelete(DeleteBehavior.Cascade); //OnDelete = Deletar em cascata

            });

            modelBuilder.Entity<PedidoItem>(p =>
            {
                p.ToTable("PedidoItens");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired(); //HasDefaultValue = Valor padrão, caso não seja informado o valor, padrão será 1
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.Desconto).IsRequired();
            });
        }
    }
}