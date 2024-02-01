using Microsoft.EntityFrameworkCore;

namespace fristclass.webapp.databesContex
{
    public class applicationDBContax(DbContextOptions<applicationDBContax> ContextOptions) : DbContext(ContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(applicationDBContax).Assembly);
        }
    }
}
