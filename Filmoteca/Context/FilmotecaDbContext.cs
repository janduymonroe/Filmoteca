using Filmoteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmoteca.Context
{
    public class FilmotecaDbContext : DbContext
    {
        #region DbSets
        public DbSet<Espectador> Espectadores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<FilmesAssistidos> FilmesAssistidos { get; set; }
        #endregion

        public FilmotecaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmotecaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
