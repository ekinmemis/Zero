using System;
using System.Linq;
using System.Web.Mvc;
using Zero.Core.Domain.Customers;
using Zero.Service.Customers;
using Zero.Web.Models.Customer;

namespace Zero.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;


        public CustomerController()
        {
            _customerService = new CustomerService();
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new CustomerListModel());
        }

        [HttpPost]
        public ActionResult CustomerList(CustomerListModel model)
        {
            var customers = _customerService.GetAllCustomers(
                firstName: model.SearchFirstName,
                lastName: model.SearchLastName,
                email: model.SearchEmail,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = customers.TotalCount,
                data = customers
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Id = model.Id,
                    TurkishIdentityNumber = model.TurkishIdentityNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    PalceOfBirth = model.PalceOfBirth,
                    Active = model.Active,
                };

                _customerService.InsertCustomer(customer);

                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = customer.Id });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null || customer.Deleted)
                return RedirectToAction("List");

            var model = new CustomerModel()
            {
                Id = customer.Id,
                TurkishIdentityNumber = customer.TurkishIdentityNumber,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                PalceOfBirth = customer.PalceOfBirth,
                Active = customer.Active,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.GetCustomerById(model.Id);

                if (customer == null || customer.Deleted)
                    return RedirectToAction("List");

                customer.TurkishIdentityNumber = model.TurkishIdentityNumber;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Email = model.Email;
                customer.DateOfBirth = model.DateOfBirth;
                customer.PalceOfBirth = model.PalceOfBirth;
                customer.Active = model.Active;

                _customerService.UpdateCustomer(customer);

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("List");

            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
                return Json("ERR");

            customer.Deleted = true;

            _customerService.UpdateCustomer(customer);

            return Json("OK");
        }
    }
}