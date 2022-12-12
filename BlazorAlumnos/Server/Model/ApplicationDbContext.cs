using BlazorAlumnos.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAlumnos.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }
        
        public DbSet<Maestro> Maestros { get; set; }

        public DbSet<Carrera> Carreras { get; set; }
    }
}



