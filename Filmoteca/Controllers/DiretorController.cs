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
    public class DiretorController : Controller
    {
        private readonly FilmotecaDbContext _filmotecaDbContext;

        public DiretorController(FilmotecaDbContext filmotecaDbContext)
        {
            _filmotecaDbContext = filmotecaDbContext;
        }

        [HttpGet]
        [Route("listar-diretores")]
        public async Task<IActionResult> ListarDiretores()
        {
            return Ok(
                await _filmotecaDbContext.Diretores.ToListAsync()
                );
        }

        [HttpPost]
        [Route("inserir-diretor")]
        public async Task<IActionResult> InserirDiretor(DiretorInput dadosEntrada)
        {
            var diretorTemp = await _filmotecaDbContext.Diretores.Where(x => x.Nome == dadosEntrada.Nome).FirstOrDefaultAsync();

            if (diretorTemp != null)
                return BadRequest("Diretor já cadastrado.");

            var diretor = new Diretor()
            {
                Nome = dadosEntrada.Nome,
                PaisOrigem = dadosEntrada.PaisOrigem
            };

            await _filmotecaDbContext.Diretores.AddAsync(diretor);
            await _filmotecaDbContext.SaveChangesAsync();

            return Ok("Diretor inserido com sucesso!");
        }
    }
}
