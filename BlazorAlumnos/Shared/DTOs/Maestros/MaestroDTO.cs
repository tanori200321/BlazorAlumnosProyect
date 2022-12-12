using System.ComponentModel.DataAnnotations;


namespace BlazorAlumnos.Shared.DTOs.Maestros
{
    public class MaestroDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }

        [Required]
        public string MatriculaMaestro { get; set; }

        public int CarreraId { get; set; }
    }
}
