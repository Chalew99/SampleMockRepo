using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBlack.Model
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please provide a value for Name field")]
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public String Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public string PhotoPath { get; set; }

    }
}
