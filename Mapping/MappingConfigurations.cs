using SurveyBasket.Contracts.Polls;
using SurveyBasket.Contracts.Questions;
using SurveyBasket.Contracts.Users;

namespace SurveyBasket.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<QuestionRequest, Question>()
            .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));

        config.NewConfig<RegisterRequest, ApplicationUser>()
            .Map(dest => dest.UserName, src => src.Email);
        config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
            .Map(dest=>dest, src=>src.user)
            .Map(dest=>dest.Roles, src=>src.roles);
    }
}
