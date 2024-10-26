using Apiudemycurso.Context;
using Apiudemycurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiudemycurso.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Produtos()
        {
            var produtos = _context.Produtos.AsNoTracking().Take(10).ToList();

            if (produtos is null)
            {
                return NotFound("Nenhum produto encontrado.");
            }

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Produto> ProdutosId(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Produto com ID {id} não encontrado.");
            }

            return Ok(produto);
        }
        [HttpPost]
        public ActionResult<Produto> AdicionarProduto(Produto produto)
        {
            var produtos = _context.Produtos.AddAsync(produto);

            if(produto is null)
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto",new {id = produto.ProdutoId},produto);
        }

        [HttpDelete]
        public ActionResult DeletarProduto(int id)
        {
            var produto =  _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if( produto is null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

    }
}
