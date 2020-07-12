using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Catalogs;
using Zero.Data.EfRepository;

namespace Zero.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService()
        {
            this._productRepository = new Repository<Product>();
        }

        public IPagedList<Product> GetAllProducts(string name, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _productRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.Where(f => f.Deleted == false);

            query = query.OrderBy(o => o.Id);

            var products = new PagedList<Product>(query, pageIndex, pageSize);

            return products;
        }

        public Product GetProductById(int id)
        {

            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var product = _productRepository.GetById(id);

            return product;
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw (new ArgumentNullException("parameter missing"));

            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw (new ArgumentNullException("parameter missing"));

            _productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
                throw (new ArgumentNullException("parameter missing"));

            _productRepository.Delete(product);
        }
    }
}
