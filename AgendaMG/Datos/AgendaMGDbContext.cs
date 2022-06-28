using AgendaMG.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AgendaMG.Datos
{
    public class AgendaMGDbContext : DbContext
    {
        public AgendaMGDbContext(DbContextOptions<AgendaMGDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Contacto> Contacto { get; set; }

    }
}
