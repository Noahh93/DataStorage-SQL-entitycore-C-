using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Entity
{
    public class Customer
    {
        public int ID { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]

        public string Phone { get; set; }

        public List<ErrorReport> ErrorReports { get; set; }
    }
}
