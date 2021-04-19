using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Moq
{
    public interface IStudentDataMapper
    {
        bool StudentNameExistsInDatabase(string name);
        void InsertNewStudentIntoDatabase(string name);
    }
}