using Microsoft.EntityFrameworkCore;
using Pre_Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository()
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Employee> GetEmployee()
        {
            List<Employee> employee = _context.Employees.ToList();

            return employee;
        }
        public Employee GetEmployeeByID(int employeeID)
        {
            Employee employee = _context.Employees.Where(x => x.ID == employeeID).First();
            return employee;
        }
        public bool UpdateEmployeeByID(int employeeID, string firstName, string lastName)
        {
            Employee employeeEntity = _context.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            if(employeeEntity != null)
            {
                employeeEntity.FirstName = firstName;
                employeeEntity.LastName = lastName;
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
