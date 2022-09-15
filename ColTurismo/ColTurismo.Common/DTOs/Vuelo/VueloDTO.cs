namespace ColTurismo.Common.DTOs.Vuelo
{
    public class VueloDTO
    {
        public int NumeroVuelo { get; set; }
        
        public DateOnly Fecha { get; set; }
        
        public TimeOnly Hora { get; set; }
        
        public string Origen { get; set; }
        
        public string Destino { get; set; }
        
        public int PlazaTotal { get; set; }
        
        public int PlazaTurista { get; set; }
    }
}
