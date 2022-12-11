using System.Threading.Tasks;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Users
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserAsync(User user);
        Task<bool> IsUserExist(User user);
        Task<bool> IsUserCanSignIn(User user);
    }
}
