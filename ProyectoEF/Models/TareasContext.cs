using Microsoft.EntityFrameworkCore;

namespace ProyectoEF.Models
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) 
        {

        }


    }
}
