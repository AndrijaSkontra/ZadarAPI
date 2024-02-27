using System.ComponentModel.DataAnnotations;

namespace ZadarAPI.Dto.Kvart;

public abstract class BaseKvartDto
{
    [Required]
    public string Name { get; set; }
    public string LifeQuality { get; set; }
}