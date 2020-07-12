namespace Zero.Core.Domain.Settings
{
    public class TaxSetting : BaseEntity
    {
        public bool Deleted { get; set; }
        public int DefaultTaxId { get; set; }
    }
}
