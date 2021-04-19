using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Moq;

namespace TestEngine.Moq.ManualMock

{
    public class MockStudentDataMapper : IStudentDataMapper
    {
        public bool ResultToReturn { get; set; }

        public bool StudentNameExistsInDatabase(string name)
        {
            return ResultToReturn;
        }

        public void InsertNewStudentIntoDatabase(string name)
        {
        }

    }
}
