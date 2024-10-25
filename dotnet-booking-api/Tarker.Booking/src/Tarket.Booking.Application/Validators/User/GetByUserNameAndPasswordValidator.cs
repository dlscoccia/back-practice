using FluentValidation;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetByUserNameAndPasswordValidator : AbstractValidator<(string, string)>
    {
        public GetByUserNameAndPasswordValidator()
        {
            RuleFor(user => user.Item1).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(user => user.Item2).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
