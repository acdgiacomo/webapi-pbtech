using Microsoft.EntityFrameworkCore;
using PBTech.WebAPI.Models;

namespace PBTech.WebAPI.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
