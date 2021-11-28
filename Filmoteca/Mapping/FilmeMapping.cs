using Filmoteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmoteca.Mapping
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasColumnType("varchar(50)").IsRequired();
            builder.HasOne(x => x.Diretor)
                .WithMany()
                .HasForeignKey(x => x.IdDiretor);
            builder.Property(x => x.AnoLancamento);
            builder.Property(x => x.Imdb).HasColumnType("float");
            builder.ToTable("filmes");

        }
    }
}
