using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Employees;
using Zero.Data.EfRepository;

namespace Zero.Service.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository;

        public EmployeeService()
        {
            this._employeeRepository = new Repository<Employee>();
        }

        public IPagedList<Employee> GetAllEmployees(string email = "",string title = "", string firstName = "", string lastName = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _employeeRepository.Table;

            if (!string.IsNullOrEmpty(email))
                query = query.Where(a => a.Email.Contains(email));

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(a => a.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(a => a.LastName.Contains(lastName));

            query = query.Where(f => f.Deleted == false);

            query = query.OrderBy(o => o.Id);

            var employees = new PagedList<Employee>(query, pageIndex, pageSize);

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {

            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var employee = _employeeRepository.GetById(id);

            return employee;
        }

        public void InsertEmployee(Employee employee)
        {
            if (employee == null)
                throw (new ArgumentNullException("parameter missing"));

            _employeeRepository.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw (new ArgumentNullException("parameter missing"));

            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw (new ArgumentNullException("parameter missing"));

            _employeeRepository.Delete(employee);
        }
    }
}
