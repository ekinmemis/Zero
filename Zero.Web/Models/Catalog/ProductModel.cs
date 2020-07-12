using System;

namespace Zero.Web.Models.Catalog
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncludedTax { get; set; }
    }
}