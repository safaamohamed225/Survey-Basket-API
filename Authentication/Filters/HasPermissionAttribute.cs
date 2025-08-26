using Microsoft.AspNetCore.Authorization;

namespace SurveyBasket.Authentication.Filters
{
    public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
    {
    }
}
