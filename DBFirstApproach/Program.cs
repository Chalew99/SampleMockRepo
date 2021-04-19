using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    class Program
    {

        static void Main(string[] args)
        {
            //using (EF_Demo_DBEntities DBEntities = new EF_Demo_DBEntities())
            //{
            //    List<Student> listStudents = DBEntities.Students.ToList();
            //    Console.WriteLine();
            //    foreach (Student student in listStudents)
            //    {
            //        Console.WriteLine($" Name = {student.FirstName} {student.LastName}, Email {student.StudentAddress?.Email}, Mobile {student.StudentAddress?.Mobile}");
            //    }
            //    Console.ReadKey();
            //}

            using (EF_Demo_DBEntities context = new EF_Demo_DBEntities())
            {
                var students = (from s in context.Students.Include("Standard")
                                select s).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"Firstname: {student.FirstName}, Lastname: {student.LastName}, StandardName: {student.Standard.StandardName}, Description: {student.Standard.Description}");
                }
                Console.Read();
            }
        }

    }
    
}
