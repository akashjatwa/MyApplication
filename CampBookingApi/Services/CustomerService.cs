using CampBookingApi.Data;
using CampBookingApi.Models;

namespace CampBookingApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();

        public Customer? GetById(int id) => _context.Customers.Find(id);

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer? Update(int id, Customer customer)
        {
            var existing = _context.Customers.Find(id);
            if (existing is null) return null;

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer is null) return false;
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
