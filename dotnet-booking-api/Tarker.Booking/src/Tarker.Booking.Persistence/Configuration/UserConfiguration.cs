using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(user => user.UserId);
            entityBuilder.Property(user => user.FirstName).IsRequired();
            entityBuilder.Property(user => user.LastName).IsRequired();
            entityBuilder.Property(user => user.UserName).IsRequired();
            entityBuilder.Property(user => user.Password).IsRequired();

            entityBuilder.HasMany(user => user.Bookings).WithOne(user => user.User).HasForeignKey(user => user.UserId);
        }
    }
}
