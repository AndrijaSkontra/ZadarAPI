using System.ComponentModel.DataAnnotations.Schema;

namespace ZadarAPI.Models;

public class Street
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfHomes { get; set; }
    public float Lenght { get; set; }
    [ForeignKey(nameof(KvartId))]
    public int KvartId { get; set; }
    public Kvart Kvart { get; set; }
}