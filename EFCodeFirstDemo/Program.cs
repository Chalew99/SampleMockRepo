using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                // Create and save a new Students
                Console.WriteLine("Adding new students");

                var student = new Student
                {
                    FirstMidName = "Alain",
                    LastName = "Bomer",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student);

                var student1 = new Student
                {
                    FirstMidName = "Mark",
                    LastName = "Upston",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student1);
                context.SaveChanges();

                // Display all Students from the database
                var students = (from s in context.Students
                                orderby s.FirstMidName
                                select s).ToList<Student>();

                Console.WriteLine("Retrieve all Students from the database:");

                foreach (var stdnt in students)
                {
                    string name = stdnt.FirstMidName + " " + stdnt.LastName;
                    Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
        public class Student
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            public DateTime EnrollmentDate { get; set; }

            public virtual ICollection<Enrollment> Enrollments { get; set; }
        }

        public class Course
        {
            public int CourseID { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }

            public virtual ICollection<Enrollment> Enrollments { get; set; }
        }

        public enum Grade
        {
            A, B, C, D, F
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

        //public class MyContext : DbContext
        //{
        //    // public MyContext() : base("MyContextDB") { }

        //    public MyContext() : base("name = MyContextDB") 
        //    {

        //    }

        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        //        base.OnModelCreating(modelBuilder);
        //        modelBuilder.HasDefaultSchema("Admin");
        //        //Map entity to table
        //        modelBuilder.Entity<Student>().ToTable("StudentData");
        //        modelBuilder.Entity<Course>().ToTable("CourseDetail");
        //        modelBuilder.Entity<Enrollment>().ToTable("EnrollmentInfo");
        //        modelBuilder.Entity<Student>().Property(s => s.FirstMidName).HasColumnName("FirstName");

        //    }
        //    public virtual DbSet<Course> Courses { get; set; }
        //    public virtual DbSet<Enrollment> Enrollments { get; set; }
        //    public virtual DbSet<Student> Students { get; set; }
        //}


        public class MyContext : DbContext
        {

            public MyContext() : base("name=MyContextDB")
            {
                Database.SetInitializer<MyContext>(new UniDBInitializer<MyContext>());
        //        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext,
        //EFCodeFirstDemo.Migrations.Configuration>("name=MyContextDB"));
            }

            public virtual DbSet<Course> Courses { get; set; }
            public virtual DbSet<Enrollment> Enrollments { get; set; }
            public virtual DbSet<Student> Students { get; set; }

            private class UniDBInitializer<T> : DropCreateDatabaseAlways<MyContext>
            {

                protected override void Seed(MyContext context)
                {

                    IList<Student> students = new List<Student>();

                    students.Add(new Student()
                    {
                        FirstMidName = "Andrew",
                        LastName = "Peters",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    students.Add(new Student()
                    {
                        FirstMidName = "Brice",
                        LastName = "Lambson",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    students.Add(new Student()
                    {
                        FirstMidName = "Rowan",
                        LastName = "Miller",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    foreach (Student student in students)
                        context.Students.Add(student);
                    base.Seed(context);
                }
            }
        }
    }
}
