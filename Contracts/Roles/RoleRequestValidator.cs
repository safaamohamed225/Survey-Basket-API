namespace SurveyBasket.Contracts.Roles
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(r => r.Permissions)
                .NotNull()
                .NotEmpty();

            RuleForEach(r => r.Permissions)
                .Must(p=>p.Distinct().Count() == p.Count())
                .WithMessage("Permissions must be unique")
                .When(p => p.Permissions is not null);
        }
    }
}
