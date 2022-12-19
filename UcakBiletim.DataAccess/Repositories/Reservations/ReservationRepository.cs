using UcakBiletim.DataAccess.Contexts;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.DataAccess.Repositories.Reservations
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly UcakBiletimContext _context;

        public ReservationRepository(UcakBiletimContext context) : base(context)
        {
            _context = context;
        }
    }
}
