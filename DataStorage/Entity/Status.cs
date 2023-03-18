using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Assignment.Entity
{
    public class Status
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ErrorReport> ErrorReports { get; set; }
    }
}
