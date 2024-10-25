using FluentValidation;
using Tarker.Booking.Application.Database.Bookings.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(booking => booking.Code).NotEmpty().NotNull().Length(8);
            RuleFor(booking => booking.Type).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(booking => booking.CustomerId).NotNull().GreaterThan(0);
            RuleFor(booking => booking.UserId).NotNull().GreaterThan(0);
        }
    }
}

