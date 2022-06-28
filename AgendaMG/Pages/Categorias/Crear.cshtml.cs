using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendaMG.Datos;
using AgendaMG.Modelos;

namespace AgendaMG.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly AgendaMGDbContext _context;

        public CrearModel(AgendaMGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Categoria.AddAsync(Categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
