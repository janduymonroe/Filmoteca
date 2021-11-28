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
    public class EspectadorController : Controller
    {
        private readonly FilmotecaDbContext _filmotecaDbContext;

        public EspectadorController(FilmotecaDbContext filmotecaDbContext)
        {
            _filmotecaDbContext = filmotecaDbContext;
        }

        [HttpGet]
        [Route("listar-espectadores")]
        public async Task<IActionResult> ListarEspectadores()
        {
            return Ok(
                await _filmotecaDbContext.Espectadores.ToListAsync()
                );
        }

        [HttpGet]
        [Route("quantidade-filmes")]
        public async Task<IActionResult> QuantidadeFilmesAssistidos(int IdEspectador)
        {
            var espectador = await _filmotecaDbContext.Espectadores.Where(x => x.Id == IdEspectador).FirstOrDefaultAsync();

            if (espectador == null)
                return NotFound("Espectador não cadastrado.");

            return Ok(
                await _filmotecaDbContext.FilmesAssistidos.Where(x => x.IdEspectador == IdEspectador).CountAsync()
                );
        }

        [HttpPost]
        [Route("inserir-espectador")]
        public async Task<IActionResult> InserirEspectador(EspectadorInput dadosEntrada)
        {
            var espectadorNome = _filmotecaDbContext.Espectadores.Where(x => x.Nome == dadosEntrada.Nome);
            var espectadorEmail = _filmotecaDbContext.Espectadores.Where(x => x.Email == dadosEntrada.Email);

            if (espectadorNome != null && espectadorEmail != null)
                return Conflict("Espectador já cadastrado.");

            var espectador = new Espectador()
            {
                Nome = dadosEntrada.Nome,
                Email = dadosEntrada.Email
            };

            await _filmotecaDbContext.Espectadores.AddAsync(espectador);
            await _filmotecaDbContext.SaveChangesAsync();

            return Ok("Espectador inserido com sucesso!");
        }
    }
}
