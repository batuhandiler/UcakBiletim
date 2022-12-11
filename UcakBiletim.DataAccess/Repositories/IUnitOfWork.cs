using System;
using System.Threading.Tasks;

namespace UcakBiletim.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
