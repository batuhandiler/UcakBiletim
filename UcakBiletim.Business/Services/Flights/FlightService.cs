using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UcakBiletim.DataAccess.Repositories;
using UcakBiletim.DataAccess.Repositories.Flights;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Flights
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFlightRepository _flightRepository;

        public FlightService(IUnitOfWork unitOfWork, IFlightRepository flightRepository)
        {
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }

        public async Task AddAsync(Flight data)
        {
            await _flightRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _flightRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<Flight>> GetAllAsync()
        {
            var entities = _flightRepository.GetAll();
            return await entities.ToListAsync();
        }

        public Flight GetById(int id)
        {
            var entity = _flightRepository
                 .FindBy(x => x.Id == id)
                 .FirstOrDefault();
            return entity;
        }

        public List<Flight> GetDepartureFlights(string from, string to, DateTime date)
        {
            var flights = _flightRepository
                 .FindBy(x => x.From == from && x.To == to && x.Date.Date == date.Date.Date).ToList();
            return flights;
        }

        public List<Flight> GetReturnFlights(string to, string from, DateTime date)
        {
            var flights = _flightRepository
                 .FindBy(x => x.From == to && x.To == from && x.Date.Date == date.Date).ToList();
            return flights;
        }

        public async Task UpdateAsync(Flight data)
        {
            _flightRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }
    }
}
