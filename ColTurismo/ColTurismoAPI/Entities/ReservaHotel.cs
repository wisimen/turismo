using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Entities
{
    public class ReservaHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodReserva { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodHotel { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CodTurista { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaEntrada { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Regimen { get; set; }

        //Referencias
        [ForeignKey("CodHotel")]
        public Hotel Hotel { get; set; }
        
        [ForeignKey("CodTurista")]
        public Turista Turista { get; set; }
    }
}
