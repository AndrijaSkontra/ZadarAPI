using Microsoft.AspNetCore.Identity;

namespace ZadarAPI.Models;

public class Resident : IdentityUser
{
    public string CityNickname { get; set; }
}