using Api_Tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Tareas.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {}

        public DbSet<Tareas> Tareas { get; set; }

    }
}
