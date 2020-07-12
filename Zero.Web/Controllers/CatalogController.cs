using System.Web.Mvc;
using Zero.Core.Domain.Catalogs;
using Zero.Service.Products;
using Zero.Web.Models.Catalog;

namespace Zero.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;


        public CatalogController()
        {
            _productService = new ProductService();
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new ProductListModel());
        }

        [HttpPost]
        public ActionResult ProductList(ProductListModel model)
        {
            var products = _productService.GetAllProducts(
                name: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = products.TotalCount,
                data = products
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    PriceIncludedTax = model.PriceIncludedTax,
                    ShortDescription = model.ShortDescription,
                };

                _productService.InsertProduct(product);

                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = product.Id });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null || product.Deleted)
                return RedirectToAction("List");

            var model = new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PriceIncludedTax = product.PriceIncludedTax,
                ShortDescription = product.ShortDescription,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetProductById(model.Id);

                if (product == null || product.Deleted)
                    return RedirectToAction("List");

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.PriceIncludedTax = model.PriceIncludedTax;
                product.ShortDescription = model.ShortDescription;

                //product.UserName = model.UserName;

                _productService.UpdateProduct(product);

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = product.Id });

                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return Json("ERR");

            product.Deleted = true;

            _productService.UpdateProduct(product);

            return Json("OK");
        }
    }
}