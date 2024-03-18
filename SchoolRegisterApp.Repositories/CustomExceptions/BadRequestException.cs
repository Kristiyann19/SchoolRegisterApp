namespace SchoolRegisterApp.Repositories.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        { }
    }
}
