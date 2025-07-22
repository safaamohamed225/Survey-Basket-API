namespace SurveyBasket.Contracts.Votes
{
    public class VoteAnswerRequestValidator : AbstractValidator<VoteAnswerRequest>
    {
        public VoteAnswerRequestValidator()
        {
            RuleFor(v => v.QuestionId)
                .GreaterThan(0);

            RuleFor(v => v.AnswerId)
                .GreaterThan(0);
        }
    }
}
