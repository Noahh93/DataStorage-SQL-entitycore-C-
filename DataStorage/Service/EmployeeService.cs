using Microsoft.EntityFrameworkCore;
using Pre_Assignment.Entity;
using Pre_Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Service
{
    public class EmployeeService
    {

        public void RegisterEmployee(Employee employee)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            bool isEmployeeSaved = employeeRepository.SaveEmployee(employee);
            if(isEmployeeSaved)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Record saved successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Record not saved");
            }

        }
        public void ShowAllEmployees()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employee = employeeRepository.GetEmployee();

            foreach (Employee EMP in employee)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nEmployeeID: {EMP.ID}");
                Console.WriteLine($"Fullname: {EMP.FirstName} {EMP.LastName}");
            }
        }
        public void ShowEmployeeByID(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = employeeRepository.GetEmployeeByID(id);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEmployeeID = {employee.ID}");
            Console.WriteLine($"Employee Name = {employee.FirstName} {employee.LastName}\n");

        }
        public void ModifyEmployeeByID(int id, string firstName, string lastName)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            bool isUpdated = employeeRepository.UpdateEmployeeByID(id, firstName, lastName);
            
            if (isUpdated == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEmployee has been updated\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEmployee has not been updated\n");
            }
        }
    }
}
