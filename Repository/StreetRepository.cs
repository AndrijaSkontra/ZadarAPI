using ZadarAPI.Contracts;
using ZadarAPI.Models;

namespace ZadarAPI.Repository;

public class StreetRepository : GenericRepository<Street>, IStreetRepository
{
    public StreetRepository(ZadarContext context) : base(context)
    {
    }
}