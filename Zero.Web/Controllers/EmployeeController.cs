using System.Web.Mvc;
using Zero.Core.Domain.Employees;
using Zero.Service.Employees;
using Zero.Web.Models.Employee;

namespace Zero.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;


        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new EmployeeListModel());
        }

        [HttpPost]
        public ActionResult EmployeeList(EmployeeListModel model)
        {
            var employees = _employeeService.GetAllEmployees(
                email:model.SearchEmail,
                firstName: model.SearchFirstName,
                lastName: model.SearchLastName,
                title: model.SearchTitle,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = employees.TotalCount,
                data = employees
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    TurkishIdentityNumber = model.TurkishIdentityNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email=model.Email,
                    Title=model.Title,
                    Sallary = model.Sallary,
                    DateOfBirth = model.DateOfBirth,
                    PalceOfBirth = model.PalceOfBirth,
                    Active = model.Active,
                };

                _employeeService.InsertEmployee(employee);


                if (string.IsNullOrEmpty(Request["saveandcontinue"]))
                    return RedirectToAction("List");

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("Edit", new { id = employee.Id });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null || employee.Deleted)
                return RedirectToAction("List");

            var model = new EmployeeModel()
            {
                Id = employee.Id,
                TurkishIdentityNumber = employee.TurkishIdentityNumber,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Title = employee.Title,
                Sallary=employee.Sallary,
                PalceOfBirth = employee.PalceOfBirth,
                DateOfBirth = employee.DateOfBirth,
                Active = employee.Active,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetEmployeeById(model.Id);

                if (employee == null || employee.Deleted)
                    return RedirectToAction("List");

                employee.TurkishIdentityNumber = model.TurkishIdentityNumber;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Email = model.Email;
                employee.Title = model.Title;
                employee.Sallary = model.Sallary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.PalceOfBirth = model.PalceOfBirth;
                employee.Active = model.Active;

                _employeeService.UpdateEmployee(employee);

                if (string.IsNullOrEmpty(Request["save"]))
                    return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
                return Json("ERR");

            employee.Deleted = true;

            _employeeService.UpdateEmployee(employee);

            return Json("OK");
        }
    }
}