namespace Portal.API.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}