using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.email).NotEmpty();
            RuleFor(u=>u.password).NotEmpty().MinimumLength(4);
        }

    }

}
