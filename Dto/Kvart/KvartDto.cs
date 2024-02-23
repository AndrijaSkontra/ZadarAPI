using ZadarAPI.Models;

namespace ZadarAPI.Dto.Kvart;

public class KvartDto : BaseKvartDto
{
    public int Id { get; set; }
    public IList<Street> Streets { get; set; }
}