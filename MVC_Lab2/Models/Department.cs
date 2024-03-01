using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.Models
{
    public class Department
    {
        [Key]
        public int Dno { get; set; }
        public string? Dname { get; set; }

       
        public int? MGRSSN { get; set; }
        public DateTime? MGRStartDate { get; set; }
        [ForeignKey("MGRSSN")]
        public Employee? Manger { get; set; }

        public List<Employee> Employees { get; set; }

      
        public List<Project> Projects { get; set; }
        
    }
}
