namespace Zero.Core.Domain.Taxes
{
    public class Tax : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
