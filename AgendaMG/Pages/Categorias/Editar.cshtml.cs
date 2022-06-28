using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendaMG.Datos;
using AgendaMG.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AgendaMG.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly AgendaMGDbContext _context;

        public EditarModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        public async void OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var CategoriaDb = await _context.Categoria.FindAsync(Categoria.Id);
            CategoriaDb.Nombre = Categoria.Nombre;
            CategoriaDb.FechaCreacion = Categoria.FechaCreacion;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
