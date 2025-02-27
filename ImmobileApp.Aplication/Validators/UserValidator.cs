using FluentValidation;
using ImmobileApp.Comunication.Requests;

namespace ImmobileApp.Aplication.Validators
{
    public class UserValidator:AbstractValidator<UserRequestJson>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(u => u.UserEmail).NotEmpty().WithMessage("User Email address is required");
            RuleFor(u => u.UserEmail).EmailAddress().WithMessage("Invalid email");
            RuleFor(u => u.Role).NotEmpty().WithMessage("User role is required");
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(8).WithMessage("User password must have 8 or more characters");
        }
    }
}
