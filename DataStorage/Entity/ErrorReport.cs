using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Entity
{
    public class ErrorReport
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("CustomerEntity")]
        public int customerID { get; set; }
        public Status status { get; set; }
        [ForeignKey("StatusEntity")]
        public int? StatusID { get; set; }

        public string Description { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
