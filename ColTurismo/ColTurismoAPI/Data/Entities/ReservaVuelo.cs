using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Data.Entities
{
    public class ReservaVuelo
    {
        [Key]
        [Column(Order = 1)]
        public int NumeroVuelo { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CodTurista { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Clase { get; set; }
        //Referencias
        [ForeignKey("NumeroVuelo")]
        public Vuelo Vuelo { get; set; }
        [ForeignKey("CodTurista")]
        public Turista Turista { get; set; }
    }
}
