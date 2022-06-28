using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly AgendaMGDbContext _context;

        public IndexModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias { get; set; }

        public async Task OnGet()
        {
            Categorias = await _context.Categoria.ToListAsync();
        }

    }
}
