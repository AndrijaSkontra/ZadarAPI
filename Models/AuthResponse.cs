namespace ZadarAPI.Models;

public class AuthResponse
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string? Username { get; set; }
}