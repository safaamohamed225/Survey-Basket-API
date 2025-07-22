using System.Data;

namespace SurveyBasket.Contracts.Results
{
    public record VoteResponse
      (
        string VoterName,
        DateTime VoteDate,
        IEnumerable<QuestionAnswerResponse> SelectedAnswers

        );
}
