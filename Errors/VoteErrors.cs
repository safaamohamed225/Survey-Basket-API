namespace SurveyBasket.Errors;

public class VoteErrors
{
    public static readonly Error DuplicatedVote =
     new("Vote.DuplicatedVote", "This user voted before on this Poll!");
}
