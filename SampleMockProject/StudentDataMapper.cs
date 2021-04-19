using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Engine.Moq
{
    public class StudentDataMapper : IStudentDataMapper
    {
        private readonly string _connectionString = "Data Source=(local);Initial Catalog=Student;IntegratedSecurity=True";
 
      public bool StudentNameExistsInDatabase(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand studentsWithThisName = connection.CreateCommand())
                {
                    studentsWithThisName.CommandType = CommandType.Text;
                    studentsWithThisName.CommandText = "SELECT count(*) FROM Student WHERE 'Name' = @Name";
    

                    studentsWithThisName.Parameters.AddWithValue("@Name", name);
                    var existingRowCount = (int)studentsWithThisName.ExecuteScalar();
                    return existingRowCount > 0;
                }
            }
        }

      public void InsertNewStudentIntoDatabase(string name)
        {
            using (SqlConnection connection = new SqlConnection (_connectionString))
            {
                connection.Open();

                using (SqlCommand studentsWithThisName = connection.CreateCommand())
                {
                    studentsWithThisName.CommandType = CommandType.Text;
                    studentsWithThisName.CommandText = "INSERT INTO Student([Name]) VALUES(@Name)";
    

               studentsWithThisName.Parameters.AddWithValue("@Name", name);

                    studentsWithThisName.ExecuteNonQuery();
                }
            }
        }
    }
}