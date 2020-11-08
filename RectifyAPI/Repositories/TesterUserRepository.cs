using DAL.EFCore;
using Shared.Models;

namespace ReactifyAPI.Repositories
{
    public class TesterUserRepository : Repository<TesterUser, ApplicationDbContext>
    {
        public TesterUserRepository(ApplicationDbContext context) : base(context) { }
    }
}