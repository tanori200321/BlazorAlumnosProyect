using System.ComponentModel.DataAnnotations;

namespace BlazorAlumnos.Shared.DTOs.Alumnos
{
    public class AlumnoDTO
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
    }
}
