namespace Projekt_Inzynierski.Core.Exceptions
{
    public class EmailIsTakenException : Exception
    {
        public EmailIsTakenException(string message) : base(message) { }
    }
}
