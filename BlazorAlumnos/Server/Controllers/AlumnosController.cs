using BlazorAlumnos.Server.Model.Entities;
using BlazorAlumnos.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAlumnos.Shared.DTOs.Alumnos;

namespace BlazorAlumnos.Server.Controllers
{
    [ApiController, Route("api/alumnoz")]
    public class AlumnosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AlumnosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDTO>>> GetAlumnos()
        {
            var alumnos = await context.Alumnos.ToListAsync();

            var alumnosDto = new List<AlumnoDTO>();

            foreach(var alumno in alumnos) 
            {
                var alumnoDto = new AlumnoDTO();
                alumnoDto.Id = alumno.Id;
                alumnoDto.Nombre = alumno.Nombre;
                alumnoDto.Apellido = alumno.Apellido;
                alumnoDto.Correo = alumno.Correo;
                alumnoDto.MatriculaAlumno = alumno.MatriculaAlumno;
                alumnoDto.CarreraId = alumno.CarreraId;

                alumnosDto.Add(alumnoDto);
            }
            return alumnosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlumnoDTO>> GetAlumno(int id)
        {
            var alumno = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumno == null)
            {
                return NotFound();
            }

            var alumnoDto = new AlumnoDTO();
            alumnoDto.Id = alumno.Id;
            alumnoDto.Nombre = alumno.Nombre;
            alumnoDto.Apellido = alumno.Apellido;
            alumnoDto.Correo = alumno.Correo;
            alumnoDto.MatriculaAlumno = alumno.MatriculaAlumno;
            alumnoDto.CarreraId = alumno.CarreraId;

            return alumnoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AlumnoDTO alumnoDto)
        {
            var alumno = new Alumno();
            alumno.Nombre = alumnoDto.Nombre;
            alumno.Apellido = alumnoDto.Apellido;
            alumno.Correo = alumnoDto.Correo;
            alumno.MatriculaAlumno = alumnoDto.MatriculaAlumno;
            alumno.CarreraId = alumnoDto.CarreraId;

            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] AlumnoDTO alumnoDto)
        {
            var alumnoDb = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == alumnoDto.Id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            alumnoDb.Nombre = alumnoDto.Nombre;
            alumnoDb.Apellido = alumnoDto.Apellido;
            alumnoDb.Correo = alumnoDto.Correo;
            alumnoDb.MatriculaAlumno = alumnoDto.MatriculaAlumno;
            alumnoDb.CarreraId = alumnoDto.CarreraId;

            context.Alumnos.Update(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alumnoDb = await context
                .Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
