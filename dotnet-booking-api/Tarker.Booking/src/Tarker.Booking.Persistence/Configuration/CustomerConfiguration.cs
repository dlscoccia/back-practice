using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder) {
            entityBuilder.HasKey(customer => customer.CustomerId);
            entityBuilder.Property(customer => customer.FullName).IsRequired();
            entityBuilder.Property(customer => customer.DocumentNumber).IsRequired();

            entityBuilder.HasMany(customer => customer.Bookings).WithOne(customer => customer.Customer).HasForeignKey(customer => customer.CustomerId);
        }
    }
}
