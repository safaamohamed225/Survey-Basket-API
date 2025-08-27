namespace SurveyBasket.Errors
{
    public static class RoleErrors
    {
        public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "Role is not found", StatusCodes.Status404NotFound);

        public static readonly Error RoleAlreadyExists =
            new("Role.RoleAlreadyExists", "Role with the same name already exists", StatusCodes.Status409Conflict);
        public static readonly Error InvalidPermissions =
            new("Role.InvalidPermissions", "One or more permissions are invalid", StatusCodes.Status400BadRequest);
    }
}
