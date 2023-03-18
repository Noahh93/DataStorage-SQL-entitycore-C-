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
    public class StatusService
    {
        public void RegisterStatus(Status status)
        {
            StatusRepository statusRepository = new StatusRepository();
            statusRepository.SaveStatus(status);
        }
        public void ShowAllStatus()
        {
            StatusRepository statusRepository = new StatusRepository();
            List<Status> status = statusRepository.GetStatus();

            foreach (Status statusItem in status)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nStatus ID: {statusItem.ID}");
                Console.WriteLine($"Status Title: {statusItem.Name}\n");
            }
        }
        public void ShowStatusByID(int id)
        {
            StatusRepository statusRepository = new StatusRepository();
            Status status = statusRepository.GetStatusByID(id);
            if(status != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"StatusID = {status.ID}");
                Console.WriteLine($"StatusName = {status.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status not found");
            }
        }
        public void RemoveStatusByID(int id)
        {
            StatusRepository statusRepository = new StatusRepository();
            bool status = statusRepository.DeleteStatusByID(id);

            if(status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour record has been deleted\n");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour record is not deleted/available\n");
            }
        }
        public void ModifyStatusByID(int id, string firstName)
        {
            StatusRepository statusRepository = new StatusRepository();
            bool isUpdated = statusRepository.UpdateStatusByID(id, firstName);

            if (isUpdated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStatus has been updated\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nStatus has not been updated\n");
            }
        }
    }
}
