using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(booking => booking.BookingId);
            entityBuilder.Property(booking => booking.RegisterDate).IsRequired();
            entityBuilder.Property(booking => booking.Code).IsRequired();
            entityBuilder.Property(booking => booking.Type).IsRequired();
            entityBuilder.Property(booking => booking.UserId).IsRequired();
            entityBuilder.Property(booking => booking.CustomerId).IsRequired();

            entityBuilder.HasOne(booking => booking.User).WithMany(booking => booking.Bookings).HasForeignKey(booking => booking.UserId);
            entityBuilder.HasOne(booking => booking.Customer).WithMany(booking => booking.Bookings).HasForeignKey(booking => booking.CustomerId);
        }
    }
}
