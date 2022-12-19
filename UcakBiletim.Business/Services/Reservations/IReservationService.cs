using System.Collections.Generic;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Reservations
{
    public interface IReservationService : IService<Reservation>
    {
        List<Reservation> GetReservationsByUserId(int userId);
    }
}
