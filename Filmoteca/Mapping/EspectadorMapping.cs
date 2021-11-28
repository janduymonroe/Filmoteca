using Filmoteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmoteca.Mapping
{
    public class EspectadorMapping : IEntityTypeConfiguration<Espectador>
    {
        public void Configure(EntityTypeBuilder<Espectador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(50)").IsRequired();
            builder.ToTable("espectadores");
        }
    }
}
