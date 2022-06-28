using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaMG.Datos;
using AgendaMG.Modelos.ViewModels;

namespace AgendaMG.Pages.Contactos
{
    public class BorrarModel : PageModel
    {
        private readonly AgendaMGDbContext _context;
        public BorrarModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public CrearContactoVM ContactoVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contacto = await _context.Contacto.FindAsync(id)
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var ContactoDb = await _context.Contacto.FindAsync(ContactoVM.Contacto.Id);
            if (ContactoDb == null)
            {
                return NotFound();
            }

            //_context.Contacto.Remove(ContactoDb);
            //await _context.SaveChangesAsync();

            ContactoDb.Eliminado = true;
            _context.SaveChangesAsync();
            
            return RedirectToPage("Index");
        }
    }
}
