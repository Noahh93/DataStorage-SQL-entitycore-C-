using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;
using Pre_Assignment.Repository;

namespace Pre_Assignment.Service
{
    public class CustomerService
    {
        public void RegisterCustomer(Customer customer)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.SaveCustomer(customer);
        }
        public void ShowAllCustomers()
        {
            CustomerRepository cRepository = new CustomerRepository();
            List<Customer> customers = cRepository.GetAllCustomers();

            foreach (Customer customer in customers)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Customer ID = {customer.ID}");
                Console.WriteLine($"First Name = {customer.FirstName}");
                Console.WriteLine($"Last Name = {customer.LastName}");
                Console.WriteLine($"Email = {customer.Email}");
                Console.WriteLine($"Phone = {customer.Phone}\n");
            }

        }
        public void ShowCustomerByID(int id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomerByID(id);
            if(customer != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nID: {customer.ID}");
                Console.WriteLine($"FirstName: {customer.FirstName}");
                Console.WriteLine($"LastName: {customer.LastName}");
                Console.WriteLine($"Phone: {customer.Phone}");
                Console.WriteLine($"Email: {customer.Email}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer not found");
            }
        }
        public void RemoveCustomerByID(int id)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            bool customer = customerRepository.DeleteCustomerByID(id);

            if (customer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour record has been deleted\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour record is not available\n");
            }
        }
        public void ModifyCustomerByID(int id, string firstName, string lastName, string email, string phone)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            bool isUpdated = customerRepository.UpdateCustomerByID(id, firstName, lastName, email, phone);

            if (isUpdated == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCustomer has been updated\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCustomer has not been updated\n");
            }
        }
    }
}
