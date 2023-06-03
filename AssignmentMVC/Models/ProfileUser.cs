using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentMVC.Models
{
    public class ProfileUser
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Firstname { get; set; }
        [StringLength(20)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(100)]
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}
