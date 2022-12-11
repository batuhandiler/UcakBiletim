using System.Threading.Tasks;
using UcakBiletim.DataAccess.Contexts;

namespace UcakBiletim.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UcakBiletimContext _context;

        public UnitOfWork(UcakBiletimContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
