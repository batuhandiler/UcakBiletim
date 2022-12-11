using UcakBiletim.DataAccess.Contexts;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.DataAccess.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UcakBiletimContext _context;

        public UserRepository(UcakBiletimContext context) : base(context)
        {
            _context = context;
        }
    }
}
