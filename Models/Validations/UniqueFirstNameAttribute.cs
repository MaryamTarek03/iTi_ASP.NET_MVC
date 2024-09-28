using iTi_day_17_lab.Interfaces;
using iTi_day_17_lab.Models.FirmDatabase;
using iTi_day_17_lab.Repositories;
using System.ComponentModel.DataAnnotations;

namespace iTi_day_17_lab.Models.Validations
{
    public class UniqueFirstNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return null;
            IEmployeeRepo employeeRepo = new EmployeeRepo();
            Employee? employee = employeeRepo.GetEmployeeByFirstName(value.ToString());
            if (employee == null) return ValidationResult.Success;
            return new ValidationResult("This first name already exist!");
        }
    }
}
