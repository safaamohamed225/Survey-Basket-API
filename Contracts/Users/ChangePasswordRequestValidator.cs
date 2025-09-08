namespace SurveyBasket.Contracts.Users
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty();

            RuleFor(x => x.NewPassword)
             .NotEmpty()
             .Matches(RegexPatterns.Password)
             .WithMessage("Password should be at least 8 digits and contains lowercase and uppercase")
             .NotEqual(x => x.CurrentPassword)
             .WithMessage("New password cannot eqaul cuurnt password");
        }
    }
}
