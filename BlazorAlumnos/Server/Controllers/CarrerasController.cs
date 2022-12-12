using BlazorAlumnos.Server.Model.Entities;
using BlazorAlumnos.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAlumnos.Shared.DTOs.Carreras;

namespace BlazorAlumnos.Server.Controllers
{
    [ApiController, Route("api/carreraz")]
    public class CarrerasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CarrerasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarreraDTO>>> GetMaterias()
        {
            var carreras = await context.Carreras.ToListAsync();

            var carrerasDto = new List<CarreraDTO>();

            foreach (var carrera in carreras)
            {
                var carreraDto = new CarreraDTO();
                carreraDto.Id = carrera.Id;
                carreraDto.Nombre = carrera.Nombre;

                carrerasDto.Add(carreraDto);
            }
            return carrerasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarreraDTO>> GetCarrera(int id)
        {
            var carrera = await context.Carreras
                .FirstOrDefaultAsync(x => x.Id == id);

            if (carrera == null)
            {
                return NotFound();
            }

            var carreraDto = new CarreraDTO();
            carreraDto.Id = carrera.Id;
            carreraDto.Nombre = carrera.Nombre;


            return carreraDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CarreraDTO carreraDto)
        {
            var carrera = new Carrera();
            carrera.Id = carreraDto.Id;
            carrera.Nombre = carreraDto.Nombre;

            context.Carreras.Add(carrera);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] CarreraDTO carreraDto)
        {
            var carreraDb = await context.Carreras
                .FirstOrDefaultAsync(x => x.Id == carreraDto.Id);

            if (carreraDb == null)
            {
                return NotFound();
            }
            carreraDb.Id = carreraDb.Id;
            carreraDb.Nombre = carreraDb.Nombre;

            context.Carreras.Update(carreraDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carreraDb = await context
                .Carreras
                .FirstOrDefaultAsync(x => x.Id == id);

            if (carreraDb == null)
            {
                return NotFound();
            }

            context.Carreras.Remove(carreraDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    } 
}