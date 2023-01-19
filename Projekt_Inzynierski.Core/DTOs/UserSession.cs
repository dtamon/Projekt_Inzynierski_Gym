namespace Projekt_Inzynierski.Core.DTOs
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }

    }
}
