namespace Filmoteca.Models
{
    public class FilmesAssistidos
    {
        public Espectador Espectador { get; set; }
        public int IdEspectador { get; set; }
        public Filme Filme { get; set; }
        public int IdFilme { get; set; }
    }
}
