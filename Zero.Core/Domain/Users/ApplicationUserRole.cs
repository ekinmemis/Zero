namespace Zero.Core.Domain.Users
{
    public class ApplicationUserRole : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool SystemRole { get; set; }
        public string SystemName { get; set; }
    }
}