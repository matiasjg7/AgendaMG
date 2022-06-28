using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Categorias
{
    public class BorrarModel : PageModel
    {
        private readonly AgendaMGDbContext _context;
        public BorrarModel(AgendaMGDbContext context)
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
            
            if (CategoriaDb == null)
            {
                return NotFound();
            }

            //_context.Categoria.Remove(CategoriaDb);
            //await _context.SaveChangesAsync();

            CategoriaDb.Eliminado = true;
            _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
