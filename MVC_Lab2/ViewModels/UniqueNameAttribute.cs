
using MVC_Lab2.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Lab2.ViewModels
{
    internal class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            EmployeeVM employeeVM = (EmployeeVM)validationContext.ObjectInstance;
            BanhaDbContext Db = new BanhaDbContext();
            var result = Db.Employees.Where(s => s.Fname == value.ToString() && s.Lname == employeeVM.Lname && s.Dno == employeeVM.Dno).ToList();
            if (result.Count > 0)
            {
                return new ValidationResult("This Name Isn't Unique");
            }
            return ValidationResult.Success;
        }

    }
}