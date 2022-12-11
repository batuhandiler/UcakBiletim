using System.Collections.Generic;
using System.Threading.Tasks;
using UcakBiletim.Core.Entities;

namespace UcakBiletim.Business.Services
{
    public interface IService<T> where T : class, IEntity, new()
    {
        T GetById(int id);
        Task AddAsync(T data);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(T data);
        Task<IList<T>> GetAllAsync();
    }
}
