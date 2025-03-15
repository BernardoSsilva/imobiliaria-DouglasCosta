using FluentValidation;
using ImmobileApp.Comunication.Requests;

namespace ImmobileApp.Aplication.Validators
{
    public class UserValidator : AbstractValidator<UserRequestJson>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(u => u.UserEmail).NotEmpty().WithMessage("User Email address is required");
            RuleFor(u => u.UserEmail).EmailAddress().WithMessage("Invalid email");
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("User password must have 8 or more characters");
            RuleFor(u => u.Role).NotEmpty().WithMessage("User role is required");
            RuleFor(u => u.Phone).NotEmpty().WithMessage("User phone is required");
            RuleFor(u => u.BornDate).NotEmpty().WithMessage("User born date is required");
            RuleFor(u => u.CivilState).NotEmpty().WithMessage("User civil state is required");
        }
    }
}
