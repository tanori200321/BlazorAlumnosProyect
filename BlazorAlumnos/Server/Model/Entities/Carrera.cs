using System.ComponentModel.DataAnnotations;

namespace BlazorAlumnos.Server.Model.Entities
{
    public class Carrera
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<Materia> Materias { get; set; }
    }
}
