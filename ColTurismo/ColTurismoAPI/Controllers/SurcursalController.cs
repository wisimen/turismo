using AutoMapper;
using ColTurismo.Common.DTOs.Sucursal;
using ColTurismo.Common.DTOs.Vuelo;
using ColTurismoAPI.Data;
using ColTurismoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColTurismoAPI.Controllers
{
    [ApiController]
    [Route("api/surcursales")]
    public class SurcursalController: ControllerBase
    {

        private readonly ILogger<HotelController> logger;
        private readonly ColTurismoContext context;
        private readonly IMapper mapper;

        public SurcursalController(
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
        public async Task<ActionResult<List<SucursalDTO>>> get()
        {
            var surcursal = await context.Sucursal.ToListAsync();
            return mapper.Map<List<SucursalDTO>>(surcursal);
        }


        [HttpGet("{codSucursal}", Name = "getSucursal")]
        public async Task<ActionResult<SucursalDTO>> GetById(int codSucursal)
        {
            var surcursal = await context.Sucursal.FirstOrDefaultAsync(x => x.CodSucursal == codSucursal);
            return (surcursal == null) ? NotFound() : mapper.Map<SucursalDTO>(surcursal);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] SucursalCrearDTO surcursalCreacion)
        {
            var surcursal = mapper.Map<Sucursal>(surcursalCreacion);
            context.Add(surcursal);
            await context.SaveChangesAsync();
            logger.LogInformation("Se ha creado una nueva Surcursal.");
            return NoContent();

        }

        [HttpPut("{codSucursal:int}")]
        public async Task<ActionResult> Put(int CodSucursal, [FromBody] SucursalDTO surcursalUpdate)
        {
            if (surcursalUpdate.CodSucursal != CodSucursal)
            {
                return BadRequest("El Codigo de surcursal es erróneo");
            }
            var existe = await context.Sucursal.AnyAsync(x => x.CodSucursal == CodSucursal);
            if (!existe)
            {
                return NotFound();
            }

            var sucursal = mapper.Map<Sucursal>(surcursalUpdate);
            context.Update(sucursal);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha actualizado la sucursal{CodSucursal}.");
            return NoContent();
        }


        [HttpDelete("{codSucursal:int}")]
        public async Task<ActionResult> Delete(int CodSucursal)
        {
            var sucursal = await context.Sucursal.FirstOrDefaultAsync(x => x.CodSucursal == CodSucursal);
            if (sucursal == null)
            {
                return NotFound();
            }
            context.Sucursal.Remove(sucursal);
            await context.SaveChangesAsync();
            logger.LogInformation($"Se ha eliminado la sucursal {CodSucursal}.");
            return NoContent();
        }
    }
}

