using ZadarAPI.Contracts;
using ZadarAPI.Models;

namespace ZadarAPI.Repository;

public class KvartRepository : GenericRepository<Kvart>, IKvartRepository
{
    public KvartRepository(ZadarContext context) : base(context)
    {
    }
    
}