using System.ComponentModel.DataAnnotations;
namespace ColTurismo.Common.DTOs.ReservaHotel
{
    public class ReservaHotelCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodReserva { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodHotel { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaEntrada { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Regimen { get; set; }
    }
}
