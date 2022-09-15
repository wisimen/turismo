namespace ColTurismo.Common.DTOs.Turista
{
    public class TuristaDTO
    {
        public int CodTurista { get; internal set; }

        public string Nombre { get; internal set; }

        public string Apellidos { get; internal set; }

        public string Direccion { get; internal set; }

        public string Telefono { get; internal set; }

        public string Email { get; internal set; }
        
        public string Foto { get; set; }
    }
}
