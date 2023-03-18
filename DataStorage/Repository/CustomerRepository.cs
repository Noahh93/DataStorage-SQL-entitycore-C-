using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;

namespace Pre_Assignment.Repository
{
    public class CustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository() 
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();

            return customers;
        }
        public Customer GetCustomerByID(int CustomerID)
        {
            Customer customer = _context.Customers.Where(x => x.ID == CustomerID).FirstOrDefault();
            return customer;
        }
        public bool DeleteCustomerByID(int customerID)
        {
            Customer customer = _context.Customers.Where(x => x.ID == customerID).FirstOrDefault();
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateCustomerByID(int customerID, string customerFirstName, string customerEmail, string customerPhone, string customerLastName)
        {
            Customer customerEntity = _context.Customers.Where(x => x.ID == customerID).FirstOrDefault();
            if (customerEntity != null)
            {
                customerEntity.FirstName = customerFirstName;
                customerEntity.LastName = customerLastName;
                customerEntity.Email = customerEmail;
                customerEntity.Phone = customerPhone;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
