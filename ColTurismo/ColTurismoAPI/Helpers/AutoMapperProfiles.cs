using AutoMapper;
using ColTurismo.Common.DTOs.ContratoSucursal;
using ColTurismo.Common.DTOs.Hotel;
using ColTurismo.Common.DTOs.ReservaHotel;
using ColTurismo.Common.DTOs.ReservaVuelo;
using ColTurismo.Common.DTOs.Sucursal;
using ColTurismo.Common.DTOs.Turista;
using ColTurismo.Common.DTOs.Vuelo;
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
            CreateMap<Vuelo, VueloDTO>();
            CreateMap<VueloCrearDTO, Vuelo>();
            CreateMap<VueloActualizarDTO, Vuelo>();
            //Mappers de hotel
            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelCrearDTO, Hotel>();
            CreateMap<HotelActualizarDTO, Hotel>();
            //Mappers de sucursal
            CreateMap<Sucursal, SucursalDTO>();
            CreateMap<SucursalCrearDTO, Sucursal>();
            CreateMap<SucursalActualizarDTO, Sucursal>();
            //Mappers de contratos
            CreateMap<ContratoSucursal, ContratoSucursalDTO>();
            CreateMap<ContratoSucursalCrearDTO, ContratoSucursal>();
            //Mappers de reservasVuelos
            CreateMap<ReservaVuelo, ReservaVueloDTO>();
            CreateMap<ReservaVueloCrearDTO, ReservaVuelo>();
            //Mappers de reservasHotel
            CreateMap<ReservaHotel, ReservaHotelDTO>();
            CreateMap<ReservaHotelCrearDTO, ReservaHotel>();

       }
    }
}
