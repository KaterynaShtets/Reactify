

using DAL.EFCore;
using Shared.Models;

namespace ReactifyAPI.Repositories
{
    public class IndicatorsInfoRepository : Repository<IndicatorsInfo, ApplicationDbContext>
    {
        public IndicatorsInfoRepository(ApplicationDbContext context) : base(context) { }
    }
}