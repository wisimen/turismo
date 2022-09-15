using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.Hotel
{
    public class HotelActualizarDTO : HotelCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodHotel { get; set; }
    }
}
