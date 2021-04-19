using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBlack.Model
{
    
        public static class ModelBuilderExtensions
        {
            public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Employee>().HasData(
                        new Employee
                        {
                            Id = 3,
                            Name = "Hary",
                            Department = Dept.IT,
                            Email = "mary@pragimtech.com"
                        },
                        new Employee
                        {
                            Id = 4,
                            Name = "Dany",
                            Department = Dept.HR,
                            Email = "Dany@pragimtech.com"
                        }
                    );
            }
        }
    
}
