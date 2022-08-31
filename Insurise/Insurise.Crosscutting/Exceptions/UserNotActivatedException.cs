using System.Security.Authentication;

namespace Insurise.Crosscutting.Exceptions;

public class UserNotActivatedException : AuthenticationException
{
    public UserNotActivatedException(string message) : base(message)
    {
    }
}