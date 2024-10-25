using FluentValidation;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(customer => customer.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(customer => customer.FullName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(customer => customer.DocumentNumber).NotEmpty().NotNull().Length(8);
        }
    }
}
