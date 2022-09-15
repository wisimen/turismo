using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismo.Common.DTOs.ReservaVuelo
{
    public class ReservaVueloDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int NumeroVuelo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
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
