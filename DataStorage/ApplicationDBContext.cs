using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;

namespace Pre_Assignment
{
    public class ApplicationDBContext : DbContext
    {
        private readonly string connection = "Data Source=.\\SQLEXPRESS;Initial Catalog=DataStorage;Integrated Security=True;encrypt = false;";
        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<ErrorReport> ErrorReports { get; set; }
    }
}
