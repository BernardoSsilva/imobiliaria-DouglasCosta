using FluentValidation;
using ImmobileApp.Comunication.Requests;

namespace ImmobileApp.Aplication.Validators
{
    public class ImmobileValidator : AbstractValidator<ImmobileRequestJson>
    {
        public ImmobileValidator()
        {
            RuleFor(e => e.City).NotEmpty().WithMessage("Immobile city must be provided");
            RuleFor(e => e.HasScripture).NotNull().WithMessage("Immobile scripture status must be provided");
            RuleFor(e => e.ImmobileType).NotNull().WithMessage("Immobile type is required");
            RuleFor(e => e.PostalCode).NotEmpty().WithMessage("Immobile postal code is required");
            RuleFor(e => e.Status).NotNull().WithMessage("Immobile status is required");
        }
    }
}