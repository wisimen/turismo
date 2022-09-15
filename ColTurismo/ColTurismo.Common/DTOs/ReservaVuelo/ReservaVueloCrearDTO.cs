using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismo.Common.DTOs.ReservaVuelo
{
    public class ReservaVueloCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int NumeroVuelo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Clase { get; set; }
    }
}
