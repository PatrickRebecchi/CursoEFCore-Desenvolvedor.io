using Microsoft.EntityFrameworkCore;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        //HasDefaultValueSql = Valor padrão, ValueGeneratedOnAdd = Valor gerado ao adicionar
        builder.Property(p => p.Status).HasConversion<string>();
        builder.Property(p => p.TipoFrete).HasConversion<int>(); //
        builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

        builder.HasMany(p => p.Itens) //HasMany = Relacionamento de 1 para muitos
            .WithOne(p => p.Pedido) //WithOne = Relacionamento de 1 para 1
            .OnDelete(DeleteBehavior.Cascade); //OnDelete = Deletar em cascata
    }
}
