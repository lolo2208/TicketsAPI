using APITickets.Model;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Servicio> Servicio{ get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estado> Estado{ get; set; }
        public DbSet<Preset> Preset { get; set; }
        public DbSet<Ticket> Ticket{ get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


    }
}
