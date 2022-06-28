using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Contactos
{
    public class DetalleModel : PageModel
    {
        private readonly AgendaMGDbContext _context;
        public DetalleModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contacto Contacto { get; set; }

        public async void OnGet(int id)
        {
            Contacto = await _context.Contacto.FindAsync(id);
        }
    }
}
