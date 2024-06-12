using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> bluider)
    {
        bluider.ToTable("Produtos"); //ToTable = Nome da tabela
        bluider.HasKey(p => p.Id); // HasKey = Chave primaria
        bluider.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired(); // Property = Nome da coluna, HasColumnType = tipo de dados da tabela, IsRequired = campo obrigatório
        bluider.Property(p => p.Valor).HasColumnType("DECIMAL(18,2)").IsRequired(); //HasColumnType = tipo de dados da tabela
        bluider.Property(p => p.TipoProduto).HasConversion<string>();//HasConversion = Converte o tipo de dado
    }
}
