using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.Turista
{
    public class TuristaActualizarDTO : TuristaCrearDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }
    }
}
