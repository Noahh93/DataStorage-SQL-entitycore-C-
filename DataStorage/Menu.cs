using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pre_Assignment
{
    internal class Menu
    {
        public void Menue()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Customer*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Register Customer");
            Console.WriteLine("2. View Customers");
            Console.WriteLine("3. Update Customer by ID");
            Console.WriteLine("4. Show customer by ID");
            Console.WriteLine("5. Delete Customer by ID");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Status*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("6. Register Status title");
            Console.WriteLine("7. View Statuses");
            Console.WriteLine("8. Update Status");
            Console.WriteLine("9. Show status by ID");
            Console.WriteLine("10. Delete Status");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Compliant*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("11. Register Complaint");
            Console.WriteLine("12. View Complaints");
            Console.WriteLine("13. Update Complaint by ID");
            Console.WriteLine("14. Show Complaint by ID");
            Console.WriteLine("15. Remove Complaint by ID");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Employee*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("16. Register Employee");
            Console.WriteLine("17. View All Employees");
            Console.WriteLine("18. Show Employee by ID");
            Console.WriteLine("19. Update Employee by ID");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Comment*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("20. Insert Comment to a Complaint");


        }
    }
}
