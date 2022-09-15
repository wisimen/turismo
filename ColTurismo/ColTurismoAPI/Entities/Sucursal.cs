using System.ComponentModel.DataAnnotations;

namespace ColTurismoAPI.Entities
{
    public class Sucursal
    {
        [Key]
        public int CodSucursal { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }
        //Referencias
        public ICollection<ContratoSucursal> Contratos { get; set; }
    }
}
