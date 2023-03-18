using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;
using Pre_Assignment.Service;

namespace Pre_Assignment.Repository
{

    public class ErrorReportRepository
    {
        private readonly ApplicationDBContext _context;
        public ErrorReportRepository() 
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveErrorReport(ErrorReport errorReport)
        {
            _context.ErrorReports.Add(errorReport);
            _context.SaveChanges();
            return true;
        }
        public List<ErrorReport> GetErrorReport()
        {
            List<ErrorReport> errorReports = _context.ErrorReports
                .Include(c => c.Customer)
                .Include(s => s.status)
                .Include(co => co.Comments)
                .ToList();
            return errorReports;
        }
        public ErrorReport GetErrorReportByID(int ERid)
        {
            ErrorReport errorReport = _context.ErrorReports.Include(x => x.Customer).Include(x => x.status).Where(x => x.ID == ERid).FirstOrDefault();
            return errorReport;
        }
        public bool DeleteErrorReportByID(int ERID)
        {
            ErrorReport errorReport = _context.ErrorReports.Where(x => x.ID == ERID).FirstOrDefault();
            if (errorReport != null)
            {
                _context.ErrorReports.Remove(errorReport);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateErrorReportByID(int errorReportID, int statusID)
        {
            
            ErrorReport errorReportEntity = _context.ErrorReports.Where(x => x.ID == errorReportID).FirstOrDefault();
            if (errorReportEntity != null)
            {
                errorReportEntity.StatusID = statusID;
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
