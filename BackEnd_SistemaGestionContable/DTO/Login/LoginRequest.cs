namespace BackEnd_SistemaGestionContable.DTO.Login
{
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    // DTO para la respuesta de autenticación con información adicional del usuario
    public class LoginResponse
    {
        public string Correo { get; set; }
        public int TipoUsuarioId { get; set; } // Tipo de usuario
        public bool IsAuthenticated { get; set; }
    }
}
