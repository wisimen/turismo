using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.ContratoSucursal
{
    public class ContratoSucursalCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodSucursal { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }
    }
}
