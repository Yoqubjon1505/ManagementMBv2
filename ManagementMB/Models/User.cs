namespace ManagementMB.Models
{
    public abstract class User:BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public bool IsBlocked { get; }
        public bool Functionality { get; set; }
        public string UserStatus { get; set; } = string.Empty;
    }
}
