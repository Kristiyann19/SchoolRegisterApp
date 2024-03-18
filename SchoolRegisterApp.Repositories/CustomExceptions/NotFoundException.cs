namespace SchoolRegisterApp.Repositories.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        { }
    }
}
