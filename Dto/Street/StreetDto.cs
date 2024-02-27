namespace ZadarAPI.Dto.Street;

public class StreetDto : BaseStreetDto
{
    public int Id { get; set; }
    public Models.Kvart kvart { get; set; }
}