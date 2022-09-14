using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Data.Entities
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
        public string FechaEntrada { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FechaSalida { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Regimen { get; set; }

        //Referencias
        [ForeignKey("CodHotel")]
        public Hotel Hotel { get; set; }
        [ForeignKey("CodTurista")]
        public Turista Turista { get; set; }
    }
}
