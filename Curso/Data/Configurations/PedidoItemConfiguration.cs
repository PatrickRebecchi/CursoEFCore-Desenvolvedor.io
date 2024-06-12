using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CursoEFCore.Domain;

namespace CursoEFCore.Data.Configurations;

public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.ToTable("PedidoItens");
        builder.HasKey(p => p.Id);
        //builder.Property(p => p.PedidoId).IsRequired();
        //builder.Property(p => p.ProdutoId).IsRequired();
        builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
        builder.Property(p => p.Valor).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(p => p.Desconto).HasColumnType("DECIMAL(18,2)").IsRequired();

    }
}
