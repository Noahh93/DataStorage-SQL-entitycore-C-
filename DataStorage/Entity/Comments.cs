using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Entity
{
    public class Comments
    {

        public int ID { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        [ForeignKey("ErrorReportEntity")]
        public int ErrorReportID { get; set; }
        public ErrorReport ErrorReport { get; set; }
        [ForeignKey("EmployeeEntity")]
        public int EmployeeID { get; set; }
        
        public Employee Employee { get; set; }
    }
}
