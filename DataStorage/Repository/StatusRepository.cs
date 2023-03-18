using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;

namespace Pre_Assignment.Repository
{
    public class StatusRepository
    {
        private readonly ApplicationDBContext _context;
        public StatusRepository()
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveStatus(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
            Console.WriteLine("\nYour status have been saved!\n");
            return true;
        }
        public Status GetStatusByID(int statusID)
        {
            Status status = _context.Status.Where(x => x.ID == statusID).FirstOrDefault();
            return status;
        }
        public List<Status> GetStatus()
        {
            List<Status> status = _context.Status.ToList();
            return status;
        }
        public bool DeleteStatusByID(int statusID)
        {
            Status status = _context.Status.Where(x => x.ID == statusID).FirstOrDefault();
            if (status != null)
            {
                _context.Status.Remove(status);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateStatusByID(int statusID, string status)
        {
            Status statusEntity = _context.Status.Where(x => x.ID == statusID).FirstOrDefault();
            if (statusEntity != null)
            {
                statusEntity.Name = status;
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
