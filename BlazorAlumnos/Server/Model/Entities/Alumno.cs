using System.ComponentModel.DataAnnotations;

namespace BlazorAlumnos.Server.Model.Entities
{
    public class Alumno
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }

        [Required]
        public string MatriculaAlumno { get; set; }

        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }
    }
}
