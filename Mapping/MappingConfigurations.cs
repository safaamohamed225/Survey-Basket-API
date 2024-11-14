using SurveyBasket.Contracts.Polls;

namespace SurveyBasket.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Poll, PollResponse>()
           .Map(dest => dest.Summary, src => src.Summary);
    }
}
