namespace SurveyBasket.Contracts.Users
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {

            RuleFor(f => f.FirstName)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(l => l.LastName)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Roles)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Roles)
                .Must(r => r.Distinct().Count() == r.Count)
                .WithMessage("You cannot add duplicated role to the same user")
                .When(r => r.Roles != null);
        }
    }
}
