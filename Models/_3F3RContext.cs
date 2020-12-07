using Microsoft.EntityFrameworkCore;

namespace _3F3R.Models
{
    public class _3F3RContext : DbContext
    {
        public _3F3RContext(DbContextOptions<_3F3RContext> options)
            :base(options)
        {

        }

        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Zona> Zonas { get; set; }
    }
}