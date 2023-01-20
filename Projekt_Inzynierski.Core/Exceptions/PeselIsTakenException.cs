namespace Projekt_Inzynierski.Core.Exceptions
{
    public class PeselIsTakenException : Exception
    {
        public PeselIsTakenException(string message) : base (message) { }
    }
}
