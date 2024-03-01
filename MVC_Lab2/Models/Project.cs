using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.Models
{
    public class Project
    {
        [Key]
        public int Pnumber { get; set; }
        public string Pname { get; set; }
        public string Plocation { get; set; }
        public string City { get; set; }
        public int? Dno { get; set; }

      
        [ForeignKey("Dno")]
        public Department? Department { get; set; }

       
        public List<WorksFor> WorkAssignments { get; set; }
    }
}
