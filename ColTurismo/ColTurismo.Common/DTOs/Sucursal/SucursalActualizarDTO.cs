using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.Sucursal
{
    public class SucursalActualizarDTO:SucursalCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodSucursal { get; set; }
    }
}
