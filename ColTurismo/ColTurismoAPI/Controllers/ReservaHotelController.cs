using AutoMapper;
using ColTurismo.Common.DTOs.Hotel;
using ColTurismo.Common.DTOs.ReservaHotel;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColTurismoAPI.Controllers
{
    [ApiController]
    [Route("api/reservahotel")]
    public class ReservaHotelController : ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;

        public ReservaHotelController(
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
        public async Task<ActionResult<List<ReservaHotelDTO>>> get()
        {
            var reservaHotel = await context.ReservaHotel.ToListAsync();
            return mapper.Map<List<ReservaHotelDTO>>(reservaHotel);
        }

        [HttpGet("{codHotel}/{codTurista}", Name = "getReservaHotel")]
        public async Task<ActionResult<ReservaHotelDTO>> GetById(int codHotel, int codTurista)
        {
            var reservaHotel = await context.ReservaHotel.FirstOrDefaultAsync(x => x.CodHotel == codHotel &&  x.CodTurista == codTurista);
            return (reservaHotel == null) ? NotFound() : mapper.Map<ReservaHotelDTO>(reservaHotel);
        }

        [HttpPost("{codHotel:int}/{codTurista:int}")]
        public async Task<ActionResult> Post([FromForm] ReservaHotelCrearDTO ReservaHotelCreacion)
        {
            var ReservaHotel = mapper.Map<ReservaHotel>(ReservaHotelCreacion);
            context.Add(ReservaHotel);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado una nueva reserva Hotel.");
            return NoContent();

        }

        [HttpPut("{codHotel:int}/{codTurista:int}")]
        public async Task<ActionResult> Put(int codHotel, int codTurista, [FromBody] ReservaHotelDTO ReservaHotelUpdate)
        {
            if (ReservaHotelUpdate.CodHotel != codHotel && ReservaHotelUpdate.CodTurista != codTurista)
            {
                return BadRequest("El codHotel es erróneo y Codturista es erroneo");
            }
            var existe = await context.ReservaHotel.AnyAsync(x => x.CodHotel == codHotel && x.CodTurista == codTurista);
            if (!existe)
            {
                return NotFound();
            }

            var ReservaHotel = mapper.Map<ReservaHotel>(ReservaHotelUpdate);
            context.Update(ReservaHotel);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha actualizado la reserva  hotel {codHotel}. y  {codTurista}");
            return NoContent();
        }


        [HttpDelete("{codHotel:int}/{codTurista:int}")]
        public async Task<ActionResult> Delete(int codHotel, int codTurista)
        {
            var Hotel = await context.ReservaHotel.FirstOrDefaultAsync(x => x.CodHotel == codHotel && x.CodTurista == codTurista);
            if (Hotel == null)
            {
                return NotFound();
            }
            context.ReservaHotel.Remove(Hotel);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado la reserva  hotel {codHotel}. y  {codTurista}");
            return NoContent();
        }
    }
}

