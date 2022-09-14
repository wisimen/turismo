using System.ComponentModel.DataAnnotations;

namespace ColTurismoAPI.Data.Entities
{
    public class Hotel
    {
        [Key]
        public int CodHotel { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode ter mais de {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int NumPlazas { get; set; }
        //Referencias
        public ICollection<ReservaHotel> ReservaHotel { get; set; }
    } 
}
