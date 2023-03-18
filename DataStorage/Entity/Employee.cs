using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Entity
{
    public class Employee
    {
        public int ID { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }

        public List<Comments> Comments { get; set; }
    }
}
