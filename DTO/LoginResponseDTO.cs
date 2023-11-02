namespace MeuBancoBackend.DTO
{
    public class LoginResponseDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
