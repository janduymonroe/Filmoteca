using System.Collections.Generic;

namespace Filmoteca.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Diretor Diretor { get; set; }
        public int IdDiretor { get; set; }
        public int AnoLancamento { get; set; }
        public double Imdb { get; set; }
    }
}
