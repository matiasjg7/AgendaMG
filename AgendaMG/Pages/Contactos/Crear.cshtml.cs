using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaMG.Datos;
using AgendaMG.Modelos.ViewModels;

namespace AgendaMG.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly AgendaMGDbContext _context;
        public CrearModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contacto = new Modelos.Contacto()
            };
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            await _context.Contacto.AddAsync(ContactoVM.Contacto);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
