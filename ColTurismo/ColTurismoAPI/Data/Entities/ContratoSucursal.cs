using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismoAPI.Data.Entities
{
    public class ContratoSucursal
    {
        public int CodSucursal { get; set; }
        public int CodTurista { get; set; }
        //Referencias
        [ForeignKey("CodSucursal")]
        public Sucursal Sucursal { get; set; }
        [ForeignKey("CodTurista")]
        public Turista Turista { get; set; }
    }
}
