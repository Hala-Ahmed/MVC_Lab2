using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
       
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        
        public DateTime Bdate { get; set; }
        public string? Address { get; set; }
        public char Sex { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
     
        
        public int? Superssn { get; set; }
        public int? Dno { get; set; }

        public string Password { get; set; }

        [ForeignKey("Dno")]
        public Department? Department { get; set; }

       
        [ForeignKey("Superssn")]
        public Employee? Supervisor { get; set; }

       
        public List<Dependent> Dependents { get; set; }

       
        public List<WorksFor> WorkAssignments { get; set; }
    }
}
