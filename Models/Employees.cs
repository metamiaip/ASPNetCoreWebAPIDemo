using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPIDemo.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId
        {
            get;
            set;
        }
        
        public string? EmployeeFirstName
        {
            get;
            set;
        }
        
        public string? EmployeeLastName
        {
            get;
            set;
        }
        
        [Precision(14, 2)]
        public decimal? Salary
        {
            get;
            set;
        }
        public string? Designation
        {
            get;
            set;
        }
    }
}
