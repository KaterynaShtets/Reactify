using DAL.EFCore;
using Shared.Models;

namespace ReactifyAPI.Repositories
{
    public class IndicatorsRepository : Repository<Indicators, ApplicationDbContext>
    {
        public IndicatorsRepository(ApplicationDbContext context) : base(context) { }
    }
}