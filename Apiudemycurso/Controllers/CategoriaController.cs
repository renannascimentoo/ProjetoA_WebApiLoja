using Apiudemycurso.Context;
using Apiudemycurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiudemycurso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Categorias()
        {
            var categorias = _context.Categorias.AsNoTracking().Take(10).ToList();

            if (categorias is null)
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> CategoriaId(int id)
        {
            try
            {
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.CategoriaId == id);
                return Ok(categoria);
            }

            catch (Exception ex)
            {
                    return StatusCode(500, ex.Message);

                    

            }

        }
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> ObterCategoriaProduto()
        {
            return _context.Categorias.Include(x => x.Produtos).Where(x => x.CategoriaId <= 5).ToList();
        }

        [HttpPost]
        public ActionResult<Categoria> AdicionarCategoria(Categoria categoria)
        {
            var produtos = _context.Categorias.AddAsync(categoria);

            if (categoria is null)
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = categoria.CategoriaId }, categoria);
        }
        [HttpDelete]
        public ActionResult DeletarCategoria(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

    }
}
