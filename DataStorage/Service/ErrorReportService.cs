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
    public class ErrorReportService
    {
        public void RegisterErrorReport(ErrorReport errorReport)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomerByID(errorReport.customerID);

            if(customer != null)
            {
                   ErrorReportRepository errorReportRepository = new ErrorReportRepository();
                   errorReportRepository.SaveErrorReport(errorReport);
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"A customer by the ID: {errorReport.customerID} is not registered");
            }
 
        }
        public void ShowAllErrorReport()
        {
            ErrorReportRepository errorReportRepository = new ErrorReportRepository();
            List<ErrorReport> errorReport = errorReportRepository.GetErrorReport();

            if (errorReport.Count > 0)
            {
                foreach (ErrorReport report in errorReport)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\nErrorReport ID: {report.ID}");
                    Console.WriteLine($"Description {report.Description}");
                    Console.WriteLine($"FirstName {report.Customer.FirstName}");
                    Console.WriteLine($"LastName {report.Customer.LastName}");
                    Console.WriteLine($"Email {report.Customer.Email}");
                    if(report.status != null)
                    {
                        Console.WriteLine($"Complaint Status: {report.status.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Complaint Status: not available");
                    }

                    Console.WriteLine($"Complaint register date: {report.CreatedDate.ToString("dd-MM-yyyy")}\n");

                    foreach (Comments comments in report.Comments)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Comments");
                        Console.WriteLine($"Description: {comments.Description}");
                        Console.WriteLine($"Date created: {comments.AddedDate}\n");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo complaints registered!");
            }
            
        }
        public void ShowErrorReportByID(int id)
        {
            ErrorReportRepository errorReportRepository = new ErrorReportRepository();
            ErrorReport errorReport = errorReportRepository.GetErrorReportByID(id);

            if (errorReport != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nID: {errorReport.ID}");
                Console.WriteLine($"FirstName: {errorReport.Customer.FirstName}");
                Console.WriteLine($"LastName: {errorReport.Customer.LastName}");
                Console.WriteLine($"Email: {errorReport.Customer.Email}");
                Console.WriteLine($"Phone: {errorReport.Customer.Phone}");
                Console.WriteLine($"Date: {errorReport.CreatedDate.ToString("dd-MM-yyyy")}");
                Console.WriteLine($"Status: {errorReport.status.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ErrorReport not found!");
            }
            
        }
        public void RemoveErrorReportByID(int id)
        {
            ErrorReportRepository errorReportRepository = new ErrorReportRepository();
            bool errorReport = errorReportRepository.DeleteErrorReportByID(id);

            if (errorReport)
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
        public void ModifyErrorReportByID(int id, int statusID)
        {
            ErrorReportRepository errorReportRepository = new ErrorReportRepository();
            StatusRepository statusRepository = new StatusRepository();
            Status statusEntity = statusRepository.GetStatusByID(statusID);

            if (statusEntity != null)
            {
                bool isUpdated = errorReportRepository.UpdateErrorReportByID(id, statusID);

                if (isUpdated)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nComplaint has been updated\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nComplaint has not been updated\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status not found");
            }
        }
    }
}
