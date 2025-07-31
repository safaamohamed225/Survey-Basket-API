namespace SurveyBasket.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvalidCredentials", "Invalid email/password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
        new("User.InvalidJwtToken", "Invalid Jwt token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);
    public static readonly Error DublicatedEmail =
        new("User.DublicatedEmail", "This email is already exists!", StatusCodes.Status409Conflict);

    public static readonly Error EmailNotConfirmed =
    new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidCode =
   new("User.InvalidCode", "Invalid code", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedEmailConfirmation =
   new("User.DuplicatedEmailConfirmation", "Email is already confirmed", StatusCodes.Status400BadRequest);
}