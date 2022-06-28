using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaMG.Datos;
using AgendaMG.Modelos.ViewModels;

namespace AgendaMG.Pages.Contactos
{
    public class EditarModel : PageModel
    {
        private readonly AgendaMGDbContext _context;

        public EditarModel(AgendaMGDbContext context)
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

            ContactoDb.Nombre = ContactoVM.Contacto.Nombre;
            ContactoDb.CorreoElectronico = ContactoVM.Contacto.CorreoElectronico;
            ContactoDb.Telefono = ContactoVM.Contacto.Telefono;
            ContactoDb.Direccion = ContactoVM.Contacto.Direccion;
            ContactoDb.CategoriaId = ContactoVM.Contacto.CategoriaId;
            ContactoDb.FechaCreacion = ContactoVM.Contacto.FechaCreacion;

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
