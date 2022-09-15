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

        public TuristaDTO(int codTurista, string nombre, string apellidos, string direccion, string telefono, string email , string foto)
        {
            CodTurista = codTurista;
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Foto = foto;    
        }

        public TuristaDTO(string nombre, string apellidos, string direccion, string telefono, string email, string foto)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Foto = foto;
        }
    }
}
