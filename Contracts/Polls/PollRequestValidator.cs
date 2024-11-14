namespace SurveyBasket.Contracts.Polls;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(3, 50);

        RuleFor(x => x.Summary)
             .NotEmpty()
             .Length(5, 100);
        RuleFor(x => x.StartsAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
        RuleFor(x => x)
            .Must(HasValidDate)
            .WithName(nameof(Poll.EndsAt))
            .WithMessage("{PropertyName} must be greater than or equal to start Date");

    }

    private bool HasValidDate(PollRequest pollRequest)
    {
        return pollRequest.EndsAt >= pollRequest.StartsAt;
    }


}
