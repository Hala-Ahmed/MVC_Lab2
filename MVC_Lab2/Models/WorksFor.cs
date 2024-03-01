using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.Models
{
    public class WorksFor
    {
        //[Key]
        //public int ID { get; set; }
        public int ESSN { get; set; }
        public int Pno { get; set; }
        public int Hours { get; set; }

       
        [ForeignKey("ESSN")]
        public Employee? Employee { get; set; }

       
        [ForeignKey("Pno")]
        public Project? Project { get; set; }
    }
}
