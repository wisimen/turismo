namespace ColTurismo.Common.DTOs.ReservaHotel
{
    public class ReservaHotelDTO
    {
        public int CodReserva { get; set; }
        
        public int CodHotel { get; set; }
        
        public int CodTurista { get; set; }
        
        public DateTime FechaEntrada { get; set; }
        
        public DateTime FechaSalida { get; set; }

        public string Regimen { get; set; }
    }
}
