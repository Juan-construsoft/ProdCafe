namespace HipatiaVentas.Domain.Dtos
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? TokenType { get; set; }
        public string? ExpiresIn { get; set; }
    }
}
