using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CursoEFCore.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> p)
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
    }
}
