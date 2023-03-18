using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Pre_Assignment;
using Pre_Assignment.Entity;
using Pre_Assignment.Repository;
using Pre_Assignment.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

Console.WriteLine("\t\t\t*** ERROR REPORT MANAGEMENT SYSTEM ***");

EmployeeService employeeService = new EmployeeService();
CustomerService customerService= new CustomerService();
ErrorReportService errorReportService = new ErrorReportService();
CommentService commentService = new CommentService();
StatusService statusService = new StatusService();

Menu menu = new Menu();

menu.Menue();
Console.Write("\nPlease pick your option: ");
int choice = Convert.ToInt32(Console.ReadLine());

while (true)
{
    switch (choice)
    {
        case 1:
            Customer customer = new Customer();
            Console.Clear();
            Console.Write("Type your First Name: ");
            customer.FirstName = Console.ReadLine();
            Console.Write("Type your Last Name: ");
            customer.LastName = Console.ReadLine();
            Console.Write("Type your Email: ");
            customer.Email = Console.ReadLine();
            Console.Write("Type your Phone: ");
            customer.Phone = Console.ReadLine();
            customerService.RegisterCustomer(customer);
            break;

        case 2:
            customerService.ShowAllCustomers();
            break;

        case 3:
            Console.Write("\nType the ID of the Customer you want to update: ");
            int id3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nType the new FirstName: ");
            string firstName1 = Console.ReadLine();
            Console.Write("Type the new LastName: ");
            string lastName1 = Console.ReadLine();
            Console.Write("Type the new Email: ");
            string email1 = Console.ReadLine();
            Console.Write("Type the new Phone: ");
            string phone1 = Console.ReadLine();

            customerService.ModifyCustomerByID(id3, firstName1, lastName1, email1, phone1);
            break;

        case 4:
            Console.Write("\nType in the ID of the customer you want to show: ");
            int Customerid = Convert.ToInt32(Console.ReadLine());
            customerService.ShowCustomerByID(Customerid);
            break;

        case 5:
            Console.Write("\nType the ID of the customer you want to remove: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            customerService.RemoveCustomerByID(ID);
            break;



        case 6:
            Status status1 = new Status();
            Console.Write("Type your status title: ");
            status1.Name = Console.ReadLine();
            statusService.RegisterStatus(status1);
            break;

        case 7:
            statusService.ShowAllStatus();
            break;

        case 8:
            Console.Write("\nType the ID of the Status you want to update: ");
            int statid = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nType the new Status: ");
            string firstName2 = Console.ReadLine();
            statusService.ModifyStatusByID(statid, firstName2);
            break;

        case 9:
            Console.Write("\nTo see a specific status, please type in a status ID: ");
            int statusID = Convert.ToInt32(Console.ReadLine());
            statusService.ShowStatusByID(statusID);
            break;

        case 10:
            Console.Write("\nType the ID of the status you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            statusService.RemoveStatusByID(id);
            break;



        case 11:
            ErrorReport errorReport = new ErrorReport();
            Console.Write("Write your CustomerID: ");
            errorReport.customerID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Write your Complaint: ");
            errorReport.Description = Console.ReadLine();
            errorReport.CreatedDate = DateTime.Now;
            errorReportService.RegisterErrorReport(errorReport);

            break;

        case 12:
            errorReportService.ShowAllErrorReport();
            break;

        case 13:
            Console.Write("\nType the ID of the Complaint you want to update: ");
            int empid = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nType the new StatusID: ");
            int status = Convert.ToInt32(Console.ReadLine());
            errorReportService.ModifyErrorReportByID(empid, status);
            break;

        case 14:
            Console.Write("\nType the ID of the error report you want to see: ");
            int id1 = Convert.ToInt32(Console.ReadLine());
            errorReportService.ShowErrorReportByID(id1);

            break;

        case 15:
            Console.Write("\nType the ID of the error report you want to remove: ");
            int id2 = Convert.ToInt32(Console.ReadLine());
            errorReportService.RemoveErrorReportByID(id2);
            break;



        case 16:
            Employee employeeEntity = new Employee();
            Console.Write("\nType the FirstName: ");
            employeeEntity.FirstName = Console.ReadLine();
            Console.Write("\nType the LastName: ");
            employeeEntity.LastName = Console.ReadLine();
            employeeService.RegisterEmployee(employeeEntity);
            break;

        case 17:
            employeeService.ShowAllEmployees();
            break;

        case 18:
            Console.Write("\nType the ID of the Employee you want see: ");
            int employeeID = Convert.ToInt32(Console.ReadLine());
            employeeService.ShowEmployeeByID(employeeID);
            break;

        case 19:
            Console.Write("\nType the ID of the Employee you want to update: ");
            int empid1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nType the new FirstName: ");
            string firstName = Console.ReadLine();
            Console.Write("\nType the new LastName: ");
            string lastName = Console.ReadLine();
            employeeService.ModifyEmployeeByID(empid1, firstName, lastName);
            break;


        case 20:
            Comments comment = new Comments();
            Console.Write("Write your Employee ID: ");
            comment.EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type the Related Complaint ID: ");
            comment.ErrorReportID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Write your Comment: ");
            comment.Description = Console.ReadLine();
            comment.AddedDate = DateTime.Now;
            commentService.RegisterComment(comment);
            break;
    }
    menu.Menue();
    Console.Write("\nPlease pick your option: ");
    choice = Convert.ToInt32(Console.ReadLine());
}
