using Zero.Core;
using Zero.Core.Domain.Customers;

namespace Zero.Service.Customers
{
    public interface ICustomerService
    {
        IPagedList<Customer> GetAllCustomers(string email = "",  string firstName = "", string lastName = "", int pageIndex = 0, int pageSize = int.MaxValue);

        Customer GetCustomerById(int id);

        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
