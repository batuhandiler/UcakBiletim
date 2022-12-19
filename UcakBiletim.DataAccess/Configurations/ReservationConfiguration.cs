using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.DepartureFlightId)
                .HasDefaultValue(0);

            builder.Property(x => x.ReturnFlightId)
                 .HasDefaultValue(0);

            builder.Property(x => x.ReservationNo)
                .HasDefaultValue(Guid.Empty);
        }
    }
}
