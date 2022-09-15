using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.Vuelo
{
    public class VueloActualizarDTO: VueloCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int NumeroVuelo { get; set; }
    }
}
