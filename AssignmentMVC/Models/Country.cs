using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.Models
{
    /*
     If you want to make changes to a property
    1. The table/class has to exist in "ApplicationDBContext.cs"
    2. Type in package manager console "add-migration "meaningful name"
    3. Type in package manager console "update-database
     */

    public class Country            
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}
