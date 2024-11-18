using SurveyBasket.Contracts.Polls;
using SurveyBasket.Contracts.Questions;

namespace SurveyBasket.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<Poll, PollResponse>()
        //   .Map(dest => dest.Summary, src => src.Summary);

        config.NewConfig<QuestionRequest, Question>()
            .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));
    }
}
