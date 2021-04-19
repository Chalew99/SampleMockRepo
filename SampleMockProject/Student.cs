using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Moq
{
    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Marks { get; private set; }

        public Student(string name, int age, int marks)
        {
            Name = name;
            Age = age;
            Marks = marks;
        }

        public static Student CreateNewStudent(string name, IStudentDataMapper studentDataMapper = null)
        {

            if (studentDataMapper == null)
            {
                studentDataMapper = new StudentDataMapper();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Student name cannot beempty.");
            }

            if (studentDataMapper.StudentNameExistsInDatabase(name))
            {
                throw new ArgumentException("Student name already exists.");
            }

            studentDataMapper.InsertNewStudentIntoDatabase(name);

            return new Student(name, 13, 10);
        }
    }
}