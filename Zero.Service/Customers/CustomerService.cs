using System;
using System.Linq;
using Zero.Core;
using Zero.Core.Domain.Customers;
using Zero.Data.EfRepository;

namespace Zero.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            this._customerRepository = new Repository<Customer>();
        }

        public IPagedList<Customer> GetAllCustomers(string email = "",  string firstName = "", string lastName = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _customerRepository.Table;

            if (!string.IsNullOrEmpty(email))
                query = query.Where(a => a.Email.Contains(email));

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(a => a.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(a => a.LastName.Contains(lastName));

            query = query.Where(f => f.Deleted == false);

            query = query.OrderBy(o => o.Id);

            var customers = new PagedList<Customer>(query, pageIndex, pageSize);

            return customers;
        }

        public Customer GetCustomerById(int id)
        {

            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var customer = _customerRepository.GetById(id);

            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw (new ArgumentNullException("parameter missing"));

            _customerRepository.Insert(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw (new ArgumentNullException("parameter missing"));

            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw (new ArgumentNullException("parameter missing"));

            _customerRepository.Delete(customer);
        }
    }
}
