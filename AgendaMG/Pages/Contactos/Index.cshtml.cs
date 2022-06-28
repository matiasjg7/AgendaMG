using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Contactos
{
    public class IndexModel : PageModel
    {
        private readonly AgendaMGDbContext _context;
        public IndexModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contacto> Contactos { get; set; }

        public async Task OnGet()
        {
            Contactos = await _context.Contacto.Include(c => c.Categoria).ToListAsync();
        }

    }
}
