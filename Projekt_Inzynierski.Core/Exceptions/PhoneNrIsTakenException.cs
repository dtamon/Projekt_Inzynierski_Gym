namespace Projekt_Inzynierski.Core.Exceptions
{
    public class PhoneNrIsTakenException : Exception
    {
        public PhoneNrIsTakenException(string message) : base(message) { }
    }
}
