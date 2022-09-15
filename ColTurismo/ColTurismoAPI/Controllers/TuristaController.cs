using AutoMapper;
using ColTurismo.Common.DTOs.Turista;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using ColTurismoAPI.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColTurismoAPI.Controllers
{
    [ApiController]
    [Route("api/turistas")]
    public class TuristaController : ControllerBase
    {
        private readonly ILogger<TuristaController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";


        public TuristaController(
            ILogger<TuristaController> logger,
            ColTurismoContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<TuristaDTO>>> get()
        {
            var turista = await context.Turista.ToListAsync();
            return mapper.Map<List<TuristaDTO>>(turista);
        }

        [HttpGet("{codTurista}", Name = "getTurista")]
        public async Task<ActionResult<TuristaDTO>> GetById(int codTurista)
        {
            var turista = await context.Turista.FirstOrDefaultAsync(x => x.CodTurista == codTurista);
            return (turista == null) ? NotFound() : mapper.Map<TuristaDTO>(turista);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]TuristaCreacionDTO turistaCreacion)
        {
            var turista = mapper.Map<Turista>(turistaCreacion);
           
            if(turistaCreacion.Foto!=null) turista.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, turistaCreacion.Foto);

            context.Add(turista);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado un nuevo turista.");
            return NoContent();

        }

        [HttpPut("{codTurista:int}")]
        public async Task<ActionResult> Put(int codTurista, [FromBody] TuristaDTO turistaUpdate)
        {
            if (turistaUpdate.CodTurista != codTurista)
            {
                return BadRequest("El codTurista es erróneo");
            }
            var existe = await context.Turista.AnyAsync(x => x.CodTurista == codTurista);
            if (!existe)
            {
                return NotFound();
            }

            var turista = mapper.Map<Turista>(turistaUpdate);
            context.Update(turista);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha actualizado el turista {codTurista}.");
            return NoContent();
        }


        [HttpDelete("{codTurista:int}")]
        public async Task<ActionResult> Delete(int codTurista)
        {
            var turista = await context.Turista.FirstOrDefaultAsync(x => x.CodTurista == codTurista);
            if (turista == null)
            {
                return NotFound();
            }
            context.Turista.Remove(turista);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado el turista {codTurista}.");
            return NoContent();
        }
    }
}
