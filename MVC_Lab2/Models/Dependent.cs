using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.Models
{
    public class Dependent
    {
        [Key]
        public int ID { get; set; }
        public int? ESSN { get; set; }
        public string DependentName { get; set; }
        public char Sex { get; set; }
        public DateTime Bdate { get; set; }

       
        [ForeignKey("ESSN")]
        public Employee? Employee { get; set; }
    }
}
