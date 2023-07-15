using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoEF.Models
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //List<Categoria> categoriasInit = new List<Categoria>();
            //categoriasInit.Add(new Categoria() { Nombre = "Matematicas", peso = 50 });
            //categoriasInit.Add(new Categoria() { Nombre = "Ingles", peso = 20 });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");

                categoria.HasKey(p => p.CategoriaId)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("SqlServer:IdentityIncrement", 1);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion).IsRequired(false);

                categoria.Property(p => p.peso);

                //categoria.HasData(categoriasInit);
            });

            //List<Tarea> tareasInit = new List<Tarea>();
            //tareasInit.Add(new Tarea() { CategoriaId = 1, PrioridadTarea = Prioridad.media, Titulo = "Tarea Mate", FechaCreacion = DateTime.Now });
            //tareasInit.Add(new Tarea() { CategoriaId = 2, PrioridadTarea = Prioridad.baja, Titulo = "Ejercicio verbo to be", FechaCreacion = DateTime.Now });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("SqlServer:IdentityIncrement", 1);

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Descripcion).IsRequired(false);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);

                tarea.Ignore(p => p.Resumen);

                //tarea.HasData(tareasInit);

            });
        }
    }
}
