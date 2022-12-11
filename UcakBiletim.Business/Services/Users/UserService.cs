using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UcakBiletim.DataAccess.Repositories;
using UcakBiletim.DataAccess.Repositories.Users;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public User GetById(int id)
        {
            var entity = _userRepository
                .FindBy(x => x.Id == id)
                .FirstOrDefault();
            return entity;
        }

        public async Task AddAsync(User data)
        {
            await _userRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _userRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(User data)
        {
            _userRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            var entities = _userRepository.GetAll();
            return await entities.ToListAsync();
        }

        public async Task<bool> IsUserExist(User user)
        {
            var isExist = await _userRepository.IsExistAsync(x => x.Mail == user.Mail);
            return isExist;
        }

        public async Task<bool> IsUserCanSignIn(User user)
        {
            var isUserCanSignIn = await _userRepository.IsExistAsync(x => x.Mail == user.Mail && x.Password == user.Password);
            return isUserCanSignIn;
        }

        public async Task<User> GetUserAsync(User user)
        {
            var entity = _userRepository
                .FindBy(x => x.Mail == user.Mail && x.Password == user.Password)
                .FirstOrDefault();
            return entity;
        }
    }
}
