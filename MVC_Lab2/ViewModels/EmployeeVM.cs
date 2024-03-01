using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab2.ViewModels
{
    public class EmployeeVM
    {



        public int SSN { get; set; }
        [Length(4, 50, ErrorMessage = "fname must be 4 up to 50 character")]
        [UniqueName]
        [Required(ErrorMessage = "*")]
        public string? Fname { get; set; }
        [Length(4, 50, ErrorMessage = "lname must be 4 up to 50 character")]
        [Required(ErrorMessage = "*")]
        public string? Lname { get; set; }
       
        [Remote("Address", "ClientSide", ErrorMessage = "this address nod defined")]
        public string? Address { get; set; }
        [Range(1000,3000 , ErrorMessage ="salary must be from 1000 to 3000")]
        [Required(ErrorMessage = "*")]

        public decimal Salary { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Compare("ConfirmPassword", ErrorMessage = "Password must match confirm")]
        public string Password { get; set; }
        [Compare("Password" , ErrorMessage = "Password must match confirm")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "*")]
        public int? Dno { get; set; }
        [ValidateNever]
        public SelectList departments { get; set; }     
    }
}
