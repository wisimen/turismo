using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Data.Entities
{
    public class ContratoSucursal
    {
        [Key]
        [Column(Order = 1)]
        public int CodSucursal { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CodTurista { get; set; }
        //Referencias
        [ForeignKey("CodSucursal")]
        public Sucursal Sucursal { get; set; }
        [ForeignKey("CodTurista")]
        public Turista Turista { get; set; }
    }
}
