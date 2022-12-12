using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAlumnos.Shared.DTOs.Maestros
{
    internal class MaestroDTO
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
