using UcakBiletim.DataAccess.Contexts;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.DataAccess.Repositories.Flights
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private readonly UcakBiletimContext _context;

        public FlightRepository(UcakBiletimContext context) : base(context)
        {
            _context = context;
        }
    }
}
