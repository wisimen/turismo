using AutoMapper;
using ColTurismo.Common.DTOs.ReservaHotel;
using ColTurismo.Common.DTOs.ReservaVuelo;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ColTurismoAPI.Controllers
{
    [ApiController]
    [Route("api/reservavuelos")]
    public class ReservaVueloController : ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;

        public ReservaVueloController(
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
        public async Task<ActionResult<List<ReservaVueloDTO>>> get()
        {
            var reservaVuelo = await context.ReservaVuelo.ToListAsync();
            return mapper.Map<List<ReservaVueloDTO>>(reservaVuelo);
        }

        [HttpGet("{numeroVuelo}/{codTurista}", Name = "getReservaVuelo")]
        public async Task<ActionResult<ReservaVueloDTO>> GetById(int numeroVuelo, int codTurista)
        {
            var reservaVuelo = await context.ReservaVuelo.FirstOrDefaultAsync(x => x.NumeroVuelo == numeroVuelo && x.CodTurista == codTurista);
            return (reservaVuelo == null) ? NotFound() : mapper.Map<ReservaVueloDTO>(reservaVuelo);
        }

        [HttpPost("{numeroVuelo:int}/{codTurista:int}")]
        public async Task<ActionResult> Post([FromForm] ReservaHotelCrearDTO ReservaVueloCreacion)
        {
            var reservaVuelo = mapper.Map<ReservaVuelo>(ReservaVueloCreacion);
            context.Add(reservaVuelo);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado una nueva reserva vuelo.");
            return NoContent();

        }

        [HttpPut("{numeroVuelo:int}/{codTurista:int}")]
        public async Task<ActionResult> Put(int numeroVuelo, int codTurista, [FromBody] ReservaVueloDTO ReservaVueloUpdate)
        {
            if (ReservaVueloUpdate.NumeroVuelo != numeroVuelo && ReservaVueloUpdate.CodTurista != codTurista)
            {
                return BadRequest("El numeroVuelo es erróneo y Codturista es erroneo");
            }
            var existe = await context.ReservaVuelo.AnyAsync(x => x.NumeroVuelo  == numeroVuelo && x.CodTurista == codTurista);
            if (!existe)
            {
                return NotFound();
            }

            var ReservaHotel = mapper.Map<ReservaHotel>(ReservaVueloUpdate);
            context.Update(ReservaHotel);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha actualizado la reserva  hotel {numeroVuelo}. y  {codTurista}");
            return NoContent();
        }


        [HttpDelete("{codHotel:int}/{codTurista:int}")]
        public async Task<ActionResult> Delete(int numeroVuelo, int codTurista)
        {
            var reserva = await context.ReservaVuelo.FirstOrDefaultAsync(x => x.NumeroVuelo == numeroVuelo && x.CodTurista == codTurista);
            if (reserva == null)
            {
                return NotFound();
            }
            context.ReservaVuelo.Remove(reserva);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado la reserva  hotel {numeroVuelo}. y  {codTurista}");
            return NoContent();
        }
    }
}
