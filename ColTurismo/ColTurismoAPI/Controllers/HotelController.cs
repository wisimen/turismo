using AutoMapper;
using ColTurismo.Common.DTOs.Hotel;
using ColTurismo.Common.DTOs.Turista;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ColTurismoAPI.Controllers
{
    
        [ApiController]
        [Route("api/hoteles")]
        public class HotelController : ControllerBase
        {
            private readonly ILogger<HotelController> logger;
            private readonly ColTurismoContext context;
            private readonly IMapper mapper;
        
            public HotelController(
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
            public async Task<ActionResult<List<HotelDTO>>> get()
            {
                var Hotel = await context.Hoteles.ToListAsync();
                return mapper.Map<List<HotelDTO>>(Hotel);
            }

            [HttpGet("{codHotel}", Name = "getHotel")]
            public async Task<ActionResult<HotelDTO>> GetById(int codHotel)
            {
                var hotel = await context.Hoteles.FirstOrDefaultAsync(x => x.CodHotel == codHotel);
                return (hotel == null) ? NotFound() : mapper.Map<HotelDTO>(hotel);
            }

            [HttpPost]
            public async Task<ActionResult> Post([FromForm] HotelCrearDTO hotelCreacion)
            {
                var hotel = mapper.Map<Hotel>(hotelCreacion);
                context.Add(hotel);
                await context.SaveChangesAsync();
                logger.LogInformation("Se ha creado un nuevo Hotel.");
                return NoContent();

            }

            [HttpPut("{codHotel:int}")]
            public async Task<ActionResult> Put(int codHotel, [FromBody] HotelDTO HotelUpdate)
            {
                if (HotelUpdate.CodHotel != codHotel)
                {
                    return BadRequest("El codHotel es erróneo");
                }
                var existe = await context.Hoteles.AnyAsync(x => x.CodHotel == codHotel);
                if (!existe)
                {
                    return NotFound();
                }

                var Hotel = mapper.Map<Hotel>(HotelUpdate);
                context.Update(Hotel);
                await context.SaveChangesAsync();
                logger.LogInformation($"Se ha actualizado el hotel {codHotel}.");
                return NoContent();
            }


            [HttpDelete("{codHotel:int}")]
            public async Task<ActionResult> Delete(int CodHotel)
            {
                var Hotel = await context.Hoteles.FirstOrDefaultAsync(x => x.CodHotel == CodHotel);
                if (Hotel == null)
                {
                    return NotFound();
                }
                context.Hoteles.Remove(Hotel);
                await context.SaveChangesAsync();
                logger.LogInformation($"Se ha eliminado el hotel {CodHotel}.");
                return NoContent();
            }
        }
    }

