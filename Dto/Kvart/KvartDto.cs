using ZadarAPI.Models;

namespace ZadarAPI.Dto.Kvart;

public class KvartDto : BaseKvartDto
{
    public int Id { get; set; }
    public IList<Models.Street> Streets { get; set; }
}