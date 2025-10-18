namespace BackEnd_SistemaGestionContable.DTO.Usuarios
{
    public interface ICreateUsuariosRequest
    {
        int tipoIdentificacion_Id { get; set; }
        int tipo_Usuario_Id { get; set; }
        int genero_Id { get; set; }
        int ciudad_Id { get; set; }

        string? nombres { get; set; }
        string? apellidos { get; set; }
        string? numeroIdentificacion { get; set; }
        DateTime? fechaNacimiento { get; set; }
        string? telefono { get; set; }
        DateTime? fechaRegistro { get; set; }
        bool? activo { get; set; }

        string? correo { get; set; }
        string? contraseña { get; set; }
    }

    public class CreateUsuariosRequest
    {
        public int tipoIdentificacion_Id { get; set; }
        public int tipo_Usuario_Id { get; set; }
        public int genero_Id { get; set; }
        public int ciudad_Id { get; set; }

        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numeroIdentificacion { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string? telefono { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public bool? activo { get; set; }

        public string? correo { get; set; }
        public string? contraseña { get; set; }
    }
}
