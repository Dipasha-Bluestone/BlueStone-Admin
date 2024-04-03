using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlueStone_Admin.Data
{
    public class Profile
{
        [Key]public string? EmailId { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = " ";
        public string Designation { get; set; } = " ";
        public string Role { get; set; } = " ";
        public string Gender { get; set; } = " ";
        public DateTime Birthday { get; set; } = DateTime.Now;
        public int Age { get; set; }
        public long ContactNumber { get; set; }
        public long EmergencyContactNumber { get; set; }
        

    }
}
