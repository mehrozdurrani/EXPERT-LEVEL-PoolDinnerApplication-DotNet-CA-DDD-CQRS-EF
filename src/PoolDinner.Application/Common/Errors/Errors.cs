using System.Net;

namespace PoolDinner.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public string ErrorMessage => "User Already Exists";
    }

    public class WrongUsernameOrPasswordException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public string ErrorMessage => "Wrong Username or Password";
    }

    public class UserDoesntExistsException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public string ErrorMessage => "User Doesnt Exists";
    }

    public class InvalidRegisterInputException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Invalid Registeration Input";
    }
}
