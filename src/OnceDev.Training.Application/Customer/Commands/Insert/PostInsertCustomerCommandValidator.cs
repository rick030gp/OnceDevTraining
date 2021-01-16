using FluentValidation;

namespace OnceDev.Training.Application.Customer.Commands.Insert
{
    public class PostInsertCustomerCommandValidator : AbstractValidator<PostInsertCustomerCommand>
    {
        public PostInsertCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Hola Error")
                .NotNull().WithMessage("Hola Error");
            RuleFor(c => c.LastName).NotEmpty().NotNull();
            RuleFor(c => c.City).NotEmpty().NotNull();
            RuleFor(c => c.Country).NotEmpty().NotNull();
            RuleFor(c => c.Phone)
                .NotEmpty()
                .NotNull()
                .Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
        }
    }
}
