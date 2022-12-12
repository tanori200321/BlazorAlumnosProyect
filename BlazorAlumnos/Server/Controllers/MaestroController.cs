using BlazorAlumnos.Server.Model.Entities;
using BlazorAlumnos.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAlumnos.Shared.DTOs.Maestros;

namespace BlazorAlumnos.Server.Controllers
{
    [ApiController, Route("api/maestroz")]
    public class MaestrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MaestrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaestroDTO>>> GetMaestros()
        {
            var maestros = await context.Maestros.ToListAsync();

            var maestrosDto = new List<MaestroDTO>();

            foreach (var maestro in maestros)
            {
                var maestroDto = new MaestroDTO();
                maestroDto.Id = maestro.Id;
                maestroDto.Nombre = maestro.Nombre;
                maestroDto.Apellido = maestro.Apellido;
                maestroDto.Correo = maestro.Correo;
                maestroDto.MatriculaMaestro = maestro.MatriculaMaestro;
                maestroDto.CarreraId = maestro.CarreraId;

                maestrosDto.Add(maestroDto);
            }
            return maestrosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaestroDTO>> GetMaestro(int id)
        {
            var maestro = await context.Maestros
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maestro == null)
            {
                return NotFound();
            }

            var maestroDto = new MaestroDTO();
            maestroDto.Id = maestro.Id;
            maestroDto.Nombre = maestro.Nombre;
            maestroDto.Apellido = maestro.Apellido;
            maestroDto.Correo = maestro.Correo;
            maestroDto.MatriculaMaestro = maestro.MatriculaMaestro;
            maestroDto.CarreraId = maestro.CarreraId;


            return maestroDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MaestroDTO maestroDto)
        {
            var maestro = new Maestro();
            maestro.Nombre = maestroDto.Nombre;
            maestro.Apellido = maestroDto.Apellido;
            maestro.Correo = maestroDto.Correo;
            maestro.MatriculaMaestro = maestroDto.MatriculaMaestro;
            maestro.CarreraId = maestroDto.CarreraId;

            context.Maestros.Add(maestro);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MaestroDTO maestroDto)
        {
            var maestroDb = await context.Maestros
                .FirstOrDefaultAsync(x => x.Id == maestroDto.Id);

            if (maestroDb == null)
            {
                return NotFound();
            }

            maestroDb.Nombre = maestroDb.Nombre;
            maestroDb.Apellido = maestroDb.Apellido;
            maestroDb.Correo = maestroDb.Correo;
            maestroDb.MatriculaMaestro = maestroDb.MatriculaMaestro;
            maestroDb.CarreraId = maestroDb.CarreraId;

            context.Maestros.Update(maestroDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var maestroDb = await context
                .Maestros
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maestroDb == null)
            {
                return NotFound();
            }

            context.Maestros.Remove(maestroDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}