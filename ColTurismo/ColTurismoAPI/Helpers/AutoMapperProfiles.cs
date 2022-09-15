using AutoMapper;
using ColTurismo.Common.DTOs.Turista;
using ColTurismoAPI.Entities;

namespace ColTurismoAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mappers de turista
            CreateMap<Turista, TuristaDTO>();
            CreateMap<TuristaCrearDTO, Turista>();
            CreateMap<TuristaActualizarDTO, Turista>();
            //Mappers de vuelo
            //...
            //Mappers de hotel
            //...
            //Mappers de sucursal
            //...
            //Mappers de contratos
            //...
            //Mappers de reservasVuelos
            //...
            //Mappers de reservasHotel
            //...
        }
    }
}
