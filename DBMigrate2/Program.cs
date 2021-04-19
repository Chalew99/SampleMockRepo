using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigrate2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }

    public enum Grade { A, B, C, D }
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }

    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        [Index]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }

    public class MyContext : DbContext
    {

        public MyContext() : base("name = MyContextDB2")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, DBMigrate2.Migrations.Configuration>("name = MyContextDB2"));
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

    }
}
