using FluentValidation;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.UserId).NotNull().GreaterThan(0);
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(user => user.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(user => user.UserName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(user => user.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10);
        }
    }
}
