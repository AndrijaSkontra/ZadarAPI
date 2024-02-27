using System.ComponentModel.DataAnnotations.Schema;

namespace ZadarAPI.Dto.Street;

public abstract class BaseStreetDto
{
    public string Name { get; set; }
    public int NumberOfHomes { get; set; }
    public float? Lenght { get; set; }
    [ForeignKey(nameof(KvartId))]
    public int KvartId { get; set; }
}