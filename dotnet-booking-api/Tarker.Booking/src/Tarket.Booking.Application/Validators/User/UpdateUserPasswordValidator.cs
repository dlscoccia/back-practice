using FluentValidation;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(user => user.UserId).NotNull().GreaterThan(0);
            RuleFor(user => user.Password).NotEmpty().NotNull().MaximumLength(10);
        }
    }
}
