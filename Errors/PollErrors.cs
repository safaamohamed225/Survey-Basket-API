namespace SurveyBasket.Errors;

public class PollErrors
{
    public static readonly Error PollNotFound =
     new("Poll.NotFound", "No poll was found with the given ID");

    public static readonly Error DuplicatedPollTitle =
     new("Poll.DuplicatedTitle", "There is another poll with the same title!");
}

