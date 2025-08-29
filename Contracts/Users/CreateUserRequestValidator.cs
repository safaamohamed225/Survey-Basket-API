using SurveyBasket.Abstractions.Consts;

namespace SurveyBasket.Contracts.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
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
           
            RuleFor(p => p.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage("Password should be at least 8 digits and contains lowercase and uppercase");

            RuleFor(r => r.Roles)
                .NotNull()
                .NotEmpty();

            RuleFor(r=>r.Roles)
                .Must(r => r.Distinct().Count() == r.Count)
                .WithMessage("You cannot add duplicated role to the same user")
                .When(r=>r.Roles!=null);
        }
    }
}
