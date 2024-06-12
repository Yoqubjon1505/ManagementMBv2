namespace ManagementMB.CQRS.Commands
{
    public class UpdateWorkerCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserStatus { get; set; } = string.Empty;
    }
}
