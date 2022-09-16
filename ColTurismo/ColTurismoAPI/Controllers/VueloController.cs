using AutoMapper;
using ColTurismo.Common.DTOs.Hotel;
using ColTurismo.Common.DTOs.Vuelo;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ColTurismoAPI.Controllers
{


    [ApiController]
    [Route("api/vuelos")]
    public class VueloController:ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;

        public VueloController(
            ILogger<HotelController> logger,
            ColTurismoContext context,
            IMapper mapper
           )
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VueloDTO>>> get()
        {
            var vuelos = await context.Vuelo.ToListAsync();
            return mapper.Map<List<VueloDTO>>(vuelos);
        }


        [HttpGet("{numeroVuelo}", Name = "getVuelo")]
        public async Task<ActionResult<VueloDTO>> GetById(int numeroVuelo)
        {
            var vuelos = await context.Vuelo.FirstOrDefaultAsync(x => x.NumeroVuelo == numeroVuelo);
            return (vuelos == null) ? NotFound() : mapper.Map<VueloDTO>(vuelos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] VueloCrearDTO vueloCreacion)
        {
            var vuelo = mapper.Map<Vuelo>(vueloCreacion);
            context.Add(vuelo);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado un nuevo vuelo.");
            return NoContent();

        }

        [HttpPut("{numeroVuelo:int}")]
        public async Task<ActionResult> Put(int numeroVuelo, [FromBody] VueloDTO VueloUpdate)
        {
            if (VueloUpdate.NumeroVuelo != numeroVuelo)
            {
                return BadRequest("El Numero de vuelo es erróneo");
            }
            var existe = await context.Vuelo.AnyAsync(x => x.NumeroVuelo == numeroVuelo);
            if (!existe)
            {
                return NotFound();
            }

            var vuelo = mapper.Map<Vuelo>(VueloUpdate);
            context.Update(vuelo);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha actualizado el vuelo {numeroVuelo}.");
            return NoContent();
        }


        [HttpDelete("{numeroVuelo:int}")]
        public async Task<ActionResult> Delete(int numeroVuelo)
        {
            var vuelo = await context.Vuelo.FirstOrDefaultAsync(x => x.NumeroVuelo == numeroVuelo);
            if (vuelo == null)
            {
                return NotFound();
            }
            context.Vuelo.Remove(vuelo);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado el vuelo {numeroVuelo}.");
            return NoContent();
        }
    }
}
