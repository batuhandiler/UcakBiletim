using System;
using UcakBiletim.Core.Entities;

namespace UcakBiletim.Entities.Concrete
{
    public class Flight : IEntity
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public decimal BusinessClassPrice { get; set; }
        public decimal EconomyClassPrice { get; set; }
    }
}
