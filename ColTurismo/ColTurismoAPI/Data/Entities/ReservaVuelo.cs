using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Data.Entities
{
    public class ReservaVuelo
    {
        public int NumeroVuelo { get; set; }
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
