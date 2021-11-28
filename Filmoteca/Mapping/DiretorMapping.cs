using Filmoteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmoteca.Mapping
{
    public class DiretorMapping : IEntityTypeConfiguration<Diretor>
    {
        public void Configure(EntityTypeBuilder<Diretor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.PaisOrigem).HasColumnType("varchar(10)").IsRequired();
            builder.ToTable("diretores");
        }
    }
}
