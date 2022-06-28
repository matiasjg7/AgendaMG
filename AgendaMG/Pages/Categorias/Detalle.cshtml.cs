using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Categorias
{
    public class DetalleModel : PageModel
    {

        private readonly AgendaMGDbContext _context;
        public DetalleModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async void OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }
    }
}
