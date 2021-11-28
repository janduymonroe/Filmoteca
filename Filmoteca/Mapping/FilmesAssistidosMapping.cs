using Filmoteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmoteca.Mapping
{
    public class FilmesAssistidosMapping : IEntityTypeConfiguration<FilmesAssistidos>
    {
        public void Configure(EntityTypeBuilder<FilmesAssistidos> builder)
        {
            builder.HasKey(x=>new {x.IdEspectador, x.IdFilme });
            builder.HasOne(x => x.Espectador)
                .WithMany()
                .HasForeignKey(x => x.IdEspectador);
            builder.HasOne(x => x.Filme)
                .WithMany()
                .HasForeignKey(x => x.IdFilme);
            builder.ToTable("filmesassistidos");
        }
    }
}
