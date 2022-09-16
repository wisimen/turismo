using AutoMapper;
using ColTurismo.Common.DTOs.ContratoSucursal;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ColTurismoAPI.Controllers
{
    [ApiController]
    [Route("api/contratosucursales")]
    public class ContratoSucursal : ControllerBase
    {

        private readonly ILogger<HotelController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;

        public ContratoSucursal(
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
        public async Task<ActionResult<List<ContratoSucursalDTO>>> get()
        {
            var ContratoSucursal = await context.ContratoSucursal.ToListAsync();
            return mapper.Map<List<ContratoSucursalDTO>>(ContratoSucursal);
        }

       

        [HttpPost("{codSucursal:int}/{codTurista:int}")]
        public async Task<ActionResult> Post([FromForm] ContratoSucursalCrearDTO ContratoHotel)
        {
            var contratoHotel = mapper.Map<ContratoSucursal>(ContratoHotel);
            context.Add(ContratoHotel);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado una nueva Contrato Hotel.");
            return NoContent();

        }

        [HttpDelete("{codSucursal:int}/{codTurista:int}")]
        public async Task<ActionResult> Delete(int codSucursal, int codTurista)
        {
            var Hotel = await context.ContratoSucursal.FirstOrDefaultAsync(x => x.CodSucursal == codSucursal && x.CodTurista == codTurista);
            if (Hotel == null)
            {
                return NotFound();
            }
            context.ContratoSucursal.Remove(Hotel);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado la reserva  hotel {codSucursal}. y turista   {codTurista}");
            return NoContent();
        }
    }
}

