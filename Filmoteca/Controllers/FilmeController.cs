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
    public class FilmeController : Controller
    {
        private readonly FilmotecaDbContext _filmotecaDbContext;

        public FilmeController(FilmotecaDbContext filmotecaDbContext)
        {
            _filmotecaDbContext = filmotecaDbContext;
        }

        [HttpGet]
        [Route("listar-filmes")]
        public async Task<IActionResult> ListarFilmes()
        {
            return Ok(
                await _filmotecaDbContext.Filmes
                .Include(x=>x.Diretor)
                .ToListAsync()
                );        
        }

        [HttpGet]
        [Route("quantidade-espectadores")]
        public async Task<IActionResult> QuantidadeEspectadores(int IdFilme)
        {
            var filme = await _filmotecaDbContext.Filmes.Where(x => x.Id == IdFilme).FirstOrDefaultAsync();

            if (filme == null)
                return NotFound("Filme não cadastrado.");

            return Ok(
                await _filmotecaDbContext.FilmesAssistidos.Where(x=>x.IdFilme == IdFilme).CountAsync()
                );
        }

        [HttpGet]
        [Route("buscar-por-titulo")]
        public async Task<IActionResult> BuscarPorNome(string titulo)
        {
            var filme = _filmotecaDbContext.Filmes.Where(x=>x.Titulo.Contains(titulo));

            if (filme == null)
                return NotFound("Filme não cadastrado.");

            return Ok(
                filme
                .Include(x=>x.Diretor)
                );
        }

        [HttpPost]
        [Route("inserir-filme")]
        public async Task<IActionResult> InserirFilme(FilmeInput dadosEntrada)
        {
            var filmeTemp = await _filmotecaDbContext.Filmes.Where(x => x.Titulo == dadosEntrada.Titulo).FirstOrDefaultAsync();

            if (filmeTemp != null)
                return BadRequest("Filme já cadastrado.");


            var filme = new Filme()
            {
                Titulo = dadosEntrada.Titulo,
                IdDiretor = dadosEntrada.IdDiretor,
                AnoLancamento = dadosEntrada.AnoLancamento,
                Imdb = dadosEntrada.Imdb
            };


            await _filmotecaDbContext.Filmes.AddAsync(filme);
            await _filmotecaDbContext.SaveChangesAsync();

            return Ok("Filme Cadastrado com Sucesso!");
        }
    }
}
