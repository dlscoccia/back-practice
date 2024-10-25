using FluentValidation;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(customer => customer.FullName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(customer => customer.DocumentNumber).NotEmpty().NotNull().Length(8);
        }
    }
}
