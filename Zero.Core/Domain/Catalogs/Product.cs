using Zero.Core.Domain.Taxes;

namespace Zero.Core.Domain.Catalogs
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncludedTax { get; set; }
        public bool Deleted { get; set; }

        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
