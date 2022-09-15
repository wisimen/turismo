using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ColTurismo.Common.DTOs.Turista
{
    public class TuristaActualizarDTO : TuristaDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }

        public TuristaActualizarDTO(int codTurista, string nombre, string apellidos, string direccion, string telefono, string email, string  foto) : base(nombre, apellidos, direccion, telefono, email,foto) => CodTurista = codTurista;
    }
}
