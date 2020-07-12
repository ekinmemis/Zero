using Zero.Core;
using Zero.Core.Domain.Catalogs;

namespace Zero.Service.Products
{
    public interface IProductService
    {
        IPagedList<Product> GetAllProducts(string name = "", int pageIndex = 0, int pageSize = int.MaxValue);

        Product GetProductById(int id);

        void InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
