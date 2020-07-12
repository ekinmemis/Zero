using Zero.Core;
using Zero.Core.Domain.Employees;

namespace Zero.Service.Employees
{
    public interface IEmployeeService
    {
        IPagedList<Employee> GetAllEmployees(string email = "", string title = "", string firstName = "", string lastName = "", int pageIndex = 0, int pageSize = int.MaxValue);

        Employee GetEmployeeById(int id);

        void InsertEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
