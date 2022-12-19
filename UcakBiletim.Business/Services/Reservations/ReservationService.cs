using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UcakBiletim.DataAccess.Repositories;
using UcakBiletim.DataAccess.Repositories.Reservations;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
        }

        public Reservation GetById(int id)
        {
            var entity = _reservationRepository
                .FindBy(x => x.Id == id)
                .FirstOrDefault();
            return entity;
        }

        public async Task AddAsync(Reservation data)
        {
            await _reservationRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _reservationRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Reservation data)
        {
            _reservationRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<Reservation>> GetAllAsync()
        {
            var entities = _reservationRepository.GetAll();

            entities = entities.Include(x => x.DepartureFlight);
            entities = entities.Include(x => x.ReturnFlight);

            return await entities.ToListAsync();
        }

        public List<Reservation> GetReservationsByUserId(int userId)
        {
            var reservations = _reservationRepository
                .FindBy(x => x.UserId == userId);

            reservations = reservations.Include(x => x.DepartureFlight);
            reservations = reservations.Include(x => x.ReturnFlight);

            return reservations.ToList();
        }
    }
}
