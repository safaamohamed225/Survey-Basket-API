namespace SurveyBasket.Authentication;

public interface IJwtProvider
{
    (string token, int expillresIn) GenerateToken(ApplicationUser user);

    string? ValidateToken(string token);
}
