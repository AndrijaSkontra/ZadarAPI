namespace ZadarAPI.Models;

public class Kvart
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LifeQuality { get; set; }
    public IList<Street> Streets { get; set; }
}