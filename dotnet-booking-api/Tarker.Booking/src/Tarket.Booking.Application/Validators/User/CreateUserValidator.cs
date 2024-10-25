using FluentValidation;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
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
