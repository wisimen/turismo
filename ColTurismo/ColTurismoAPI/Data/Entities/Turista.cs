using System.ComponentModel.DataAnnotations;

namespace ColTurismoAPI.Data.Entities
{
    public class Turista
    {
        [Key]
        public int CodTurista { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo de {0} no es una dirección de correo electrónico válida")]
        public string Email { get; set; }
        //Referencias
        public ICollection<ReservaVuelo> Vuelos { get; set; }
        public ICollection<ReservaHotel> Hoteles { get; set; }
        public ICollection<ContratoSucursal> Contratos  { get; set; }
    }
}
