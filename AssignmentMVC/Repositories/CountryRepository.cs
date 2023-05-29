using AssignmentMVC.Models;
using System.Data.SqlClient;

namespace AssignmentMVC.Repositories
{
    public class CountryRepository
    {
        private readonly ApplicationDBContext _context;
        public CountryRepository()
        {
            _context = new ApplicationDBContext();
        }
        public List<Country> GetCountries()
        {
           List<Country> countries = _context.Countries.ToList(); //Read(Fetch) from database
           return countries;
        }
    }
}
