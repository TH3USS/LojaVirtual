using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualASPReact.Controllers
{
    using LojaVirtualASPReact.Data;
    using LojaVirtualASPReact.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return View(produtos);
        }

        [HttpGet]
        public async Task<JsonResult> GetProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Json(produtos);
        }
    }

}
