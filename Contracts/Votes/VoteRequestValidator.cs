namespace SurveyBasket.Contracts.Votes
{
    public class VoteRequestValidator : AbstractValidator<VoteRequest>
    {
        public VoteRequestValidator()
        {
            RuleFor(v => v.Answers)
                .NotEmpty();

            RuleForEach(a=>a.Answers)
                .SetInheritanceValidator(v=>v.Add(new VoteAnswerRequestValidator()));
        }
    }
}
