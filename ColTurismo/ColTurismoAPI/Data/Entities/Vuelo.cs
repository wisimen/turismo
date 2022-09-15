using System.ComponentModel.DataAnnotations;

namespace ColTurismoAPI.Data.Entities
{
    public class Vuelo
    {
        [Key]
        public int NumeroVuelo { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateOnly Fecha { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public TimeOnly Hora { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Origen { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Destino { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PlazaTotal { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PlazaTurista { get; set; }
        
        //Referencias
        public ICollection<ReservaVuelo> ReservaVuelo { get; set; }
    }
}
