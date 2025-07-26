using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Errors;

public static class UserError
{
    public static readonly Error InvalidUserId = new("User.InvalidId", "User ID not found in token.");
    public static readonly Error UserNotFound = new("User.NotFound", "User not found.");
}
