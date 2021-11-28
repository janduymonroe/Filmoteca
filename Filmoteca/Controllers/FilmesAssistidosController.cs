using Filmoteca.Context;
using Filmoteca.InputModel;
using Filmoteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Filmoteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesAssistidosController : Controller
    {
        private readonly FilmotecaDbContext _filmotecaDbContext;
        public FilmesAssistidosController(FilmotecaDbContext filmotecaDbContext)
        {
            _filmotecaDbContext = filmotecaDbContext;
        }

        [HttpGet]
        [Route("listar-filmes-por-espectador")]
        public async Task<IActionResult> ListarFilmesAssistidos(int IdEspectador)
        {
            return Ok(
                await _filmotecaDbContext.FilmesAssistidos
                .Include(x=>x.Espectador)
                .Include(x=>x.Filme)
                .Include(x=>x.Filme.Diretor)
                .ToListAsync()
                );
        }

        [HttpPost]
        [Route("inserir-filme-assistido")]
        public async Task<IActionResult> InserirFilmeAssistido(FilmesAssistidosInput dadosEntrada)
        {
            var espectador = await _filmotecaDbContext.Espectadores.Where(x => x.Id == dadosEntrada.IdEspectador).FirstOrDefaultAsync();

            if (espectador == null)
                return NotFound("Espectador não cadastrado.");

            var filme = await _filmotecaDbContext.Filmes.Where(x => x.Id == dadosEntrada.IdFilme).FirstOrDefaultAsync();

            if (filme == null)
                return NotFound("Filme não cadastrado.");

            var filmeAssistido = new FilmesAssistidos()
            {
                IdEspectador = dadosEntrada.IdEspectador,
                IdFilme = dadosEntrada.IdFilme
            };

            await _filmotecaDbContext.FilmesAssistidos.AddAsync(filmeAssistido);
            await _filmotecaDbContext.SaveChangesAsync();

            return Ok("Filme marcado como assistido!");
        }

       
    }
}
